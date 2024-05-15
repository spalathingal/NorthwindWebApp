namespace NorthwindWebApp.Context
{
    using Microsoft.EntityFrameworkCore;
    using NorthwindWebApp.Models;

    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        // DbSet properties for all model classes
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemos { get; set; }
        public DbSet<CustomerDemographics> CustomerDemographics { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure mapping for CustomerCustomerDemo table
            modelBuilder.Entity<CustomerCustomerDemo>()
                .ToTable("customer_customer_demo")
                .HasKey(ccd => new { ccd.CustomerId, ccd.CustomerTypeId });

            // Configure mapping for EmployeeTerritories table
            modelBuilder.Entity<EmployeeTerritory>()
                .ToTable("employee_territories")
                .HasKey(et => new { et.EmployeeId, et.TerritoryId });

            // Configure mapping for OrderDetails table
            modelBuilder.Entity<OrderDetail>()
                .ToTable("order details")
                .HasKey(od => new { od.OrderId, od.ProductId });
        }
    }
}
