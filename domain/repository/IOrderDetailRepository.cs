using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.repository
{
    public interface IOrderDetailRepository
    {
        public List<OrderDetail> GetOrderDetailByOrderId(long OrderId);
    }
}