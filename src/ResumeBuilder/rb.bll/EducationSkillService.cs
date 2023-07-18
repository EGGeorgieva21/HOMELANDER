using rb.dal.Data;
using rb.dal.Models;
using rb.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rb.bll
{
    public class EducationSkillService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<EducationSkill> genericRepository;
        public EducationSkillService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<EducationSkill>(_context);
        }

        public EducationSkill? AddEducationSkill(int educationId, int skillId)
        {
            if(educationId <= 0 || skillId <= 0 || genericRepository.GetAll().FirstOrDefault(es => es.EducationId == educationId && es.SkillId == skillId) != null)
            {
                return null;
            }

            EducationSkill educationSkill = new EducationSkill()
            {
                EducationId = educationId,
                SkillId = skillId
            };

            if(educationSkill == null)
            {
                return null;
            }

            genericRepository.Add(educationSkill);
            _context.SaveChanges();
            return genericRepository.GetAll().FirstOrDefault(es => es.EducationId == educationId && es.SkillId == skillId);
        }

        public List<Skill>? GetEducationSkills(int educationId)
        {
            GenericRepository<Education> educationRepository = new GenericRepository<Education>(_context);
            if(educationRepository.GetAll().FirstOrDefault(e => e.Id == educationId) == null)
            {
                return null;
            }
            List<EducationSkill> educationSkills = genericRepository.GetAll()
                .Where(es => es.EducationId == educationId)
                .ToList();

            GenericRepository<Skill> skillRepository = new GenericRepository<Skill>(_context);
            List<Skill> skills = skillRepository.GetAll().ToList();

            List<Skill> result = educationSkills
                .Join(skills,
                es => es.SkillId,
                s => s.Id,
                (es, s) => s)
                .ToList();

            return result;
        }

        public bool RemoveEducationSkill(int educationSkillId)
        {
            EducationSkill? educationSkill = genericRepository.GetAll().FirstOrDefault(es => es.Id == educationSkillId);
            if (educationSkill == null)
            {
                return false;
            }

            genericRepository.Remove(educationSkill);
            _context.SaveChanges();
            return true;
        }
    }
}