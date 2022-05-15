using ManagementApartments.Data.Models;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IRoomService
    {
        Room Create(Room room);
        Room Get(int id);
        List<RoomDTO> GetList(int apartmentId);
        void Remove(int id);
        Room Update(Room room);
    }
}