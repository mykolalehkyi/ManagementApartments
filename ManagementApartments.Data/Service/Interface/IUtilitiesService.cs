using ManagementApartments.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IUtilitiesService
    {
        Utility Create(Utility item);
        Utility Get(int id);
        List<Utility> GetList(int apartmentId);
        void Remove(int id);
        Utility Update(Utility item);
    }
}