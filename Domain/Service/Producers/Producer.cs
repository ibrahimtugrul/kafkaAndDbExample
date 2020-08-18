using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace kafkaAndDbPairing.domain.service
{
    public class Producer<TKey, TValue> : Domain.Service.Interfaces.IProducer<TKey, TValue>
    {
        private TopicPartition topicPartition;
        private string boostrapServers;
        private ProducerConfig producerConfig;

        public Producer(string topicName, int partition, string boostrapServers)
        {
            this.boostrapServers = boostrapServers;
            this.topicPartition = new TopicPartition(topicName, new Partition(partition));
        }

        public void Produce(TKey key, TValue value)
        {
            CreateConfig();
            ProduceMessage(key, value);
        }

        private void ProduceMessage(TKey key, TValue value)
        {
            using (var producer = new ProducerBuilder<TKey, TValue>(this.producerConfig).Build())
            {
                producer.Produce(this.topicPartition, new Message<TKey, TValue>()
                {
                    Key = key,
                    Value = value
                });
            }
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
