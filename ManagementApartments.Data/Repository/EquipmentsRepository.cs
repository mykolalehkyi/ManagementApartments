using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class EquipmentsRepository : Repository<Equipment>, IEquipmentsRepository
    {
        public EquipmentsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<Equipment> GetList(int roomId)
        {
            var rooms = this.Context.Equipment.Where(x => x.RoomId == roomId).ToList();
            return rooms;
        }
    }
}
