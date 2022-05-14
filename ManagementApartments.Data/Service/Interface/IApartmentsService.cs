using ManagementApartments.Data.Models;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IApartmentsService
    {
        Apartment Create(ApartmentCreateDTO apartmentDto, string userId);
        Apartment Edit(ApartmentCreateDTO apartmentDto, string userId);
        Apartment Get(int id, string userId);
        IPagedList<Apartment> GetByPage(int page, int pageSize);
        void Remove(int id, string userId);
        string SaveImage(Microsoft.AspNetCore.Http.IFormFile file, int apartmentId);
    }
}