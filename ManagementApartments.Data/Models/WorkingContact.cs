using System.ComponentModel.DataAnnotations;

namespace ManagementApartments.Data.Models
{
    public class WorkingContact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}