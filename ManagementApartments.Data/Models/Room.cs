using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Room style")]
        public string RoomStyle { get; set; }
        public double Area { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public List<Equipment> Equipment { get; set; }
    }
}