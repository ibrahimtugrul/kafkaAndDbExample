using Microsoft.EntityFrameworkCore;

namespace kafkaAndDbPairing.domain.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<kafkaAndDbPairing.domain.entity.Order> Orders { get; set; }

        public DbSet<kafkaAndDbPairing.domain.entity.OrderDetail> OrderDetails { get; set; }

        public DbSet<kafkaAndDbPairing.domain.entity.OrderLog> OrderLogs { get; set; }
    }
}