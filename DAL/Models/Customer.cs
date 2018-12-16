using System.Collections.Generic;

namespace AngularJStore.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
