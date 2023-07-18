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
        private readonly GenericRepository<Language> genericRepository;
        public EducationService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Language>(_context);
        }

        public Language? AddLanguage(string spokenLanguage, int userId)
        {
            if (spokenLanguage.IsNullOrEmpty() || userId == 0 || genericRepository.GetAll().FirstOrDefault(u => u.Language == spokenLanguage && u.UserId == userId) != null)
            {
                return null;
            }

            Language language = new Language()
            {
                Language = spokenLanguage,
                UserId = userId
            };

            genericRepository.Add(language);
            _context.SaveChanges();

            return genericRepository.GetAll().FirstOrDefault(e => e.Language == spokenLanguage && e.UserId == userId);
        }

        public List<Language>? GetAllByUserId(int userId)
        {
            if (userId == 0)
            {
                return null;
            }

            List<Language> languages = new List<Language>();
            languages = genericRepository
                .GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return languages;
        }

        public Language? EditLanguage(int id, string spokenLanguage)
        {
            Language? language = genericRepository.GetAll().FirstOrDefault(c => c.Id == id);

            if (language == null)
            {
                return null;
            }

            language.spokenLanguage = spokenLanguage;

            if (genericRepository.GetAll().Count(c => c.Language == spokenLanguage && c.UserId == language.UserId) > 1)
            {
                return null;
            }

            genericRepository.Update(language);
            _context.SaveChanges();
            return language;
        }

        public bool RemoveLanguage(int languageId)
        {
            Language? language = genericRepository.GetAll().FirstOrDefault(c => c.Id == languageId);
            if (language == null)
            {
                return false;
            }

            genericRepository.Remove(language);
            _context.SaveChanges();
            return true;
        }
    }
}
