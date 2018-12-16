using System.ComponentModel.DataAnnotations;

namespace AngularJStore.App.Models.Customer
{
    public class AddCustomer
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Company { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}