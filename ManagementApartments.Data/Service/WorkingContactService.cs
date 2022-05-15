using AutoMapper;
using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using ManagementApartments.Data.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace ManagementApartments.Data.Service
{
    public class WorkingContactService : IWorkingContactService
    {
        private readonly IWorkingContactRepository workingContactRepository;
        private readonly IMapper mapper;

        public WorkingContactService(IWorkingContactRepository workingContactRepository, IMapper mapper)
        {
            this.workingContactRepository = workingContactRepository;
            this.mapper = mapper;
        }

        public WorkingContact Get(int id)
        {
            return workingContactRepository.Find(id);
        }

        public List<WorkingContact> GetList(string userId)
        {
            return workingContactRepository.GetList(userId);
        }

        public WorkingContact Create(WorkingContact workingContact)
        {
            return workingContactRepository.Add(workingContact);
        }

        public WorkingContact Update(WorkingContact workingContact)
        {
            return workingContactRepository.Update(workingContact);
        }

        public void Remove(int id)
        {
            workingContactRepository.Remove(workingContactRepository.Find(id));
        }
    }
}
