using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public interface ICustomerConsumer
    {
        Customer Consume();
    }
}
