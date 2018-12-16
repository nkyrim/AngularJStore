using System.Collections.Generic;
using System.Data.Entity;
using AngularJStore.DAL.Models;

namespace AngularJStore.DAL
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var customers = new List<Customer>
            {
                new Customer { Name = "Nick", Phone = "0123456789", Email = "nick@email.com", Company = "NickCompany" },
                new Customer { Name = "John", Phone = "2345236789", Email = "john@email.com", Company = "JohnCompany" },
                new Customer { Name = "George", Phone = "3456435635", Email = "george@email.com", Company = "GeorgeCompany" },
                new Customer { Name = "Gus", Phone = "3457867832", Email = "gus@email.com", Company = "GusCompany" }
            };

            customers.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();

            var orders = new List<Order>
            {
                new Order { CustomerId = 1, Product = "Paper", Price = 100, Quantity = 2 },
                new Order { CustomerId = 1, Product = "Soap", Price = 100, Quantity = 3 },
                new Order { CustomerId = 2, Product = "Shampoo", Price = 100, Quantity = 2 },
                new Order { CustomerId = 2, Product = "Window cleaner", Price = 100, Quantity = 1 },
                new Order { CustomerId = 3, Product = "Detergent", Price = 100, Quantity = 4 },
                new Order { CustomerId = 3, Product = "Soap", Price = 100, Quantity = 3 },
                new Order { CustomerId = 3, Product = "Paper", Price = 100, Quantity = 5 },
                new Order { CustomerId = 4, Product = "Detergent", Price = 100, Quantity = 6 },
                new Order { CustomerId = 4, Product = "Soap", Price = 100, Quantity = 3 },
                new Order { CustomerId = 4, Product = "Shampoo", Price = 100, Quantity = 2 },
                new Order { CustomerId = 4, Product = "Window cleaner", Price = 100, Quantity = 5 }
            };
            orders.ForEach(s => context.Orders.Add(s));
            context.SaveChanges();
        }
    }
}
