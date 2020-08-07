using System;
using System.Text.Json;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public class CustomerConsumer : ICustomerConsumer
    {
        public Customer Consume()
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "customer-consumer",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            using var consumer = new ConsumerBuilder<string, string>(config).Build();
            
            var partition = new Partition(0);
            var topicPartition = new TopicPartition("CustomerCreatedEvent", partition);
            
            consumer.Assign(topicPartition);

            while (true)
            {
                try
                {
                    var result = consumer.Consume();

                    if (result.IsPartitionEOF)
                        break;

                    var value = result.Message.Value;

                    return JsonSerializer.Deserialize<Customer>(value);
                }
                catch
                {
                    throw;
                }
            }

            return null;
        }
    }
}