using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.Models
{
    public class OrderReceivedModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
    }
}
