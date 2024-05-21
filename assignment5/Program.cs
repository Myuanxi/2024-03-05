using System;

public class Program
{
    public static void Main(string[] args)
    {
        OrderService orderService = new OrderService();

        try
        {
            Order order1 = new Order("001", "Alice");
            order1.AddDetails(new OrderDetails("Apple", 1.2m, 10));
            order1.AddDetails(new OrderDetails("Banana", 0.5m, 20));
            orderService.AddOrder(order1);

            Order order2 = new Order("002", "Bob");
            order2.AddDetails(new OrderDetails("Milk", 2.5m, 5));
            order2.AddDetails(new OrderDetails("Bread", 1.5m, 10));
            orderService.AddOrder(order2);

            // Query orders
            var queriedOrders = orderService.QueryOrders(o => o.Customer == "Alice");
            queriedOrders.ForEach(o => Console.WriteLine(o));

            // Update order
            Order updatedOrder = new Order("001", "Alice");
            updatedOrder.AddDetails(new OrderDetails("Apple", 1.2m, 15));
            updatedOrder.AddDetails(new OrderDetails("Banana", 0.5m, 25));
            orderService.UpdateOrder(updatedOrder);

            // Remove order
            orderService.RemoveOrder("002");

            // Sort orders by custom criteria
            var sortedOrders = orderService.SortOrders((o1, o2) => o2.TotalAmount.CompareTo(o1.TotalAmount));
            sortedOrders.ForEach(o => Console.WriteLine(o));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}