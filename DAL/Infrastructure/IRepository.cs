using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL.Infrastructure
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        void AddRange(List<T> entity);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
