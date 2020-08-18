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
        private readonly IOrderCreatedProducer _orderCreatedProducer;
        private readonly IOrderCreatedConsumer _orderCreatedConsumer;

        public OrderService(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IOrderCreatedProducer orderCreatedProducer, IOrderCreatedConsumer orderCreatedConsumer)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderCreatedProducer = orderCreatedProducer;
            _orderCreatedConsumer = orderCreatedConsumer;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            if (order.OrderDetails == null)
                throw new Exception("Order must have order details.");

            var createdOrder = await _orderRepository.CreateOrderAsync(order);

            await _orderCreatedProducer.Produce(createdOrder);

            await _orderCreatedConsumer.ConsumeAsync();

            return createdOrder;
        }
    }
}