using kafkaAndDbPairing.Domain.Interfaces;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface ICustomerConsumer : IConsumer<string, string>
    {
    }
}
