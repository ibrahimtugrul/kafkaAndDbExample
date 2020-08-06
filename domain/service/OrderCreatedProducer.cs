using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using System.Text.Json.Serialization;
using System;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderCreatedProducer : IOrderCreatedProducer
    {
        public async Task<bool> Produce(Order order)
        {
            try
            {
                var topicName = "OrderCreatedEvent";
                var partition = new Partition(5);
                var topicPartition = new TopicPartition(topicName, partition);
                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092"
                };
                using var producer = new ProducerBuilder<string, string>(config).Build();
                await producer.ProduceAsync(topicPartition, new Message<string, string>
                {
                    Key = "MY_KEY",
                    Value = JsonSerializer.Serialize(order).ToString()
                });
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}