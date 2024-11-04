using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MyApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using MyApp.Data.Context;


    public class MyAppDbContext : DbContext
    {
        // public class MyAppDbContext : IdentityDbContext<IdentityUser>
        // {
        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
       public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Call Identity configurations

            // Configure Many-to-Many relationship
            modelBuilder.Entity<OrderProduct>()
                    .HasKey(op => new { op.OrderId, op.ProductId });

            // Configure relationships
            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);


            base.OnModelCreating(modelBuilder);
            // Configure the composite key for the junction table
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId });


        }

    }

