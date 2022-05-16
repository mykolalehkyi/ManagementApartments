using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<RentPeriod> RentPeriod { get; set; }
    }
}