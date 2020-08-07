using System.Text.Json;

namespace kafkaAndDbPairing.domain.service
{
    public interface IConsumer<TKey, out TValue>
    {
        TValue Consume();
    }
}
