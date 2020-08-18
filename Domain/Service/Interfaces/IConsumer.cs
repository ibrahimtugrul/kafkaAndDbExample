namespace KafkaDbPairProject.Domain.Interfaces
{
    public interface IConsumer<TKey, out TValue>
    {
        TValue Consume();
    }
}
