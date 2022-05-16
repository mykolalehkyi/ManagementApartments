using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class UtilitiesRepository : Repository<Utility>, IUtilitiesRepository
    {
        public UtilitiesRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<Utility> GetList(int apartmentId)
        {
            var items = this.Context.Utility.Where(x => x.ApartmentId == apartmentId).ToList();
            return items;
        }
    }
}
