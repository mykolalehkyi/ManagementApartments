using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class ApartmentSpendingsRepository : Repository<ApartmentSpending>, IApartmentSpendingsRepository
    {
        public ApartmentSpendingsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<ApartmentSpending> GetList(int apartmentId)
        {
            var items = this.Context.ApartmentSpending.Where(x => x.ApartmentId == apartmentId).ToList();
            return items;
        }
    }
}
