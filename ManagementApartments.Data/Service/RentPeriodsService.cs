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
    public class RentPeriodsService : IRentPeriodsService
    {
        private readonly IRentPeriodsRepository rentPeriodsRepository;
        private readonly IMapper mapper;

        public RentPeriodsService(IRentPeriodsRepository rentPeriodsRepository, IMapper mapper)
        {
            this.rentPeriodsRepository = rentPeriodsRepository;
            this.mapper = mapper;
        }

        public RentPeriod Get(int id)
        {
            return rentPeriodsRepository.Find(id);
        }

        public List<RentPeriod> GetList(int apartmentId)
        {
            return rentPeriodsRepository.GetList(apartmentId);
        }

        public RentPeriod Create(RentPeriod item)
        {
            return rentPeriodsRepository.Add(item);
        }

        public RentPeriod Update(RentPeriod item, List<int> tenants)
        {
            return rentPeriodsRepository.Update(item, tenants);
        }

        public List<SelectListItem> GetTenants(int rentPeriodId,string userId)
        {
            return rentPeriodsRepository.GetTenants(userId).Select(x => new SelectListItem()
            {
                Text = x.FirstName + " " + x.LastName,
                Value = x.Id.ToString(),
                Selected = x.RentPeriod.Select(x => x.Id).Contains(rentPeriodId)
            }).ToList();
        }

        //public Apartment Edit(ApartmentCreateDTO apartmentDto, string userId)
        //{
        //    var modelFromDb = apartmentRepository.Get(apartmentDto.Id, userId);
        //    mapper.Map(apartmentDto, modelFromDb);

        //    return apartmentRepository.Update(modelFromDb);
        //}

        public void Remove(int id)
        {
            rentPeriodsRepository.Remove(rentPeriodsRepository.Find(id));
        }
    }
}
