using kafkaAndDbPairing.domain.Models;
using kafkaAndDbPairing.domain.repository;
using System.Text.Json;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderReceivedProducer : IOrderReceivedProducer
    {
        private readonly IOrderLogRepository _orderLogRepository;
        private readonly ICustomerConsumer _customerConsumer;

        public OrderReceivedProducer(ICustomerConsumer customerConsumer, IOrderLogRepository orderLogRepository)
        {
            _customerConsumer = customerConsumer;
            _orderLogRepository = orderLogRepository;
        }

        public void Produce()
        {
            var orderLog = _orderLogRepository.ReadOrderLog();
            var customer = _customerConsumer.Consume();

            var orderReceivedModel = new OrderReceivedModel
            {
                Customer = customer,
                Order = JsonSerializer.Deserialize<Order>(orderLog.Event)
            };

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };

            var partition = new Partition(0);
            var topicPartition = new TopicPartition("OrderReceivedEvent", partition);

            using var producer = new ProducerBuilder<string, string>(config).Build();

            producer.Produce(topicPartition, new Message<string, string>
            {
                Key = $"Order{orderReceivedModel.Order.Id}Customer{orderReceivedModel.Customer.Id}",
                Value = JsonSerializer.Serialize(orderReceivedModel)
            });
        }
    }
}