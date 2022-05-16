using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class Utility
    {
        [Key]
        public int Id { get; set; }
        public UtilityTypeEnum UtilityType { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}