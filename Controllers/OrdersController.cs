﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using KafkaDbPairProject.Domain.Entity;
using KafkaDbPairProject.Domain.Service.Interfaces;

namespace KafkaDbPairProject.Controllers
{
    [Route("orders/")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly ICustomerProducer _customerProducer;
        private readonly ICustomerConsumer _customerConsumer;
        private readonly IOrderReceivedProducer _orderReceivedProducer;

        public OrdersController(
            IOrderDetailService orderDetailService, 
            IOrderService orderService, 
            ICustomerProducer customerProducer, 
            ICustomerConsumer customerConsumer, 
            IOrderReceivedProducer orderReceivedProducer)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
            _customerProducer = customerProducer;
            _customerConsumer = customerConsumer;
            _orderReceivedProducer = orderReceivedProducer;
        }

        [HttpGet("{id}/detail")]
        public ActionResult<List<OrderDetail>> GetOrderDetail([FromRoute] long id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailByOrderId(id);
            
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            var createdOrder = await _orderService.CreateOrderAsync(order);
            
            _customerProducer.Produce();
            
            _orderReceivedProducer.Produce();

            return Ok(createdOrder);
        }
    }
}
