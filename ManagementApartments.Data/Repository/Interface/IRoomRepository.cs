using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        List<Room> GetList(int apartmentId);
    }
}