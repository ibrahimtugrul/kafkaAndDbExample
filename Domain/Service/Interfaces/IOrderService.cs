using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order order);
    }
}
