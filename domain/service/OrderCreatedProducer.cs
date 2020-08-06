using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderCreatedProducer : IOrderCreatedProducer
    {
        public Task<bool> Produce(Order order)
        {
            return Task.FromResult(false);
        }
    }
}