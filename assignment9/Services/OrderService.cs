using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Services
{
    public class OrderService
    {
        private readonly OrderManagementContext context;

        public OrderService(OrderManagementContext context)
        {
            this.context = context;
            this.context.Database.EnsureCreated();
        }

        public void AddOrder(Order order)
        {
            if (context.Orders.Any(o => o.OrderID == order.OrderID))
            {
                throw new Exception("Order already exists.");
            }
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void RemoveOrder(string orderId)
        {
            var order = context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = context.Orders.Include(o => o.OrderDetails).FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }
            existingOrder.Customer = order.Customer;
            existingOrder.OrderDetails = order.OrderDetails;
            context.SaveChanges();
        }

        public List<Order> QueryOrders(Func<Order, bool> query)
        {
            return context.Orders.Include(o => o.OrderDetails).AsEnumerable().Where(query).OrderBy(o => o.TotalAmount).ToList();
        }

        public List<Order> GetOrdersSortedBy(Func<Order, object> keySelector)
        {
            return context.Orders.Include(o => o.OrderDetails).AsEnumerable().OrderBy(keySelector).ToList();
        }

        public List<Order> GetOrdersSortedByDefault()
        {
            return context.Orders.Include(o => o.OrderDetails).OrderBy(o => o.OrderID).ToList();
        }
    }
}
