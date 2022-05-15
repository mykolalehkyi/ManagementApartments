using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class WorkingContactRepository : Repository<WorkingContact>, IWorkingContactRepository
    {
        public WorkingContactRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<WorkingContact> GetList(string userId)
        {
            return this.Context.WorkingContact.Where(x => x.ApplicationUserId == userId).ToList();
        }
    }
}
