using System.ComponentModel.DataAnnotations;

namespace AngularJStore.App.Models.Customer
{
    public class EditCustomer
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }

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