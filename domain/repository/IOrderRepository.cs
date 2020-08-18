using kafkaAndDbPairing.Domain.Entity;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
