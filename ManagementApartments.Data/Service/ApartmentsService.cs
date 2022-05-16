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
    public class ApartmentsService : IApartmentsService
    {
        private readonly IApartmentsRepository apartmentRepository;
        private readonly IMapper mapper;

        public ApartmentsService(IApartmentsRepository apartmentRepository, IMapper mapper)
        {
            this.apartmentRepository = apartmentRepository;
            this.mapper = mapper;
        }

        public IPagedList<Apartment> GetByPage(int page, int pageSize, string userId)
        {
            return apartmentRepository.GetByPage(page, pageSize, userId);
        }

        public Apartment Get(int id, string userId)
        {
            return apartmentRepository.Get(id, userId);
        }

        public Apartment Create(ApartmentCreateDTO apartmentDto, string userId)
        {
            Apartment apartment = mapper.Map<ApartmentCreateDTO, Apartment>(apartmentDto);
            apartment.ApplicationUserId = userId;
            return apartmentRepository.Add(apartment);
        }

        public Apartment Edit(ApartmentCreateDTO apartmentDto, string userId)
        {
            var modelFromDb = apartmentRepository.Get(apartmentDto.Id, userId);
            mapper.Map(apartmentDto, modelFromDb);
            
            return apartmentRepository.Update(modelFromDb);
        }

        public void Remove(int id, string userId)
        {
            apartmentRepository.Remove(id, userId);
        }

        public string SaveImage(IFormFile file, int apartmentId)
        {
            byte[] logoInBytes = new byte[file.Length];
            using (BinaryReader theReader = new BinaryReader(file.OpenReadStream()))
            {
                logoInBytes = theReader.ReadBytes((int)file.Length);
            }

            string logoAsString = Convert.ToBase64String(logoInBytes);
            apartmentRepository.SaveImage(logoAsString, apartmentId);
            return logoAsString;
        }
    }
}
