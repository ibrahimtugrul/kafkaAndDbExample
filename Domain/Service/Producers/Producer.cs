using Confluent.Kafka;

namespace kafkaAndDbPairing.Domain.Service.Producers
{
    public class Producer<TKey, TValue> : Interfaces.IProducer<TKey, TValue>
    {
        private readonly TopicPartitionOffset _topicPartitionOffset;
        private readonly string _boostrapServers;
        private ProducerConfig _producerConfig;

        public Producer(string topicName, int partition, string boostrapServers)
        {
            this._boostrapServers = boostrapServers;
            this._topicPartitionOffset = new TopicPartitionOffset(topicName, new Partition(partition), new Offset(0));
        }

        public Producer(TopicPartitionOffset topicPartitionOffset, string boostrapServers)
        {
            this._topicPartitionOffset = topicPartitionOffset;
            this._boostrapServers = boostrapServers;
        }

        public void Produce(TKey key, TValue value)
        {
            CreateConfig();

            ProduceMessage(key, value);
        }

        private void ProduceMessage(TKey key, TValue value)
        {
            using var producer = new ProducerBuilder<TKey, TValue>(this._producerConfig).Build();
            
            producer.Produce(this._topicPartitionOffset.Topic, new Message<TKey, TValue>
            {
                Key = key,
                Value = value
            });
        }

        private void CreateConfig()
        {
            this._producerConfig = new ProducerConfig
            {
                BootstrapServers = this._boostrapServers
            };
        }
    }
}
