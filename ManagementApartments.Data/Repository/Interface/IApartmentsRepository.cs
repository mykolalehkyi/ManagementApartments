using ManagementApartments.Data.Models;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IApartmentsRepository : IRepository<Apartment>
    {
        Apartment Get(int id, string userId);
        void Remove(int id, string userId);
        Apartment SaveImage(string logoAsString, int apartmentId);
    }
}