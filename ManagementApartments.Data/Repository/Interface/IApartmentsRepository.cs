using ManagementApartments.Data.Models;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IApartmentsRepository : IRepository<Apartment>
    {
        Apartment Create(Apartment apartment);
        Apartment Get(int id, string userId);
        void Remove(int id, string userId);
        Apartment Save(Apartment apartment);
        Apartment SaveImage(string logoAsString, int apartmentId);
    }
}