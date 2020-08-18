using System.Threading.Tasks;
using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderCreatedProducer
    {
        Task<bool> Produce(Order order);
    }
}
