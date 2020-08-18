using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kafkaAndDbPairing.Domain.Data;
using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context;

        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(long orderId)
        {
            return _context
                .OrderDetails
                .Where(x=> x.OrderId == orderId)
                .ToList();
        }

        public async Task CreateOrderDetailsAsync(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                orderDetail.OrderId = order.Id;

                await _context
                    .OrderDetails
                    .AddAsync(orderDetail);

                await _context.SaveChangesAsync();
            }
        }
    }
}
