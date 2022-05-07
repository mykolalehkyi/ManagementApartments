using ManagementApartments.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.Config
{
    public static class ModelBuilderExtensions
    {
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = UserRoles.ADMIN, NormalizedName = UserRoles.ADMIN.ToUpper() },
                new IdentityRole { Id = "2", Name = UserRoles.USER, NormalizedName = UserRoles.USER.ToUpper() }
        );
        }
    }
}
