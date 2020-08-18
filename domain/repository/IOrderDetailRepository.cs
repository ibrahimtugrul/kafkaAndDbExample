using kafkaAndDbPairing.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailByOrderId(long orderId);
        Task CreateOrderDetailsAsync(Order order);
    }
}