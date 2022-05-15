using ManagementApartments.Data.Models;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IEquipmentsService
    {
        Equipment Create(Equipment equipment);
        Equipment Get(int id);
        List<EquipmentDTO> GetList(int roomId);
        void Remove(int id);
        Equipment Update(Equipment equipment);
    }
}