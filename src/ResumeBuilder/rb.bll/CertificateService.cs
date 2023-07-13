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
    public class CertificateService
    {
        private readonly ResumeBuilderContext _context;
        private readonly GenericRepository<Certificate> genericRepository;
        public CertificateService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<Certificate>(_context);
        }

        public Certificate? AddCertificate(string name, DateTime? issuedDate, DateTime? expirationDate, int userId)
        {
            if(name.IsNullOrEmpty() || userId == 0 || genericRepository.GetAll().FirstOrDefault(u => u.Name == name && u.UserId == userId) != null)
            {
                return null;
            }

            Certificate certificate = new Certificate()
            {
                Name = name,
                IssuedDate = issuedDate,
                ExpirationDate = expirationDate,
                UserId = userId
            };

            genericRepository.Add(certificate);
            _context.SaveChanges();

            return genericRepository.GetAll().FirstOrDefault(u => u.Name == name && u.UserId == userId);
        }
    }
}
