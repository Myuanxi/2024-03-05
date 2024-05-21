using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Models;
using OrderManagementAPI.Services;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return _orderService.GetOrdersSortedByDefault();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            var order = _orderService.QueryOrders(o => o.OrderID == id).FirstOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            return order;
        }

        [HttpPost]
        public ActionResult<Order> PostOrder(Order order)
        {
            _orderService.AddOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderID }, order);
        }

        [HttpPut("{id}")]
        public IActionResult PutOrder(string id, Order order)
        {
            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _orderService.UpdateOrder(order);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(string id)
        {
            _orderService.RemoveOrder(id);
            return NoContent();
        }
    }
}
