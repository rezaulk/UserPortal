using System;
using System.Data.Entity;
using UserPortal.Core.Entities;

namespace UserPortal.Core.Infrastructure
{
    public class UserPortalDbContext : DbContext
    {
        public UserPortalDbContext():base("UserPortalDbContext")
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
