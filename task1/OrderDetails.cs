using System;

namespace task1 {
    public class OrderDetails
    {
        public Goods Item { get; }
        public int Quantity { get; }

        public OrderDetails(Goods item, int quantity)
        {
            Item = item ?? throw new ArgumentNullException(nameof(item), "Item cannot be null.");
            Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        }
    }
}