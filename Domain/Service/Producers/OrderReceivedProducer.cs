using System.Text.Json;
using KafkaDbPairProject.Domain.Entity;
using KafkaDbPairProject.Domain.Models;
using KafkaDbPairProject.Domain.Repository;
using KafkaDbPairProject.Domain.Service.Interfaces;
using KafkaDbPairProject.Domain.Service.Producers;

namespace KafkaDbPairProject.domain.service
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
                Customer = JsonSerializer.Deserialize<Customer>(customer),
                Order = JsonSerializer.Deserialize<Order>(orderLog.Event)
            };
            var producer = new Producer<string, string>("OrderReceivedEvent", 0, "localhost:9092");
            producer.Produce($"Order{orderReceivedModel.Order.Id}Customer{orderReceivedModel.Customer.Id}", JsonSerializer.Serialize(orderReceivedModel));
        }
    }
}