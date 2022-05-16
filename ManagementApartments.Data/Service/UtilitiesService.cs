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
    public class UtilitiesService : IUtilitiesService
    {
        private readonly IUtilitiesRepository utilitiesRepository;
        private readonly IMapper mapper;

        public UtilitiesService(IUtilitiesRepository utilitiesRepository, IMapper mapper)
        {
            this.utilitiesRepository = utilitiesRepository;
            this.mapper = mapper;
        }

        public Utility Get(int id)
        {
            return utilitiesRepository.Find(id);
        }

        public List<Utility> GetList(int apartmentId)
        {
            return utilitiesRepository.GetList(apartmentId);
        }

        public Utility Create(Utility item)
        {
            return utilitiesRepository.Add(item);
        }

        public Utility Update(Utility item)
        {
            return utilitiesRepository.Update(item);
        }

        public void Remove(int id)
        {
            utilitiesRepository.Remove(utilitiesRepository.Find(id));
        }
    }
}
