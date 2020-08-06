using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.service
{
    public interface IOrderCreatedConsumer
    {
        Task ConsumeAsync();
    }
}