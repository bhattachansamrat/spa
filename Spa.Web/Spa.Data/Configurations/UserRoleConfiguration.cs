using Spa.Entities;

namespace Spa.Data.Configurations
{
    public class UserRoleConfiguration:EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Property(s => s.UserId).IsRequired();
            Property(s => s.RoleId).IsRequired();
        }
    }
}
