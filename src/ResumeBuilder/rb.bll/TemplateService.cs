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
    public class TemplateService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Template> genericRepository;
        public TemplateService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Template>(_context);
        }

        public bool AddTemplate(int userId)
        {
            if (userId <= 0)
            {
                return false;
            }

            Template template = new Template()
            {
                UserId = userId
            };

            genericRepository.Add(template);
            _context.SaveChanges();
            return true;
        }

        public List<Template>? GetAllTemplates()
        {
            List<Template> templates = new List<Template>();
            templates = genericRepository
                .GetAll()
                .ToList();

            return templates;
        }

        public bool RemoveTemplate(int templateId)
        {
            if (templateId == 0)
            {
                return false;
            }

            Template? template = genericRepository.GetAll().FirstOrDefault(c => c.Id == templateId);
            if (template == null)
            {
                return false;
            }

            genericRepository.Remove(template);
            _context.SaveChanges();
            return true;
        }
    }
}
