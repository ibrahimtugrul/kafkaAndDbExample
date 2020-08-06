﻿using kafkaAndDbPairing.domain.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kafkaAndDbPairing.domain.repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _context;

        public OrderDetailRepository(DataContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetOrderDetailByOrderId(long orderId)
        {
            return _context.OrderDetails.Where(x=> x.OrderId == orderId).ToList();
        }

        public async Task CreateOrderDetailsAsync(Order order)
        {
            foreach (var orderDetail in order.OrderDetails)
            {
                await _context
                    .OrderDetails
                    .AddAsync(orderDetail);
            }

            await _context.SaveChangesAsync();
        }
    }
}
