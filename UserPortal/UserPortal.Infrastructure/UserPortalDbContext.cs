using System;
using System.Data.Entity;
using UserPortal.Core.Entities;

namespace UserPortal.Core.Infrastructure
{
    public class UserPortalDbContext : DbContext
    {
        public UserPortalDbContext():base("UserPortalDbContext")
        {
            Database.SetInitializer<UserPortalDbContext>(new DropCreateDatabaseIfModelChanges<UserPortalDbContext>());
        }
        public DbSet<User> users { get; set; }
    }
}
