using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Models
{
    public class OrderReceivedModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
