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
            var producer = new Producer<string, string>("OrderReceivedEvent", 0, "localhost:9092");
            producer.Produce($"Order{orderReceivedModel.Order.Id}Customer{orderReceivedModel.Customer.Id}", JsonSerializer.Serialize(orderReceivedModel));
        }
    }
}