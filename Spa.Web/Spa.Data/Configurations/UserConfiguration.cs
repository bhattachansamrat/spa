using Spa.Entities;

namespace Spa.Data.Configurations
{
    public class UserConfiguration:EntityBaseConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(s => s.UserName).IsRequired().HasMaxLength(255);
            Property(s => s.Email).IsRequired().HasMaxLength(255);
            Property(s => s.FullName).IsRequired().HasMaxLength(255);
            Property(s => s.HashedPassword).IsRequired().HasMaxLength(255);
            Property(s => s.PasswordSalt).IsRequired().HasMaxLength(255);
            Property(s => s.IsLocked).IsRequired();
            //Property(s => s.DateCreated);

            HasMany(s => s.UserRoles).WithRequired().HasForeignKey( s=> s.UserId);
        }
    }
}
