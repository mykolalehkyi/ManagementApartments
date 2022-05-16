using ManagementApartments.Data.Models;
using X.PagedList;

namespace ManagementApartments.Data.Repository.Interface
{
    public interface IApartmentsRepository : IRepository<Apartment>
    {
        Apartment Get(int id, string userId);
        IPagedList<Apartment> GetByPage(int page, int pageSize, string userId);
        void Remove(int id, string userId);
        Apartment SaveImage(string logoAsString, int apartmentId);
    }
}