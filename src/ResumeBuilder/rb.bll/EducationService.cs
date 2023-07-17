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
    public class EducationService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Education> genericRepository;
        public EducationService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Education>(_context);
        }

        public Education? AddEducation(string place, DateTime? fromDate, DateTime? toDate, int userId)
        {
            if (place.IsNullOrEmpty() || userId == 0 || genericRepository.GetAll().FirstOrDefault(u => u.Place == place && u.UserId == userId) != null)
            {
                return null;
            }

            Education education = new Education()
            { 
                Place = place,
                FromDate = fromDate,
                ToDate = toDate,
                UserId = userId
            };

            genericRepository.Add(education);
            _context.SaveChanges();

            return genericRepository.GetAll().FirstOrDefault(e => e.Place == place && e.UserId == userId);
        }

        public List<Education>? GetAllByUserId(int userId)
        {
            if (userId == 0)
            {
                return null;
            }

            List<Education> educations = new List<Education>();
            educations = genericRepository
                .GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return educations;
        }

        public bool RemoveEducation(int educationId)
        {
            if (educationId == 0)
            {
                return false;
            }

            Education? education = genericRepository.GetAll().FirstOrDefault(c => c.Id == educationId);
            if (education == null)
            {
                return false;
            }

            genericRepository.Remove(education);
            _context.SaveChanges();
            return true;
        }
    }
}
