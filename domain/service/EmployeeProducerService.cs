using System.Collections.Generic;
using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public class EmployeeProducerService : IEmployeeProducerService
    {
        public async Task<bool> Produce(Employee employee)
        {
            try
            {
                const string topicName = "PODeneme";
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
                    Value = "MY_VALUE"
                });

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}