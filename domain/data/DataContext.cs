using kafkaAndDbPairing.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace kafkaAndDbPairing.Domain.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<OrderLog> OrderLogs { get; set; }
    }
}