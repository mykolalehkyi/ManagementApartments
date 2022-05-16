using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IUtilitiesRepository : IRepository<Utility>
    {
        List<Utility> GetList(int apartmentId);
    }
}