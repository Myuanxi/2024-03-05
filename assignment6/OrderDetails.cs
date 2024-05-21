using System;

namespace OrderManagementSystem
{
    public class OrderDetails
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount => Quantity * Price;

        public OrderDetails(string productName, int quantity, decimal price)
        {
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details && ProductName == details.ProductName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName);
        }

        public override string ToString()
        {
            return $"Product: {ProductName}, Quantity: {Quantity}, Price: {Price:C}, Amount: {Amount:C}";
        }
    }
}
