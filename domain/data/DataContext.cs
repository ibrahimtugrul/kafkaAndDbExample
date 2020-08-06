using kafkaAndDbPairing.domain.entity;
using Microsoft.EntityFrameworkCore;

namespace kafkaAndDbPairing
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<kafkaAndDbPairing.domain.entity.Order> Orders { get; set; }

        public DbSet<kafkaAndDbPairing.domain.entity.OrderDetail> OrderDetails { get; set; }
    }
}