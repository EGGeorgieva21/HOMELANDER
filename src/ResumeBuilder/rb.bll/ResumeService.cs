using Microsoft.IdentityModel.Tokens;
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
    public class ResumeService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Resume> genericRepository;
        public ResumeService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Resume>(_context);
        }

        public Resume? AddResume(int userId, int templateId)
        {
            if (userId == 0)
            {
                return null;
            }

            Resume resume = new Resume()
            {
                UserId = userId,
                TemplateId = templateId
            };

            genericRepository.Add(resume);
            _context.SaveChanges();

            return genericRepository.GetAll().FirstOrDefault(u => u.UserId == userId);
        }

        public List<Resume>? GetAllByUserId(int userId)
        {
            if (userId == 0)
            {
                return null;
            }

            List<Resume> resumes = new List<Resume>();
            resumes = genericRepository
                .GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return resumes;
        }

        public Resume? EditResume(int id, int userId, int templateId)
        {
            Resume? resume = genericRepository.GetAll().FirstOrDefault(c => c.Id == id);

            if (resume == null)
            {
                return null;
            }

            if (genericRepository.GetAll().Count(c => c.UserId == resume.UserId && c.TemplateId == resume.TemplateId) > 1)
            {
                return null;
            }

            genericRepository.Update(resume);
            _context.SaveChanges();
            return resume;
        }

        public bool RemoveResume(int id)
        {
            Resume? resume = genericRepository.GetAll().FirstOrDefault(c => c.Id == id);
            if (resume == null)
            {
                return false;
            }

            genericRepository.Remove(resume);
            _context.SaveChanges();
            return true;
        }
    }
}