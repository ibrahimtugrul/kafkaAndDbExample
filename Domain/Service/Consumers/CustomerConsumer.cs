using System.Text.Json;
using kafkaAndDbPairing.Domain.Entity;
using kafkaAndDbPairing.Domain.Service.Interfaces;

namespace kafkaAndDbPairing.Domain.Service.Consumers
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