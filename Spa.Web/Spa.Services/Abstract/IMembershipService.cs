using Spa.Entities;
using Spa.Services.Utilities;
using System.Collections.Generic;

namespace Spa.Services.Abstract
{
    public interface IMembershipService
    {
        MembershipContext ValidateUser(string userName, string password);
        User Createuser(string userName, string fullName, string password, string email, int[] roles);
        User GetUser(int userId);
        List<Role> GetUserRoles(string userName);
    }
}
