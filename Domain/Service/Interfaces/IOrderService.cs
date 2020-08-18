using System.Threading.Tasks;
using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
