using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Entities
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string HashedPassword { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
