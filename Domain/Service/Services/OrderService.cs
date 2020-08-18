using System;
using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;
using KafkaDbPairProject.Domain.Repository;
using KafkaDbPairProject.Domain.Service.Interfaces;

namespace KafkaDbPairProject.Domain.Service.Services
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

            _orderCreatedProducer.Produce(createdOrder);

            // It is ignored for now.
            var result = _orderCreatedConsumer.Consume();

            return createdOrder;
        }
    }
}