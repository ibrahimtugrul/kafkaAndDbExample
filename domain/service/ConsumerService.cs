using System;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using Newtonsoft.Json;

namespace kafkaAndDbPairing.domain.service
{
    public class ConsumerService : IConsumerService
    {
        public Product ConsumeProduct()
        {
            var topicName = "PODeneme";
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "csharp-consumer",
                EnableAutoCommit = false,
                StatisticsIntervalMs = 5000,
                SessionTimeoutMs = 6000,
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnablePartitionEof = true
            };
            var commitPeriod = 5;
            Product message = null;
            using (var consumer = new ConsumerBuilder<Ignore, string>(config)
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .SetStatisticsHandler((_, json) =>
                {
                    //Console.WriteLine($"Statistics: {json}");
                })
                .SetPartitionsAssignedHandler((c, partitions) =>
                {
                    Console.WriteLine($"Assigned partitions: [{string.Join(", ", partitions)}]");
                })
                .SetPartitionsRevokedHandler((c, partitions) =>
                {
                    Console.WriteLine($"Revoking assignment: [{string.Join(", ", partitions)}]");
                })
                .Build())
            {
                consumer.Subscribe(topicName);
               
                try
                {
                    try
                        {
                            
                            var consumeResult = consumer.Consume();
                            if (consumeResult.IsPartitionEOF)
                            {
                                Console.WriteLine(
                                    $"Reached end of topic {consumeResult.Topic}, partition {consumeResult.Partition}, offset {consumeResult.Offset}."); 
                            }

                            Console.WriteLine(
                                $"Received message at {consumeResult.TopicPartitionOffset}: {consumeResult.Message.Value}");
                            if (consumeResult.Offset % commitPeriod == 0)
                            {
                                try
                                {
                                    consumer.Commit(consumeResult);
                                }
                                catch (KafkaException e)
                                {
                                    Console.WriteLine($"Commit error: {e.Error.Reason}");
                                }
                            }

                            message = JsonConvert.DeserializeObject<Product>(consumeResult.Message.Value);
                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Consume error: {e.Error.Reason}");
                        }
                    
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Closing consumer.");
                    consumer.Close();
                }
            }

            return message;
        }
    }
}