using System;
using System.Collections.Generic;
using System.Text;
using UserPortal.Core.Entities;
using UserPortal.Core.Infrastructure;
using UserPortal.Core.Services;

namespace Test
{
    public class UserPortalDatabseCodeFirst
    {
        public void CreateDb()
        {
            UserPortalDbContext db = new UserPortalDbContext();

            UserPortalService _userPortalService = new UserPortalService(db);

            User U = new User();
            U.FirstName = "reza";
            U.LastName = "karim";
            U.Address = "Dhaka";
            U.BirthDate = "12-02-2019";
            U.Email = "Reza@gmail.com";
            U.Phone = 12113;
            U.Password = "asw";
            U.UserId = 12;

             _userPortalService.Insert(U);
        }
    }
}
