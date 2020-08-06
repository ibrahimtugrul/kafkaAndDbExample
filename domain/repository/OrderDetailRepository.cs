using kafkaAndDbPairing.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context;

        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(long OrderId)
        {
            return _context.OrderDetails.Where(x=> x.OrderId == OrderId).ToList();
        }
    }
}
