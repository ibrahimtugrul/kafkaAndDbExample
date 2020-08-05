using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.repository;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(long orderId)
        {
            var orderDetail = _orderDetailRepository.GetOrderDetailByOrderId(orderId);
            if (orderDetail == null)
            {
                throw new Exception("Order Detail Not Found!");
            }

            return orderDetail;
        }
    }
}