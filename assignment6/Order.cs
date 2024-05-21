using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem
{
    public class Order
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public decimal TotalAmount => OrderDetails.Sum(od => od.Amount);

        public Order(string orderId, string customer)
        {
            OrderID = orderId;
            Customer = customer;
            OrderDetails = new List<OrderDetails>();
        }

        public override bool Equals(object obj)
        {
            return obj is Order order && OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderID);
        }

        public override string ToString()
        {
            return $"OrderID: {OrderID}, Customer: {Customer}, TotalAmount: {TotalAmount:C}";
        }
    }
}
