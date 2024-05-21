using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem
{
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new Exception("Order already exists.");
            }
            orders.Add(order);
        }

        public void RemoveOrder(string orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderID == orderId);
            if (order == null)
            {
                throw new Exception("Order not found.");
            }
            orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existingOrder == null)
            {
                throw new Exception("Order not found.");
            }
            existingOrder.Customer = order.Customer;
            existingOrder.OrderDetails = order.OrderDetails;
        }

        public List<Order> QueryOrders(Func<Order, bool> query)
        {
            return orders.Where(query).OrderBy(o => o.TotalAmount).ToList();
        }

        public List<Order> GetOrdersSortedBy(Func<Order, object> keySelector)
        {
            return orders.OrderBy(keySelector).ToList();
        }

        public List<Order> GetOrdersSortedByDefault()
        {
            return orders.OrderBy(o => o.OrderID).ToList();
        }
    }
}
