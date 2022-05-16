using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class TenantsRepository : Repository<Tenant>, ITenantsRepository
    {
        public TenantsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }
        public List<Tenant> GetList(string userId)
        {
            var rooms = this.Context.Tenant.Where(x => x.ApplicationUserId == userId).ToList();
            return rooms;
        }
    }
}
