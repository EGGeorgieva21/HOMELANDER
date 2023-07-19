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
    public class SkillService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Skill> genericRepository;
        public SkillService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Skill>(_context);
        }

        public List<Skill> GetAll()
        {
            return genericRepository.GetAll().OrderBy(i => i.Id).ToList();
        }
    }
}
