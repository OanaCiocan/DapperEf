using eShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace eShop.DataAccess.EntityFramework.Context
{
    public class OnlineShopContext : DbContext
    {
        public OnlineShopContext(DbContextOptions options) 
            : base(options)
        {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}