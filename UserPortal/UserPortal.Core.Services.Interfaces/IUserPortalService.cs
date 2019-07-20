using System;
using System.Collections.Generic;
using UserPortal.Core.Entities;

namespace UserPortal.Core.Services.Interfaces
{
    public interface IUserPortalService
    {
        bool Insert(User user);
        bool Update(User user);
        bool Delete(int AddressId);
        bool GetUniqueEmail(string AddressId);

        bool InsertNewPassword(int j,string AddressId);



        

        User Login(User user);

        List<User> GetAllUser();
        List<User> GetAllUserBySearch(string k);

        
        User GetUser(int k);


    }
}
