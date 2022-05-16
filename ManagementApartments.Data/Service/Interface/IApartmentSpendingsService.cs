using ManagementApartments.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IApartmentSpendingsService
    {
        ApartmentSpending Create(ApartmentSpending item);
        ApartmentSpending Get(int id);
        List<ApartmentSpending> GetList(int apartmentId);
        void Remove(int id);
        ApartmentSpending Update(ApartmentSpending item);
    }
}