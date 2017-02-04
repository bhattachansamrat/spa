using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Data.Infrastructure
{
    public class DbFactory: Disposable, IDbFactory
    {
        private SpaContext _dbContext;

        public SpaContext Init()
        {
            return _dbContext?? (_dbContext = new SpaContext());
        }

        public override void DisposeCore()
        {
            if(null !=_dbContext)
            {
                _dbContext.Dispose();
            }
        }
    }
}
