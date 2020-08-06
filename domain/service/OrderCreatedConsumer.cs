using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.repository;

namespace kafkaAndDbPairing.domain.service
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
            var topicName = "OrderCreatedEvent";
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "csharp-consumer",
                EnableAutoCommit = false,
                StatisticsIntervalMs = 5000,
                SessionTimeoutMs = 6000,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnablePartitionEof = true
            };
            

            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                consumer.Subscribe(topicName);
                var keepConsuming = true;
                // TODO: to read from specific partition, we should think about last consumed offset to not consume same data again and again
                consumer.Assign(new TopicPartitionOffset(topicName, 5, new Offset(0)));
                while (keepConsuming)
                {
                    try
                    {
                        ConsumeResult<string, string> consumedTextMessage = consumer.Consume();
                        if (consumedTextMessage.IsPartitionEOF) // TODO: this should be use bc prevent EOF exception or null Message Exception
                        {
                            break;
                        }

                        Console.WriteLine($"Consumed message '{consumedTextMessage.Message.Value}' Topic: {consumedTextMessage.Topic}'.");
                        var message = consumedTextMessage.Message.Value;
                        var orderLog = new OrderLog()
                        {
                            Event = message
                        };
                        await _orderLogRepository.CreateOrderLog(orderLog);
                    }
                    catch (ConsumeException e)
                    {
                        break;
                    }
                }
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumer.Close();
            }
        }
    }
}
