using kafkaAndDbPairing.domain.entity;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.repository
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