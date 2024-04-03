using System;
using System.Collections.Generic;
using System.Linq;

namespace task1 {
    public class OrderService
    {
        private readonly List<Order> _orders = new List<Order>();

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order), "Order cannot be null.");
            if (_orders.Any(o => o.OrderId == order.OrderId)) throw new InvalidOperationException("Order with the same ID already exists.");
            _orders.Add(order);
        }

        public bool ChangeOrder(int orderId, Client client, List<OrderDetails> details)
        {
            var orderIndex = _orders.FindIndex(o => o.OrderId == orderId);
            if (orderIndex == -1) return false;
        
            _orders[orderIndex] = new Order(orderId, client, details);
            return true;
        }

        public Order QueryId(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        public bool DeleteOrder(int orderId)
        {
            return _orders.RemoveAll(o => o.OrderId == orderId) > 0;
        }

        public IEnumerable<Order> QueryName(string goodsName)
        {
            return _orders.Where(o => o.Details.Any(d => d.Item.Name.Equals(goodsName, StringComparison.OrdinalIgnoreCase)));
        }

        public void SortId()
        {
            _orders.Sort((x, y) => x.OrderId.CompareTo(y.OrderId));
        }

        public List<Order> QueryAll()
        {
            return new List<Order>(_orders);
        }
    }
}