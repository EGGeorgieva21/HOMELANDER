using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using rb.dal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rb.dal.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
    {
        private readonly ResumeBuilderContext _context;
        public GenericRepository(ResumeBuilderContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetAll()
        {   
            return _context.Set<TEntity>();
        }

        public void Add(TEntity? entity)
        {
            if (entity != null)
            {
                _context.Add(entity);
            }
        }

        public void Update(TEntity? entity)
        {
            if (entity != null)
            {
                _context.Update(entity);
            }
        }

        public void Remove(TEntity? entity)
        {
            if(entity != null)
            {
                _context.Remove(entity);
            }
        }
    }

    public interface IRepository<TEntity>
    where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}