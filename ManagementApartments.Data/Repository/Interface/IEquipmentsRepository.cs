using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IEquipmentsRepository : IRepository<Equipment>
    {
        List<Equipment> GetList(int roomId);
    }
}