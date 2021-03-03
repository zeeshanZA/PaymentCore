using DAL.Infrastructure;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Implementation
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private PaymentContext _dbContext;

        public EFRepository(PaymentContext dBContext = null)
        {
            _dbContext = dBContext ?? new PaymentContext();
        }

        public void Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(List<T> entity)
        {
            _dbContext.Set<T>().AddRange(entity);
        }

        public void Delete(T entity)
        {
            T existing = _dbContext.Set<T>().Find(entity);
            if (existing != null) _dbContext.Set<T>().Remove(existing);
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>();
        }
        public T FirstOrDefault(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().FirstOrDefault(predicate);
        }
        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
