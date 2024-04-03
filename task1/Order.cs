using System;
using System.Collections.Generic;
using System.Linq;

namespace task1 {
    public class Order
    {
        public int OrderId { get; }
        public Client Client { get; }
        public List<OrderDetails> Details { get; }

        public Order(int orderId, Client client, List<OrderDetails> details)
        {
            OrderId = orderId;
            Client = client ?? throw new ArgumentNullException(nameof(client), "Client cannot be null.");
            Details = details ?? throw new ArgumentNullException(nameof(details), "Details cannot be null.");
        }

        public override string ToString()
        {
            return $"Order ID: {OrderId}, Client: {Client.Name}, Items: {string.Join(", ", Details.Select(d => $"{d.Item.Name} x {d.Quantity}"))}";
        }
    }

}