using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindWebApp.DTOs;
using NorthwindWebApp.Services;

namespace NorthwindWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly ILogger<OrdersController> _logger; // Add logger field

        public OrdersController(OrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        // POST: api/orders
        [HttpPost]
        public IActionResult PostOrder(OrderRequestDTO orderRequest)
        {
            try
            {
                var response = _orderService.CreateOrder(orderRequest);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception details including the stack trace
                _logger.LogError(ex, "An error occurred while processing the request.");

                // Return a generic error message to the client
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
}
