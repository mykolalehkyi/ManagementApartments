using ManagementApartments.Data.Models;
using System.Collections.Generic;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IWorkingContactService
    {
        WorkingContact Create(WorkingContact workingContact);
        WorkingContact Get(int id);
        List<WorkingContact> GetList(string userId);
        void Remove(int id);
        WorkingContact Update(WorkingContact workingContact);
    }
}