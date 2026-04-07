using BusinessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Persistence.Contexts
{
    public class BusinessManagementDbContext :DbContext
    {
        public BusinessManagementDbContext(DbContextOptions<BusinessManagementDbContext> options)
         : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<WarehouseMovement> WarehouseMovements { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<ProcessType> ProcessTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<MaterialProcurement> MaterialProcurements { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }


    }
}
