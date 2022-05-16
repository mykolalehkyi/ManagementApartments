using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public List<RentPeriod> RentPeriod { get; set; }
    }
}