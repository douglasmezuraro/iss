﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PSS.Models;

namespace SGCO.Context
{
    public class Context : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }        
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<SaleOrderFreight> SaleOrderFreights { get; set; }
        public DbSet<PurchaseOrderFreight> PurchaseOrderFreights { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<System.DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Entity<PurchaseOrder>().HasRequired(o => o.Freight).WithRequiredPrincipal(f => f.PurchaseOrder);
            modelBuilder.Entity<SaleOrder>().HasRequired(o => o.Freight).WithRequiredPrincipal(f => f.SaleOrder);
            //modelBuilder.Entity<PurchaseOrderFreight>().HasRequired(f => f.PurchaseOrder).WithRequiredPrincipal(o => o.Freight);


            base.OnModelCreating(modelBuilder);
        }

    }
}