using ManagementApartments.Data.Models;
using X.PagedList;

namespace ManagementApartments.Data.Service.Interface
{
    public interface IApartmentsService
    {
        Apartment Create(ApartmentCreateDTO apartmentDto, string userId);
        IPagedList<Apartment> GetByPage(int page, int pageSize);
        string SaveImage(Microsoft.AspNetCore.Http.IFormFile file, int apartmentId);
    }
}