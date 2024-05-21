using System;
using System.Collections.Generic;

public class Order : IComparable<Order>
{
    public string OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> Details { get; set; }
    public decimal TotalAmount
    {
        get
        {
            decimal total = 0;
            Details.ForEach(detail => total += detail.TotalPrice);
            return total;
        }
    }

    public Order(string orderId, string customer)
    {
        OrderId = orderId;
        Customer = customer;
        Details = new List<OrderDetails>();
    }

    public void AddDetails(OrderDetails details)
    {
        if (Details.Contains(details))
            throw new Exception("Order details already exist!");
        Details.Add(details);
    }

    public override bool Equals(object obj)
    {
        return obj is Order order && OrderId == order.OrderId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(OrderId);
    }

    public override string ToString()
    {
        return $"Order ID: {OrderId}, Customer: {Customer}, Total Amount: {TotalAmount}";
    }

    public int CompareTo(Order other)
    {
        return OrderId.CompareTo(other.OrderId);
    }
}
