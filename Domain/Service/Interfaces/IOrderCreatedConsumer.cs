using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderCreatedConsumer
    {
        Task ConsumeAsync();
    }
}