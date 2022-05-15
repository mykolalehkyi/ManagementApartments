using AutoMapper;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApartments.Data.Service
{
    public class TenantsService : ITenantsService
    {
        private readonly ITenantsRepository tenantsRepository;
        private readonly IMapper mapper;

        public TenantsService(ITenantsRepository tenantsRepository, IMapper mapper)
        {
            this.tenantsRepository = tenantsRepository;
            this.mapper = mapper;
        }

        public Tenant Get(int id)
        {
            return tenantsRepository.Find(id);
        }

        public List<Tenant> GetList()
        {
            return tenantsRepository.GetAll().ToList();
        }

        public Tenant Create(Tenant tenant)
        {
            return tenantsRepository.Add(tenant);
        }

        public Tenant Update(Tenant tenant)
        {
            return tenantsRepository.Update(tenant);
        }

        public void Remove(int id)
        {
            tenantsRepository.Remove(tenantsRepository.Find(id));
        }
    }
}
