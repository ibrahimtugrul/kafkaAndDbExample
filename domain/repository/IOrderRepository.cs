using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
