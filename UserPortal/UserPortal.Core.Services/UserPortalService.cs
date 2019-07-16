using System;
using System.Data.Entity;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;
using System.Linq;

namespace UserPortal.Core.Services
{
   
    public class UserPortalService : IUserPortalService
    {
        DbContext _context;

        public UserPortalService(DbContext context)
        {
            _context = context;
        }

        public bool Delete(int AddressId)
        {
            var DeleteAddress = _context.Set<User>().Where(i => i.UserId == AddressId).SingleOrDefault();
            
            if (DeleteAddress != null)
            {
                _context.Set<User>().Remove(DeleteAddress);
                _context.SaveChanges();
            }
            return true;
        }
        public bool Insert(User user)
        {
            if (_context.Set<User>().Add(user) == user)
            {
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool Update(User user)
        {
            if (_context.Set<User>().Any(e => e.UserId == user.UserId))
            {
                
                _context.Set<User>().Attach(user);
                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;

        }


    }
}
