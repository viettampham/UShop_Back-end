using System;
using beSS.Models.RequestModels;
using beSS.Services;
using Microsoft.AspNetCore.Mvc;

namespace beSS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderControlle:ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderControlle(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get-order")]
        public IActionResult GetOrder()
        {
            var listOrder = _orderService.GetOrder();
            return Ok(listOrder);
        }
        
        [HttpGet("get-order-by-user/{id}")]
        public IActionResult GetOrderByUser(Guid id)
        {
            var listOrder = _orderService.GetOrderByUser(id);
            return Ok(listOrder);
        }

        [HttpPost("add-order")]
        public IActionResult CreateOrder(CreateOrder request)
        {
            var newOrder = _orderService.CreateOrder(request);
            return Ok(newOrder);
        }

        [HttpDelete("delete-order/{id}")]
        public IActionResult DeleteOrder(Guid id)
        {
            var targetOrder = _orderService.DeleteOrder(id);
            return Ok(targetOrder);
        }

    }
}