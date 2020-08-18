using KafkaDbPairProject.Domain.Service.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Consumers
{
    public class CustomerConsumer : ICustomerConsumer
    {
        public string Consume()
        {
            var consumer = new Consumer<string, string>("CustomerCreatedEvent", 0, "localhost:9092");

            return consumer.Consume();
        }
    }
}