using System.Text.Json;
using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;
using System;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderCreatedProducer: IOrderCreatedProducer
    {
        public async Task<bool> Produce(Order order)
       {
           try
           {
               await Task.Yield();
               var producer = new Producer<string, string>("OrderCreatedEvent", 5, "localhost:9092");
               producer.Produce("MY_KEY", JsonSerializer.Serialize(order));
               return true;
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
               return false;
           }
       }

    }
}