using Confluent.Kafka;

namespace kafkaAndDbPairing.Domain.Service
{
    public class Consumer<TKey, TValue> : IConsumer<TKey, TValue>
    {
        private readonly ConsumerConfig _config;
        private readonly TopicPartition _topicPartition;

        public Consumer(string topic, int partition, string host)
        {
            _config = new ConsumerConfig
            {
                BootstrapServers = host,
                GroupId = "generic-group-id",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                SessionTimeoutMs = 5000,
                SocketTimeoutMs = 6000
            };
            _topicPartition = new TopicPartition(topic, partition);
        }

        public TValue Consume()
        {
            using var consumer = new ConsumerBuilder<TKey, TValue>(_config).Build();

            consumer.Assign(_topicPartition);

            var result = consumer.Consume();
            
            if (result.IsPartitionEOF)
                return default;

            return result.Message.Value;
        }
    }
}