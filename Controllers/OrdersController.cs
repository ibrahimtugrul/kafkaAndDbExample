using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kafkaAndDbPairing;
using kafkaAndDbPairing.domain.entity;
using kafkaAndDbPairing.domain.service;

namespace kafkaAndDbPairing.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrdersController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("{id}/detail")]
        public ActionResult<List<OrderDetail>> GetOrderDetail([FromRoute]long id)
        {
            var orderDetail = _orderDetailService.GetOrderDetailByOrderId(id);
            return Ok(orderDetail);
        }

        /* // GET: api/Orders
         [HttpGet]
         public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
         {
             return await _context.Orders.ToListAsync();
         }
 
         // GET: api/Orders/5
         [HttpGet("{id}")]
         public async Task<ActionResult<Order>> GetOrder(long id)
         {
             var order = await _context.Orders.FindAsync(id);
 
             if (order == null)
             {
                 return NotFound();
             }
 
             return order;
         }
 
         // PUT: api/Orders/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for
         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
         [HttpPut("{id}")]
         public async Task<IActionResult> PutOrder(long id, Order order)
         {
             if (id != order.Id)
             {
                 return BadRequest();
             }
 
             _context.Entry(order).State = EntityState.Modified;
 
             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!OrderExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }
 
             return NoContent();
         }
 
         // POST: api/Orders
         // To protect from overposting attacks, enable the specific properties you want to bind to, for
         // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
         [HttpPost]
         public async Task<ActionResult<Order>> PostOrder(Order order)
         {
             _context.Orders.Add(order);
             await _context.SaveChangesAsync();
 
             return CreatedAtAction("GetOrder", new { id = order.Id }, order);
         }
 
         // DELETE: api/Orders/5
         [HttpDelete("{id}")]
         public async Task<ActionResult<Order>> DeleteOrder(long id)
         {
             var order = await _context.Orders.FindAsync(id);
             if (order == null)
             {
                 return NotFound();
             }
 
             _context.Orders.Remove(order);
             await _context.SaveChangesAsync();
 
             return order;
         }
 
         private bool OrderExists(long id)
         {
             return _context.Orders.Any(e => e.Id == id);
         }*/
    }
}
