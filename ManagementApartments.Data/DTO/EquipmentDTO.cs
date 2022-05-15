using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class EquipmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int RoomId { get; set; }
    }
}