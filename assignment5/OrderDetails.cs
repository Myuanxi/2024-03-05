public class OrderDetails
{
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public OrderDetails(string productName, decimal unitPrice, int quantity)
    {
        ProductName = productName;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public override bool Equals(object obj)
    {
        return obj is OrderDetails details &&
               ProductName == details.ProductName &&
               UnitPrice == details.UnitPrice &&
               Quantity == details.Quantity;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(ProductName, UnitPrice, Quantity);
    }

    public override string ToString()
    {
        return $"Product: {ProductName}, Unit Price: {UnitPrice}, Quantity: {Quantity}, Total Price: {TotalPrice}";
    }
}
