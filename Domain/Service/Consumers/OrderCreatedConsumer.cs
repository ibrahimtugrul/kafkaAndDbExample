﻿using KafkaDbPairProject.Domain.Entity;
using KafkaDbPairProject.Domain.Repository;
using KafkaDbPairProject.Domain.Service.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Consumers
{
    public class OrderCreatedConsumer : IOrderCreatedConsumer
    {
        private readonly IOrderLogRepository _orderLogRepository;

        public OrderCreatedConsumer(IOrderLogRepository orderLogRepository)
        {
            _orderLogRepository = orderLogRepository;
        }

        public string Consume()
        {
            var consumer = new Consumer<string, string>("OrderCreatedEvent", 5, "localhost:9092");
            
            var result = consumer.Consume();

            var orderLog = new OrderLog
            {
                Event = result
            };

            // Do not mix this Wait call with await operators!
            // It might cause a deadlock
            _orderLogRepository.CreateOrderLog(orderLog).Wait();

            return result;
        }
    }
}
