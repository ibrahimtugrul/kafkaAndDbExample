using System;
using System.Collections.Generic;
using kafkaAndDbPairing.Domain.Entity;
using kafkaAndDbPairing.Domain.Repository;
using kafkaAndDbPairing.Domain.Service.Interfaces;

namespace kafkaAndDbPairing.Domain.Service.Services
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
            if (orderDetail == null || orderDetail.Count == 0)
            {
                throw new Exception("Order Detail Not Found!");
            }

            return orderDetail;
        }
    }
}