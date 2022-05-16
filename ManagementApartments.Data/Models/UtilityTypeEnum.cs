using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public enum UtilityTypeEnum
    {
        [Display(Name = "Electricity")]
        Electricity,
        [Display(Name = "Water")]
        Water,
        [Display(Name = "Gas")]
        Gas
    }
}