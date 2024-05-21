namespace OrderManagementAPI.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public string OrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Amount => Quantity * Price;
    }
}
