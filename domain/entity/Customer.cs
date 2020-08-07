using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShippingAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
