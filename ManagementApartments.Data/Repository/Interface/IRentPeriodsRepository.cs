using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IRentPeriodsRepository : IRepository<RentPeriod>
    {
        List<RentPeriod> GetList(int apartmentId);
        List<Tenant> GetTenants();
        RentPeriod Update(RentPeriod item, List<int> tenants);
    }
}