using Confluent.Kafka;

namespace kafkaAndDbPairing.Domain.Service.Producers
{
    public class Producer<TKey, TValue> : Domain.Service.Interfaces.IProducer<TKey, TValue>
    {
        private TopicPartitionOffset topicPartitionOffset;
        private string boostrapServers;
        private ProducerConfig producerConfig;

        public Producer(string topicName, int partition, string boostrapServers)
        {
            this.boostrapServers = boostrapServers;
            this.topicPartitionOffset = new TopicPartitionOffset(topicName, new Partition(partition), new Offset(0));
        }

        public Producer(TopicPartitionOffset topicPartitionOffset, string boostrapServers)
        {
            this.topicPartitionOffset = topicPartitionOffset;
            this.boostrapServers = boostrapServers;
        }

        public void Produce(TKey key, TValue value)
        {
            CreateConfig();

            ProduceMessage(key, value);
        }

        private void ProduceMessage(TKey key, TValue value)
        {
            using var producer = new ProducerBuilder<TKey, TValue>(this.producerConfig).Build();
            
            producer.Produce(this.topicPartitionOffset.Topic, new Message<TKey, TValue>
            {
                Key = key,
                Value = value
            });
        }

        private void CreateConfig()
        {
            this.producerConfig = new ProducerConfig
            {
                BootstrapServers = this.boostrapServers
            };
        }
    }
}
