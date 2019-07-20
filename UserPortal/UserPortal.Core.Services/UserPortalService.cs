using System;
using System.Data.Entity;
using UserPortal.Core.Entities;
using UserPortal.Core.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace UserPortal.Core.Services
{
   
    public class UserPortalService : IUserPortalService
    {
        DbContext _context;

        public UserPortalService(DbContext context)
        {
            _context = context;
        }

        string CalculateMD5Hash(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
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
            user.Password=CalculateMD5Hash(user.Password);
            if (_context.Set<User>().Add(user) == user)
            {

                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool InsertNewPassword(int k,string userpass)
        {

            if (_context.Set<User>().Any(e => e.UserId == k))
            { 
                User muser=_context.Set<User>().Where(i => i.UserId == k).SingleOrDefault();


                muser.Password = CalculateMD5Hash(userpass);

                _context.Set<User>().Attach(muser);
                _context.Entry(muser).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            else
                return false;

           
        }

        public User Login(User user)
        {
            string k = CalculateMD5Hash(user.Password);
            
            var member = _context.Set<User>().Where(i => i.Email == user.Email && i.Password == k).SingleOrDefault();

          
            if (member != null)
            {
                return member;
            }
            else
                member = null;
                return member;
        }

        public List<User> GetAllUser()
        {
            List<User> member = _context.Set<User>().ToList();

            return member;
        }

        public List<User> GetAllUserBySearch(string k)
        {
            List<User> member = _context.Set<User>().Where(i => i.FirstName.Contains(k) || i.Email.Contains(k)).ToList();

            return member;
        }

        public bool GetUniqueEmail(string k)
        {
            User member = _context.Set<User>().Where(i => i.Email == k).SingleOrDefault();
            if(member!=null)
            {
               return false;
            }
            else
            {
               return true;
            }

          
        }

        public User GetUser(int k)
        {
            var member = _context.Set<User>().Where(i => i.UserId == k).SingleOrDefault();
             
            return member;
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
