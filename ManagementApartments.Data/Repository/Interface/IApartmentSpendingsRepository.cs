using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IApartmentSpendingsRepository : IRepository<ApartmentSpending>
    {
        List<ApartmentSpending> GetList(int apartmentId);
    }
}