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
    public class UserSkillService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<UserSkill> genericRepository;
        public UserSkillService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<UserSkill>(_context);
        }

        public UserSkill? AddUserSkill(int userId, int skillId)
        {
            if (userId <= 0 || skillId <= 0 || genericRepository.GetAll().FirstOrDefault(es => es.UserId == userId && es.SkillId == skillId) != null)
            {
                return null;
            }

            UserSkill userSkill = new UserSkill()
            {
                UserId = userId,
                SkillId = skillId
            };

            if (userSkill == null)
            {
                return null;
            }

            genericRepository.Add(userSkill);
            _context.SaveChanges();
            return genericRepository.GetAll().FirstOrDefault(es => es.UserId == userId && es.SkillId == skillId);
        }

        public List<Skill>? GetUserSkills(int userId)
        {
            GenericRepository<User> userRepository = new GenericRepository<User>(_context);
            if (userRepository.GetAll().FirstOrDefault(e => e.Id == userId) == null)
            {
                return null;
            }
            List<UserSkill> userSkills = genericRepository.GetAll()
                .Where(es => es.UserId == userId)
                .ToList();

            GenericRepository<Skill> skillRepository = new GenericRepository<Skill>(_context);
            List<Skill> skills = skillRepository.GetAll().ToList();

            List<Skill> result = userSkills
                .Join(skills,
                es => es.SkillId,
                s => s.Id,
                (es, s) => s)
                .ToList();

            return result;
        }

        public bool RemoveUserSkill(int userSkillId)
        {
            UserSkill? userSkill = genericRepository.GetAll().FirstOrDefault(es => es.Id == userSkillId);
            if (userSkill == null)
            {
                return false;
            }

            genericRepository.Remove(userSkill);
            _context.SaveChanges();
            return true;
        }
    }
}
