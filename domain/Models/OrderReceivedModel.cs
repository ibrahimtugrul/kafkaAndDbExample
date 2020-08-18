using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Models
{
    public class OrderReceivedModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
