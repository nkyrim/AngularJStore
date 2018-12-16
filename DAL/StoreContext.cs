using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using AngularJStore.DAL.Models;

namespace AngularJStore.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreDatabase")
        {
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<StoreContext>());
            }
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
