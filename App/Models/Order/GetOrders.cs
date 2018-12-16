using System.ComponentModel.DataAnnotations;

namespace AngularJStore.Models.Order
{
    public class GetOrders
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
    }
}
