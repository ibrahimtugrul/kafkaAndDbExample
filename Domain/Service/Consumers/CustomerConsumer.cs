using kafkaAndDbPairing.Domain.Interfaces;

namespace kafkaAndDbPairing.Domain.Service.Consumers
{
    public class CustomerConsumer : IConsumer<string, string>
    {
        public string Consume()
        {
            var consumer = new Consumer<string, string>("CustomerCreatedEvent", 0, "localhost:9092");

            return consumer.Consume();
        }
    }
}