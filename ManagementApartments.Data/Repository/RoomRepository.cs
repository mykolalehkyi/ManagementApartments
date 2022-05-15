using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<Room> GetList(int apartmentId)
        {
            var rooms = this.Context.Room.Where(x => x.ApartmentId == apartmentId).ToList();
            return rooms;
        }
    }
}
