using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;

namespace kafkaAndDbPairing.domain.service
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetOrderDetailByOrderId(long orderId);
    }
}
