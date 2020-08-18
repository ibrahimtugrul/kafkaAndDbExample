using KafkaDbPairProject.Domain.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Interfaces
{
    public interface IOrderCreatedConsumer : IConsumer<string, string>
    {
    }
}