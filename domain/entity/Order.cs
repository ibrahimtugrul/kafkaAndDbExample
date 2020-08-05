using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.entity
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
