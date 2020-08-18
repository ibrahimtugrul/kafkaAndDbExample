using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Data;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;

        public OrderRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var entry = await _context
                .Orders
                .AddAsync(order);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}