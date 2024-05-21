using System;
using System.Collections.Generic;
using System.Linq;

public class OrderService
{
    private List<Order> orders;

    public OrderService()
    {
        orders = new List<Order>();
    }

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
            throw new Exception("Order already exists!");
        orders.Add(order);
    }

    public void RemoveOrder(string orderId)
    {
        Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
            throw new Exception("Order not found!");
        orders.Remove(order);
    }

    public void UpdateOrder(Order updatedOrder)
    {
        Order order = orders.FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);
        if (order == null)
            throw new Exception("Order not found!");
        order.Customer = updatedOrder.Customer;
        order.Details = updatedOrder.Details;
    }

    public List<Order> QueryOrders(Func<Order, bool> criteria)
    {
        return orders.Where(criteria).OrderByDescending(o => o.TotalAmount).ToList();
    }

    public List<Order> GetAllOrders()
    {
        return orders.OrderBy(o => o.OrderId).ToList();
    }

    public List<Order> SortOrders(Comparison<Order> comparison)
    {
        List<Order> sortedOrders = new List<Order>(orders);
        sortedOrders.Sort(comparison);
        return sortedOrders;
    }
}
