using System.Collections.Generic;
using System.Linq;

namespace OrderManagementAPI.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public string Customer { get; set; }
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public decimal TotalAmount => OrderDetails.Sum(od => od.Amount);
    }
}
