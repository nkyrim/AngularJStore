using System.ComponentModel.DataAnnotations;

namespace AngularJStore.App.Models.Customer
{
    public class DeleteCustomer
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
    }
}
