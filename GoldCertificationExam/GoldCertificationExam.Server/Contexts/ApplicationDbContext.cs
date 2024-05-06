using GoldCertificationExam.Server.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace GoldCertificationExam.Server.Contexts
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<BookingOrder> BookingOrders { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Roles>()
                .HasKey(r => r.Id);
            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserID, ur.RoleID });
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<UserRoles>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ur => ur.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRoles>()
                .HasOne<Roles>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Roles>()
                .HasData(
                    new Roles { Id = 1, RoleName = "User" },
                    new Roles { Id = 2, RoleName = "Admin" });
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "admin@epam.com", Password = "Admin@124", UserName = "Admin" }
            );
            modelBuilder.Entity<UserRoles>().HasData(
                new UserRoles { RoleID = 1, UserID = 1 },
                new UserRoles { RoleID = 2, UserID = 1 }
            );
            modelBuilder.Entity<BookingOrder>()
                .HasOne(e => e.Packages)
                .WithMany()
                .HasForeignKey(e => e.PackageId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Menus>()
                .HasOne(m => m.Package)
                .WithMany(p => p.Menus)
                .HasForeignKey(m => m.PackageID);

            modelBuilder.Entity<Dishes>()
                .HasOne(d => d.Menu)
                .WithMany(m => m.Dishes)
                .HasForeignKey(d => d.MenuID);

            modelBuilder.Entity<Ingredients>()
                .HasOne(i => i.Dish)
                .WithMany(d => d.Ingredients)
                .HasForeignKey(i => i.DishID);

            modelBuilder.Entity<Orders>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerID);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetails>()
                .HasOne(od => od.Dish)
                .WithMany()
                .HasForeignKey(od => od.DishID);
        }
    }


}
  