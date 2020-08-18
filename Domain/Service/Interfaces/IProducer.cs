using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.service
{
    public interface IProducer<TKey, TValue>
    {
        public void Produce(TKey key, TValue value);
    }
}