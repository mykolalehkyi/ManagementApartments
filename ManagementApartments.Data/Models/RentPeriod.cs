using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class RentPeriod
    {
        [Key]
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public double Price { get; set; }
        public bool Payed { get; set; }

        public List<Tenant> Tenants { get; set; }
    }
}