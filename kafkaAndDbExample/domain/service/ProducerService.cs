using System.Threading.Tasks;
using Confluent.Kafka;
using kafkaAndDbPairing.domain.entity;
using Newtonsoft.Json;

namespace kafkaAndDbPairing.domain.service
{
    public class ProducerService : IProducerService
    {
        public async Task PublishAsync(Product product)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",

            };
            using (IProducer<string, string> producer = new ProducerBuilder<string, string>(config).Build())
            {
                    var partition = new TopicPartition("PODeneme", new Partition(4));
                    var message = new Message<string, string>()
                    {
                        Key = "Dogac",
                        Value = JsonConvert.SerializeObject(new Product { Id = product.Id, Price = product.Price, Title = product.Title, CategoryId = product.CategoryId})
                    };
                    await producer.ProduceAsync(partition, message);
            }
        }
    }
}