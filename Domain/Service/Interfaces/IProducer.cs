namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IProducer<TKey, TValue>
    {
        public void Produce(TKey key, TValue value);
    }
}