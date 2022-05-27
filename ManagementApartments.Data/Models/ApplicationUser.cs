using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<Apartment> Apartments { get; set; }
        public List<WorkingContact> WorkingContact { get; set; }
    }
}
