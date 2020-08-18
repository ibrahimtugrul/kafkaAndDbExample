using System.Threading.Tasks;
using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderCreatedProducer
    {
        bool Produce(Order order);
    }
}
