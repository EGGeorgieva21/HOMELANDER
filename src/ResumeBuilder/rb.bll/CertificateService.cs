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
        private readonly GenericRepository<User> genericRepository;
        public CertificateService()
        {
            _context = new ResumeBuilderContext();
            genericRepository = new GenericRepository<User>(_context);
        }


    }
}
