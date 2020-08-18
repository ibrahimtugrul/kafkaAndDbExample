using kafkaAndDbPairing.Domain.Entity;
using kafkaAndDbPairing.Domain.Repository;
using kafkaAndDbPairing.Domain.Service.Interfaces;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Domain.Service.Consumers
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
