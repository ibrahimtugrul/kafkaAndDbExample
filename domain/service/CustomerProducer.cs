using System.Text.Json;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.repository;

namespace kafkaAndDbPairing.domain.service
{
    public class CustomerProducer : ICustomerProducer
    {
        private readonly ICustomerRepository _repository;

        public CustomerProducer(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void Produce()
        {
            var id = 2;

            var customer = _repository.RetrieveCustomer(id);

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            var topic = "CustomerCreatedEvent";

            using var producer = new ProducerBuilder<string, string>(config).Build();

            producer.Produce(topic, new Message<string, string>()
            {
                Key = $"Customer{id}",
                Value = JsonSerializer.Serialize(customer)
            });
        }
    }
}
