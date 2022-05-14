using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.Models
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Apartment Price")]
        public double ApartmentPrice { get; set; }
        [Display(Name = "Rent Price")]
        public double RentPrice { get; set; }
        public double Area { get; set; }
        public string ImageContent { get; set; }


        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RentPeriod> RentPeriods { get; set; }
        public List<Utility> Utility { get; set; }
        public List<ApartmentSpending> ApartmentSpendings { get; set; }
    }
}
