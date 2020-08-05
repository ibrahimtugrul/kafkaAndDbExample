using System;
using System.Text;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using Newtonsoft.Json;

namespace kafkaAndDbPairing.domain.service
{
    public class EmployeeConsumerService : IEmployeeConsumerService
    {
        public Employee ConsumeEmployee()
        {
            var topicName = "PODeneme";

            var conf = new ConsumerConfig
            {
                GroupId = "emailmessage-consumer-group",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string, string>(conf).Build())
            {
                consumer.Subscribe(topicName);
                var keepConsuming = true;

                while (keepConsuming)
                {
                    try
                    {
                        var consumedTextMessage = consumer.Consume();
                        Console.WriteLine($"Consumed message '{consumedTextMessage.Value}' Topic: {consumedTextMessage.Topic}'.");
                        var message = JsonConvert.DeserializeObject<Employee>(consumedTextMessage.Value);
                    }
                    catch (ConsumeException e)
                    {
                        break;
                    }
                }
                // Ensure the consumer leaves the group cleanly and final offsets are committed.
                consumer.Close();
            }
            return null;
        }
    }
}