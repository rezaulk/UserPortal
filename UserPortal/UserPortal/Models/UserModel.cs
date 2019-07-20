using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserPortal.Models
{
    public class UserModel
    {
        
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public int age { get; set; }



        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}