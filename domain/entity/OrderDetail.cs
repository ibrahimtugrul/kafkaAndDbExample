using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.entity
{
    public class OrderDetail
    {
        public long OrderId { get; set; }
        public long Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Address { get; set; }
    }
}
