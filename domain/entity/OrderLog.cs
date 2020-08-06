using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.entity
{
    public class OrderLog
    {
        public long Id { get; set; }
        public string Event { get; set; }
    }
}