using System;
using System.Collections.Generic;
using task1;

namespace OrderManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // 创建OrderService实例
            OrderService orderService = new OrderService();

            // 创建客户实例
            Client client1 = new Client("小明");
            Client client2 = new Client("小红");
            Client client3 = new Client("李华");

            // 创建商品实例
            Goods goods1 = new Goods("《数据结构》", 50);
            Goods goods2 = new Goods("iPad", 5000);
            Goods goods3 = new Goods("电路板", 2000);
            Goods goods4 = new Goods("电线", 1500);
            Goods goods5 = new Goods("《算法》", 30);
            Goods goods6 = new Goods("胶卷", 80);

            // 创建订单详情
            List<OrderDetails> details1 = new List<OrderDetails> { new OrderDetails(goods1, 2), new OrderDetails(goods2, 1) };
            List<OrderDetails> details2 = new List<OrderDetails> { new OrderDetails(goods3, 1), new OrderDetails(goods4, 2) };
            List<OrderDetails> details3 = new List<OrderDetails> { new OrderDetails(goods5, 1), new OrderDetails(goods6, 3) };

            // 创建并添加订单
            orderService.AddOrder(new Order(1, client1, details1));
            orderService.AddOrder(new Order(2, client2, details2));
            orderService.AddOrder(new Order(3, client3, details3));

            // 查询并显示订单
            Console.WriteLine("查询Id为2的订单：");
            var order = orderService.QueryId(2);
            if (order != null)
            {
                Console.WriteLine(order);
            }

            // 修改订单
            Console.WriteLine("\n修改Id为3的订单：");
            List<OrderDetails> newDetails = new List<OrderDetails> { new OrderDetails(goods3, 2), new OrderDetails(goods6, 1) };
            if (orderService.ChangeOrder(3, client3, newDetails))
            {
                Console.WriteLine("订单修改成功。");
            }

            // 显示所有订单
            Console.WriteLine("\n所有订单信息：");
            var allOrders = orderService.QueryAll();
            foreach (var o in allOrders)
            {
                Console.WriteLine(o);
            }

            // 删除订单
            Console.WriteLine("\n删除Id为1的订单：");
            if (orderService.DeleteOrder(1))
            {
                Console.WriteLine("订单删除成功。");
            }

            // 显示当前所有订单
            Console.WriteLine("\n当前所有订单信息：");
            allOrders = orderService.QueryAll();
            foreach (var o in allOrders)
            {
                Console.WriteLine(o);
            }

            // 按商品名称查询订单
            Console.WriteLine("\n查询含有《数据结构》的订单：");
            var ordersWithGoods = orderService.QueryName("《数据结构》");
            foreach (var o in ordersWithGoods)
            {
                Console.WriteLine(o);
            }

            // 排序订单
            Console.WriteLine("\n按OrderId排序后的订单：");
            orderService.SortId();
            allOrders = orderService.QueryAll();
            foreach (var o in allOrders)
            {
                Console.WriteLine(o);
            }
        }
    }
}
