using System.Collections.Generic;
using KafkaDbPairProject.Domain.Entity;

namespace KafkaDbPairProject.Domain.Service.Interfaces
{
    public interface IOrderDetailService
    {
        List<OrderDetail> GetOrderDetailByOrderId(long orderId);
    }
}
