using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface ICustomerConsumer
    {
        Customer Consume();
    }
}
