using System.Text.Json;
using Confluent.Kafka;
using kafkaAndDbPairing.Domain.Entity;
using kafkaAndDbPairing.domain.service;
using kafkaAndDbPairing.Domain.Service.Interfaces;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace kafkaAndDbPairing.Domain.Service.Producers
{
    public class OrderCreatedProducer : IOrderCreatedProducer
    {
        private readonly string _bootstrapServers;
        private readonly TopicPartitionOffset _topicPartitionOffset;

        public OrderCreatedProducer() : this("OrderCreatedEvent", 5, "localhost:9092", 0)
        {
        }

        public OrderCreatedProducer(string topic, int partition, string server, int offset)
        {
            _topicPartitionOffset = new TopicPartitionOffset(topic, new Partition(partition), new Offset(offset));
            _bootstrapServers = server;
        }

        public bool Produce(Order order)
        {
            try
            {
                var producer = new Producer<string, string>(
                    _topicPartitionOffset, "localhost:9092");

                producer.Produce("MY_KEY", JsonSerializer.Serialize(order));

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}