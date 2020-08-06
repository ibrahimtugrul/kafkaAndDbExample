using kafkaAndDbPairing.domain.entity;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.service
{
    public interface IOrderCreatedProducer
    {
        Task<bool> Produce(Order order);
    }
}
