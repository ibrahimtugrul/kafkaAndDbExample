using KafkaDbPairProject.Domain.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Interfaces
{
    public interface ICustomerConsumer : IConsumer<string, string>
    {
    }
}
