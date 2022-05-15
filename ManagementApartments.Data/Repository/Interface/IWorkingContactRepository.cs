using ManagementApartments.Data.Models;
using System.Collections.Generic;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IWorkingContactRepository : IRepository<WorkingContact>
    {
        List<WorkingContact> GetList(string userId);
    }
}