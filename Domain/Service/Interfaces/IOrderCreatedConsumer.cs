using kafkaAndDbPairing.Domain.Interfaces;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderCreatedConsumer : IConsumer<string, string>
    {
    }
}