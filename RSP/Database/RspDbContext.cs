using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RSP.Models;

namespace RSP.Database
{
    public class RspDbContext : IdentityDbContext<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        //public DbSet<Cart_Item> CartItems { get; set; }
        //public DbSet<Courier> Couriers { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Inventory> Inventories { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Robot> Robots { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }

        public RspDbContext(DbContextOptions<RspDbContext> options) :
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
