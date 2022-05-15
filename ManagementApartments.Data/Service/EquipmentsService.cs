using AutoMapper;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service.Interface;
using System.Collections.Generic;

namespace ManagementApartments.Data.Service
{
    public class EquipmentsService : IEquipmentsService
    {
        private readonly IEquipmentsRepository equipmentRepository;
        private readonly IMapper mapper;

        public EquipmentsService(IEquipmentsRepository equipmentRepository, IMapper mapper)
        {
            this.equipmentRepository = equipmentRepository;
            this.mapper = mapper;
        }

        public Equipment Get(int id)
        {
            return equipmentRepository.Find(id);
        }

        public List<EquipmentDTO> GetList(int apartmentId)
        {
            var equipment = equipmentRepository.GetList(apartmentId);
            return mapper.Map<List<Equipment>, List<EquipmentDTO>>(equipment);
        }

        public Equipment Create(Equipment equipment)
        {
            return equipmentRepository.Add(equipment);
        }

        public Equipment Update(Equipment equipment)
        {
            return equipmentRepository.Update(equipment);
        }

        public void Remove(int id)
        {
            equipmentRepository.Remove(equipmentRepository.Find(id));
        }
    }
}
