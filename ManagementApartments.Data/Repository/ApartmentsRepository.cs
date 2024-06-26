﻿using ManagementApartments.Data.Models;
using ManagementApartments.Data.Repository.Interface;
using System.Linq;
using System.Text;
using X.PagedList;

namespace ManagementApartments.Data.Repository
{
    public class ApartmentsRepository : Repository<Apartment>, IApartmentsRepository
    {
        public ApartmentsRepository(ManagementApartmentDbContext context) : base(context)
        {

        }

        public Apartment Get(int id, string userId)
        {
            Apartment apartment = this.Context.Apartment.Where(x => x.Id == id && x.ApplicationUserId == userId).First();
            return apartment;
        }

        public IPagedList<Apartment> GetByPage(int page, int pageSize, string userId)
        {
            return Query().Where(x => x.ApplicationUserId == userId).ToPagedList(page, pageSize);
        }

        public void Remove(int id, string userId)
        {
            Apartment apartment = this.Context.Apartment.Where(x => x.Id == id && x.ApplicationUserId == userId).First();
            this.Context.Apartment.Remove(apartment);
            this.Context.SaveChanges();
        }

        public Apartment SaveImage(string logoAsString, int apartmentId)
        {
            Apartment apartment = this.Context.Apartment.Where(x => x.Id == apartmentId).First();
            apartment.ImageContent = logoAsString;
            this.Context.SaveChanges();
            return apartment;
        }

        public void DeleteLogo(int apartmentId)
        {
            Apartment apartment = this.Context.Apartment.Where(x => x.Id == apartmentId).First();
            apartment.ImageContent = "";
            this.Context.SaveChanges();
        }
    }
}
