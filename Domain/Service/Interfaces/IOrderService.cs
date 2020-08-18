using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
