using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.repository;
using System;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order.OrderDetails == null)
                throw new Exception("Order must have order details.");

            var createdOrder = await _orderRepository.CreateOrderAsync(order);
            
            await _orderDetailRepository.CreateOrderDetailsAsync(createdOrder);

            return createdOrder;
        }
    }
}