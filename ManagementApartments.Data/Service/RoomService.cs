using AutoMapper;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ManagementApartments.Data.Service
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IMapper mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            this.roomRepository = roomRepository;
            this.mapper = mapper;
        }

        public Room Get(int id)
        {
            return roomRepository.Find(id);
        }

        public List<RoomDTO> GetList(int apartmentId)
        {
            List<Room> rooms = roomRepository.GetList(apartmentId);
            return mapper.Map<List<Room>, List<RoomDTO>>(rooms);
        }

        public Room Create(Room room)
        {
            return roomRepository.Add(room);
        }

        public Room Update(Room room)
        {
            return roomRepository.Update(room);
        }

        //public Apartment Edit(ApartmentCreateDTO apartmentDto, string userId)
        //{
        //    var modelFromDb = apartmentRepository.Get(apartmentDto.Id, userId);
        //    mapper.Map(apartmentDto, modelFromDb);

        //    return apartmentRepository.Update(modelFromDb);
        //}

        public void Remove(int id)
        {
            roomRepository.Remove(roomRepository.Find(id));
        }
    }
}
