using AutoMapper;
using ManagementApartments.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Apartment, ApartmentCreateDTO>();
            CreateMap<ApartmentCreateDTO, Apartment>();

            CreateMap<Room, RoomDTO>();
            CreateMap<RoomDTO, Room>();

            CreateMap<EquipmentDTO, Equipment>();
            CreateMap<Equipment, EquipmentDTO>();
        }
    }
}
