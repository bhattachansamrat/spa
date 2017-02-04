using Spa.Data.Infrastructure;
using Spa.Entities;
using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Spa.Data.Repository
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private IDbFactory _dbFactory;
        private SpaContext _dbContext;

        private SpaContext DbContext { get { return _dbContext ?? (_dbContext = _dbFactory.Init()); } }

        public EntityBaseRepository(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public virtual IQueryable<T> All
        {
            get{ return GetAll(); }
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = System.Data.Entity.EntityState.Added;
        }

        public virtual void Delete(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = System.Data.Entity.EntityState.Deleted;
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry entry = DbContext.Entry<T>(entity);
            entry.State = System.Data.Entity.EntityState.Modified;
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return DbContext.Set<T>().Where(predicate);
        }

        public virtual IQueryable<T> GetAll()
        {
            return DbContext.Set<T>();
        }

        public virtual T GetSingle(int id)
        {
            return GetAll().FirstOrDefault(s => s.Id == id);
        }
    }
}
