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

        public Template? AddTemplate(int id, int userId)
        {
            if ( userId == 0 || genericRepository.GetAll().FirstOrDefault(u => u.Id == id && u.UserId == userId) != null)
            {
                return null;
            }

            Template template = new Template()
            { 
                Id = id,
                UserId = userId
            };

            genericRepository.Add(template);
            _context.SaveChanges();

            return genericRepository.GetAll().FirstOrDefault(e => e.Id == id && e.UserId == userId);
        }

        public List<Template>? GetAllByUserId(int userId)
        {
            if (userId == 0)
            {
                return null;
            }

            List<Template> templates = new List<Template>();
            templates = genericRepository
                .GetAll()
                .Where(c => c.UserId == userId)
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

        public Template? EditTemplate(int id)
        {
            Template? template = genericRepository.GetAll().FirstOrDefault(c => c.Id == id);

            if (template == null)
            {
                return null;
            }

            template.Id = id;

            if (genericRepository.GetAll().Count(c => c.Id == id && c.UserId == template.UserId) > 1)
            {
                return null;
            }

            genericRepository.Update(template);
            _context.SaveChanges();
            return template;
        }
    }
}
