using Confluent.Kafka;

namespace KafkaDbPairProject.Domain.Service.Consumers
{
    public class Consumer<TKey, TValue> : Domain.Interfaces.IConsumer<TKey, TValue>
    {
        private readonly ConsumerConfig _config;
        private readonly TopicPartitionOffset _topicPartitionOffset;
        
        // Warning! Static field in generic type. For now, it is ok.
        private static readonly ConsumerConfig DefaultConfig = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = "generic-group-id",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            SessionTimeoutMs = 5000,
            SocketTimeoutMs = 6000
        };

        public Consumer(TopicPartitionOffset topicPartitionOffset, ConsumerConfig config)
        {
            _topicPartitionOffset = topicPartitionOffset;
            _config = config;
        }

        public Consumer(string topic, int partition, string host)
        : this(new TopicPartitionOffset(topic, partition, new Offset(0)), DefaultConfig)
        {
        }

        public TValue Consume()
        {
            using var consumer = new ConsumerBuilder<TKey, TValue>(_config).Build();

            consumer.Assign(_topicPartitionOffset);

            var result = consumer.Consume();
            
            if (result.IsPartitionEOF)
                return default;

            return result.Message.Value;
        }
    }
}