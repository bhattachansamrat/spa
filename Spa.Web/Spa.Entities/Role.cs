using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Entities
{
    public class Role:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
