namespace Spa.Data.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Spa.Data.SpaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Spa.Data.SpaContext context)
        {
            context.RoleSet.AddOrUpdate(s => s.Name, GetRole());

            context.UserSet.AddOrUpdate(u => u.Email, new User[]{
                new User()
                {
                    Email="chsakells.blog@gmail.com",
                    UserName="chsakell",
                    HashedPassword ="XwAQoiq84p1RUzhAyPfaMDKVgSwnn80NCtsE8dNv3XI=",
                    PasswordSalt = "mNKLRbEFCH8y1xIyTXP4qA==",
                    IsLocked = false,
                    DateCreated = DateTime.Now,
                    FullName = "Samrat Bhattachan"
                }
            });

            context.UserRoleSet.AddOrUpdate(new UserRole[] { new UserRole() { RoleId = 1, UserId = 1 } });
        }

        private Role[] GetRole()
        {
            return new Role[] {
                new Role() { Id = 1, Name= "Admin" },
                new Role() { Id = 2, Name= "User" }
            };
        }
    }
}
