using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}