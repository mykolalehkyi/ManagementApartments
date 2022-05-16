using AutoMapper;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace ManagementApartments.Data.Service
{
    public class ApartmentSpendingsService : IApartmentSpendingsService
    {
        private readonly IApartmentSpendingsRepository apartmentSpendingsRepository;
        private readonly IMapper mapper;

        public ApartmentSpendingsService(IApartmentSpendingsRepository apartmentSpendingsRepository, IMapper mapper)
        {
            this.apartmentSpendingsRepository = apartmentSpendingsRepository;
            this.mapper = mapper;
        }

        public ApartmentSpending Get(int id)
        {
            return apartmentSpendingsRepository.Find(id);
        }

        public List<ApartmentSpending> GetList(int apartmentId)
        {
            return apartmentSpendingsRepository.GetList(apartmentId);
        }

        public ApartmentSpending Create(ApartmentSpending item)
        {
            return apartmentSpendingsRepository.Add(item);
        }

        public ApartmentSpending Update(ApartmentSpending item)
        {
            return apartmentSpendingsRepository.Update(item);
        }

        public void Remove(int id)
        {
            apartmentSpendingsRepository.Remove(apartmentSpendingsRepository.Find(id));
        }
    }
}
