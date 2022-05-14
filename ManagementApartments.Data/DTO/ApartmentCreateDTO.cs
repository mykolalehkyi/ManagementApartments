using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApartments.Data.Models
{
    public class ApartmentCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double ApartmentPrice { get; set; }
        public double RentPrice { get; set; }
        public double Area { get; set; }
    }
}
