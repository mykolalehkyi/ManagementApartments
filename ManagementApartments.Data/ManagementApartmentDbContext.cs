using ManagementApartments.Data.Config;
using ManagementApartments.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data
{
    public class ManagementApartmentDbContext : IdentityDbContext<ApplicationUser>
    {

        public ManagementApartmentDbContext()
        {
        }

        public ManagementApartmentDbContext(DbContextOptions<ManagementApartmentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RentPeriod> RentPeriod { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Tenant> Tenant { get; set; }
        public virtual DbSet<WorkingContact> WorkingContact { get; set; }
        public virtual DbSet<ApartmentSpending> ApartmentSpending { get; set; }
        //public virtual DbSet<RentPeriodTenant> RentPeriodTenant { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = .; initial catalog=ManagementApartment; integrated security=SSPI");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedRoles();

            //modelBuilder.Entity<RentPeriodTenant>()
            //    .HasOne(x => x.RentPeriodId)
        }

    }
}