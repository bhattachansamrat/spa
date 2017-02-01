using Spa.Entities;

namespace Spa.Data.Configurations
{
    public class RolesConfiguration:EntityBaseConfiguration<Role>
    {
        public RolesConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(50);
        }
    }
}
