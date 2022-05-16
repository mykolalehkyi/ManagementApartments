using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class RentPeriodsRepository : Repository<RentPeriod>, IRentPeriodsRepository
    {
        public RentPeriodsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public List<RentPeriod> GetList(int apartmentId)
        {
            var items = this.Context.RentPeriod.Where(x => x.ApartmentId == apartmentId).ToList();
            return items;
        }

        public List<Tenant> GetTenants(string userId)
        {
            return this.Context.Tenant.Where(x => x.ApplicationUserId==userId).Include(x => x.RentPeriod).ToList();
        }

        public RentPeriod Update(RentPeriod item, List<int> tenantIds)
        {
            var itemFromDb = this.Context.RentPeriod.Where(x => x.Id == item.Id).Include(x => x.Tenant).First();
            itemFromDb.Tenant.Clear();
            Context.Entry(itemFromDb).State = EntityState.Modified;
            Context.SaveChanges();
            itemFromDb.Start = item.Start;
            itemFromDb.End = item.End;
            itemFromDb.Price = item.Price;
            itemFromDb.Payed = item.Payed;

            List<Tenant> tenants = this.Context.Tenant.Where(x => tenantIds.Contains(x.Id)).ToList();
            itemFromDb.Tenant = tenants;
            Context.Entry(itemFromDb).State = EntityState.Modified;
            Context.SaveChanges();
            return item;
        }
    }
}
