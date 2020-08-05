using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public interface IConsumerService
    {
        public Product ConsumeProduct();
    }
}