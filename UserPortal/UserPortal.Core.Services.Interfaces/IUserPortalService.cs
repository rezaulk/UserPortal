using System;
using UserPortal.Core.Entities;

namespace UserPortal.Core.Services.Interfaces
{
    public interface IUserPortalService
    {
        bool Insert(User user);
        bool Update(User user);
        bool Delete(int AddressId);
    }
}
