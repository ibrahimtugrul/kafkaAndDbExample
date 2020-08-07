using kafkaAndDbPairing.domain.entity;
using System.Text.Json;

namespace kafkaAndDbPairing.domain.service
{
    public class CustomerConsumer : ICustomerConsumer
    {
        public Customer Consume()
        {
            var consumer = new Consumer<string, string>("CustomerCreatedEvent", 0, "localhost:9092");

            var result = consumer.Consume();

            return JsonSerializer.Deserialize<Customer>(result);
        }
    }
}