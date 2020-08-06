using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _orderService = orderService;
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

            return Ok(createdOrder);
        }
    }
}
