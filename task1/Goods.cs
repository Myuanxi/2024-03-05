using System;

namespace task1 {
    public class Goods
    {
        public string Name { get; }
        public decimal Price { get; }

        public Goods(string name, decimal price)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
            Price = price >= 0 ? price : throw new ArgumentException("Price cannot be negative.", nameof(price));
        }
    }
}