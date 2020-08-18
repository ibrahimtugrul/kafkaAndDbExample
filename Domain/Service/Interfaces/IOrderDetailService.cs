using System.Collections.Generic;
using kafkaAndDbPairing.Domain.Entity;

namespace kafkaAndDbPairing.Domain.Service.Interfaces
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetOrderDetailByOrderId(long orderId);
    }
}
