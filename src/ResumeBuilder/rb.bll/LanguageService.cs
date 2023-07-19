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
    public class LanguageService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Language> genericRepository;
        public LanguageService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Language>(_context);
        }

        public List<Language> GetAll()
        {
            return genericRepository.GetAll().OrderBy(i => i.Id).ToList();
        }
    }
}
