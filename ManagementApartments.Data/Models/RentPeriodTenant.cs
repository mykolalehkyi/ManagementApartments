using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class RentPeriodTenant
    {
        [Key]
        public int RentPeriodId { get; set; }
        [Key]
        public int TenantId { get; set; }

        public RentPeriod RentPeriod { get; set; }
        public Tenant Tenant { get; set; }

    }
}