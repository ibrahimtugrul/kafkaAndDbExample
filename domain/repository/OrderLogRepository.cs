using System.Linq;
using System.Threading.Tasks;
using kafkaAndDbPairing.Domain.Data;

namespace kafkaAndDbPairing.Domain.Repository
{
    public class OrderLogRepository : IOrderLogRepository
    {
        private readonly DataContext _context;

        public OrderLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateOrderLog(OrderLog orderLog)
        {
            await _context.OrderLogs.AddAsync(orderLog);
            await _context.SaveChangesAsync();
        }

        public OrderLog ReadOrderLog()
        {
            return _context
                .OrderLogs
                .FirstOrDefault();
        }
    }
}