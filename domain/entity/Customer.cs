using System;

namespace KafkaDbPairProject.Domain.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
