using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.service
{
    public interface IOrderCreatedConsumer
    {
        Task ConsumeAsync();
    }
}