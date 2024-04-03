namespace NorthwindWebApp.Models
{
    using Microsoft.EntityFrameworkCore;

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
        public DbSet<USState> USStates { get; set; }
        // Add DbSet properties for other model classes...

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure mapping for Categories table
            modelBuilder.Entity<Category>()
                .ToTable("categories")
                .HasKey(c => c.CategoryId);

            // Configure mapping for Customers table
            modelBuilder.Entity<Customer>()
                .ToTable("customers")
                .HasKey(c => c.CustomerId);

            // Configure mapping for CustomerCustomerDemo table
            modelBuilder.Entity<CustomerCustomerDemo>()
                .ToTable("customer_customer_demo")
                .HasKey(ccd => new { ccd.CustomerId, ccd.CustomerTypeId });

            // Configure mapping for CustomerDemographics table
            modelBuilder.Entity<CustomerDemographics>()
                .ToTable("customer_demographics")
                .HasKey(cd => cd.CustomerTypeId);

            // Configure mapping for Employees table
            modelBuilder.Entity<Employee>()
                .ToTable("employees")
                .HasKey(e => e.EmployeeId);

            // Configure mapping for EmployeeTerritories table
            modelBuilder.Entity<EmployeeTerritory>()
                .ToTable("employee_territories")
                .HasKey(et => new { et.EmployeeId, et.TerritoryId });

            // Configure mapping for Orders table
            modelBuilder.Entity<Order>()
                .ToTable("orders")
                .HasKey(o => o.OrderId);

            // Configure mapping for OrderDetails table
            modelBuilder.Entity<OrderDetail>()
                .ToTable("order details")
                .HasKey(od => new { od.OrderId, od.ProductId });

            // Configure mapping for Products table
            modelBuilder.Entity<Product>()
                .ToTable("products")
                .HasKey(p => p.ProductId);

            // Configure mapping for Regions table
            modelBuilder.Entity<Region>()
                .ToTable("regions")
                .HasKey(r => r.RegionId);

            // Configure mapping for Shippers table
            modelBuilder.Entity<Shipper>()
                .ToTable("shippers")
                .HasKey(s => s.ShipperId);

            // Configure mapping for Suppliers table
            modelBuilder.Entity<Supplier>()
                .ToTable("suppliers")
                .HasKey(s => s.SupplierId);

            // Configure mapping for Territories table
            modelBuilder.Entity<Territory>()
                .ToTable("territories")
                .HasKey(t => t.TerritoryId);

            // Configure mapping for USStates table
            modelBuilder.Entity<USState>()
                .ToTable("us_states")
                .HasKey(s => s.StateId);

            // Configure mapping for other tables...
        }
    }
}
