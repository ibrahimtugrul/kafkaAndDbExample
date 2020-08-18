using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.repository;
using System;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Service
{
    public class OrderCreatedConsumer : IOrderCreatedConsumer
    {
        private readonly IOrderLogRepository _orderLogRepository;

        public OrderCreatedConsumer(IOrderLogRepository orderLogRepository)
        {
            _orderLogRepository = orderLogRepository;
        }

        public async Task ConsumeAsync()
        {
            var consumer = new Consumer<string, string>("OrderCreatedEvent", 5, "localhost:9092");

            var result = consumer.Consume();

            var orderLog = new OrderLog
            {
                Event = result
            };

            await _orderLogRepository.CreateOrderLog(orderLog);
        }
    }
}
