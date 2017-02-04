using Spa.Data.Repository;
using Spa.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa.Data.Extension
{
    public static class UserRepositoryExtension
    {
        public static User GetSingleByUserName(this IEntityBaseRepository<User> userRepository, string userName)
        {
            return userRepository.GetAll().FirstOrDefault(s => s.UserName == userName);
        }
    }
}
