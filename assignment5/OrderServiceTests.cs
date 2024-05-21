using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

public class OrderServiceTests
{
    [Fact]
    public void TestAddOrder()
    {
        OrderService service = new OrderService();
        Order order = new Order("001", "Alice");
        service.AddOrder(order);

        Assert.Contains(order, service.GetAllOrders());
    }

    [Fact]
    public void TestRemoveOrder()
    {
        OrderService service = new OrderService();
        Order order = new Order("001", "Alice");
        service.AddOrder(order);
        service.RemoveOrder("001");

        Assert.DoesNotContain(order, service.GetAllOrders());
    }

    [Fact]
    public void TestUpdateOrder()
    {
        OrderService service = new OrderService();
        Order order = new Order("001", "Alice");
        service.AddOrder(order);

        Order updatedOrder = new Order("001", "Bob");
        service.UpdateOrder(updatedOrder);

        Assert.Equal("Bob", service.GetAllOrders().FirstOrDefault(o => o.OrderId == "001").Customer);
    }

    [Fact]
    public void TestQueryOrders()
    {
        OrderService service = new OrderService();
        Order order1 = new Order("001", "Alice");
        Order order2 = new Order("002", "Bob");
        service.AddOrder(order1);
        service.AddOrder(order2);

        var result = service.QueryOrders(o => o.Customer == "Alice");
        Assert.Single(result);
        Assert.Contains(order1, result);
    }

    [Fact]
    public void TestSortOrders()
    {
        OrderService service = new OrderService();
        Order order1 = new Order("001", "Alice");
        Order order2 = new Order("002", "Bob");
        order1.AddDetails(new OrderDetails("Apple", 1.2m, 10));
        order2.AddDetails(new OrderDetails("Milk", 2.5m, 5));
        service.AddOrder(order1);
        service.AddOrder(order2);

        var sortedOrders = service.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
        Assert.Equal(order2, sortedOrders.First());
    }
}
