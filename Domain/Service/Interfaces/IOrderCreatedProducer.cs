using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Service.Interfaces
{
    public interface IOrderCreatedProducer
    {
        bool Produce(Order order);
    }
}
