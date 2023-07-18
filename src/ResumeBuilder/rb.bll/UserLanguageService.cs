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
    public class UserLanguageService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<UserLanguage> genericRepository;
        public UserLanguageService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<UserLanguage>(_context);
        }

        public UserLanguage? AddUserLanguage(int userId, int languageId)
        {
            if (userId <= 0 || languageId <= 0 || genericRepository.GetAll().FirstOrDefault(es => es.UserId == userId && es.LanguageId == languageId) != null)
            {
                return null;
            }

            UserLanguage userLanguage = new UserLanguage()
            {
                UserId = userId,
                LanguageId = languageId
            };

            if (userLanguage == null)
            {
                return null;
            }

            genericRepository.Add(userLanguage);
            _context.SaveChanges();
            return genericRepository.GetAll().FirstOrDefault(es => es.UserId == userId && es.LanguageId == languageId);
        }

        public List<Language>? GetUserLanguages(int userId)
        {
            GenericRepository<User> userRepository = new GenericRepository<User>(_context);
            if (userRepository.GetAll().FirstOrDefault(e => e.Id == userId) == null)
            {
                return null;
            }
            List<UserLanguage> userLanguages = genericRepository.GetAll()
                .Where(es => es.UserId == userId)
                .ToList();

            GenericRepository<Language> languageRepository = new GenericRepository<Language>(_context);
            List<Language> languages = languageRepository.GetAll().ToList();

            List<Language> result = userLanguages
                .Join(languages,
                es => es.LanguageId,
                s => s.Id,
                (es, s) => s)
                .ToList();

            return result;
        }

        public bool RemoveUserLanguage(int educationLanguageId)
        {
            UserLanguage? userLanguage = genericRepository.GetAll().FirstOrDefault(es => es.Id == educationLanguageId);
            if (userLanguage == null)
            {
                return false;
            }

            genericRepository.Remove(userLanguage);
            _context.SaveChanges();
            return true;
        }
    }
}
