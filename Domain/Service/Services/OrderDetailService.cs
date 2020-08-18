using System;
using System.Collections.Generic;
using KafkaDbPairProject.Domain.Entity;
using KafkaDbPairProject.Domain.Repository;
using KafkaDbPairProject.Domain.Service.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Services
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