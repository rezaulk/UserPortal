using System;
using UserPortal.Core.Entities;

namespace UserPortal.Core.Services.Interfaces
{
    public interface IUserPortalService
    {
        bool Insert(User address);
        bool Update(User address);
        bool Delete(int AddressId);
    }
}
