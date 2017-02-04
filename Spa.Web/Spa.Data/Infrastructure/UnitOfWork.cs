using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbFactory _dbFactory;
        private SpaContext _dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public SpaContext DbContext { get { return _dbContext ?? (_dbContext = _dbFactory.Init()); } } 

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
