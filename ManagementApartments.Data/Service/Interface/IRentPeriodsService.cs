using ManagementApartments.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IRentPeriodsService
    {
        RentPeriod Create(RentPeriod item);
        RentPeriod Get(int id);
        List<RentPeriod> GetList(int apartmentId);
        List<SelectListItem> GetTenants(int rentPeriodId, string userId);
        void Remove(int id);
        RentPeriod Update(RentPeriod item, List<int> tenants);
    }
}