using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class ApartmentSpending
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}