using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PSS.Models;

namespace SGCO.Context
{
    public class Context : DbContext
    {
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<FreightType> FreightTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Freight> Freights { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}