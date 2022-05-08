using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using System.Linq;
using System.Text;

namespace ManagementApartments.Data.Repository
{
    public class ApartmentsRepository : Repository<Apartment>, IApartmentsRepository
    {
        public ApartmentsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public Apartment Create(Apartment apartment)
        {
            this.Context.Apartment.Add(apartment);
            this.Context.SaveChanges();
            return apartment;
        }

        public Apartment SaveImage(string logoAsString, int apartmentId)
        {
            Apartment apartment = this.Context.Apartment.Where(x => x.Id == apartmentId).First();
            apartment.ImageContent = logoAsString;
            this.Context.SaveChanges();
            return apartment;
        }
    }
}
