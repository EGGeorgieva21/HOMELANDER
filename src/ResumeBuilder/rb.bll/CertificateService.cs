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

        public List<Certificate>? GetAllByUserId(int userId)
        {
            if(userId == 0)
            {
                return null;
            }

            List<Certificate> certificates = new List<Certificate>();
            certificates = genericRepository
                .GetAll()
                .Where(c => c.UserId == userId)
                .ToList();

            return certificates;
        }

        public Certificate? EditCertificate(int id, string name, DateTime? issuedDate, DateTime? expirationDate)
        {
            Certificate? certificate = genericRepository.GetAll().FirstOrDefault(c => c.Id == id);

            if (certificate == null)
            {
                return null;
            }

            certificate.Name = name;
            certificate.IssuedDate = issuedDate;
            certificate.ExpirationDate = expirationDate;

            if (genericRepository.GetAll().Count(c => c.Name == name && c.UserId == certificate.UserId) > 1)
            {
                return null;
            }

            genericRepository.Update(certificate);
            _context.SaveChanges();
            return certificate;
        }

        public bool RemoveCertificate(int certificateId)
        {
            Certificate? certificate = genericRepository.GetAll().FirstOrDefault(c => c.Id == certificateId);
            if(certificate == null)
            {
                return false;
            }

            genericRepository.Remove(certificate);
            _context.SaveChanges();
            return true;
        }
    }
}
