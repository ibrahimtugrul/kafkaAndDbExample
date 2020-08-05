using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public interface IProducerService
    {
        public Task PublishAsync(Product product);
    }
}