using ManagementApartments.Data.Models;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IApartmentsRepository : IRepository<Apartment>
    {
        Apartment Create(Apartment apartment);
        Apartment SaveImage(string logoAsString, int apartmentId);
    }
}