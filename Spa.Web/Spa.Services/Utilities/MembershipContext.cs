using Spa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Services.Utilities
{
    public class MembershipContext
    {
        public User User { get; set; }
        public IPrincipal Principal { get; set; }

        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
