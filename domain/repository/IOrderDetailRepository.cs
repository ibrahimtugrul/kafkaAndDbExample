using System.Collections.Generic;
using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailByOrderId(long orderId);
        Task CreateOrderDetailsAsync(Order order);
    }
}