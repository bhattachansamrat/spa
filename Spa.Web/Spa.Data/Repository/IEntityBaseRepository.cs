using Spa.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Spa.Data.Repository
{
    public interface IEntityBaseRepository<T> where T : class,IEntityBase, new()
    {
        T GetSingle(int id);
        IQueryable<T> GetAll();
        IQueryable<T> All { get; }
        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
