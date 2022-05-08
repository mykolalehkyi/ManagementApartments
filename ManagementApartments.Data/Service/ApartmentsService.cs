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

        public IPagedList<Apartment> GetByPage(int page, int pageSize)
        {
            return apartmentRepository.GetByPage(page, pageSize);
        }

        public Apartment Create(ApartmentCreateDTO apartmentDto, string userId)
        {
            Apartment apartment = mapper.Map<ApartmentCreateDTO, Apartment>(apartmentDto);
            apartment.ApplicationUserId = userId;
            return apartmentRepository.Create(apartment);
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
