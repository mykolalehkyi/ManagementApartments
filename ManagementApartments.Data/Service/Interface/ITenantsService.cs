using ManagementApartments.Data.Models;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface ITenantsService
    {
        Tenant Create(Tenant tenant);
        Tenant Get(int id);
        List<Tenant> GetList(string userId);
        void Remove(int id);
        Tenant Update(Tenant tenant);
    }
}