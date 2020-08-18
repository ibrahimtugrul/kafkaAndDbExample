using System;
using System.Collections.Generic;

namespace kafkaAndDbPairing.Domain.Entity
{
    public class Order
    {
        public long Id { get; set; }
        public long ItemCount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
