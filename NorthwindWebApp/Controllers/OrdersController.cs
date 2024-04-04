using Microsoft.AspNetCore.Mvc;
using NorthwindWebApp.DTOs;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindDbContext _context;

        public OrdersController(NorthwindDbContext context)
        {
            _context = context;
        }

        // POST: api/orders
        [HttpPost]
        public IActionResult PostOrder(OrderRequestDTO orderRequest)
        {
            // Input validation
            if (orderRequest == null || orderRequest.Customer == null || orderRequest.ProductIDs == null || orderRequest.ProductIDs.Count == 0)
            {
                return BadRequest("Invalid order request");
            }

            try
            {
                // If any part of the process fails, the transaction will be rolled back.
                using (var transaction = _context.Database.BeginTransaction())
                {
                    // Create Customer entity
                    var customer = new Customer
                    {
                        CompanyName = orderRequest.Customer.CompanyName,
                        ContactName = orderRequest.Customer.ContactName,
                        ContactTitle = orderRequest.Customer.ContactTitle,
                        Address = orderRequest.Customer.Address,
                        City = orderRequest.Customer.City,
                        Region = orderRequest.Customer.Region,
                        PostalCode = orderRequest.Customer.PostalCode,
                        Country = orderRequest.Customer.Country,
                        Phone = orderRequest.Customer.Phone,
                        Fax = orderRequest.Customer.Fax
                    };

                    _context.Customers.Add(customer);
                    _context.SaveChanges();  // Save customer first to generate CustomerId

                    // Create Order entity
                    var order = new Order
                    {
                        CustomerId = customer.CustomerId,  // Use generated CustomerId
                        EmployeeId = orderRequest.EmployeeId,
                        OrderDate = orderRequest.OrderDate,
                        RequiredDate = orderRequest.RequiredDate,
                        ShippedDate = orderRequest.ShippedDate,
                        ShipVia = orderRequest.ShipVia,
                        Freight = orderRequest.Freight,
                        ShipName = orderRequest.ShipName,
                        ShipAddress = orderRequest.ShipAddress,
                        ShipCity = orderRequest.ShipCity,
                        ShipRegion = orderRequest.ShipRegion,
                        ShipPostalCode = orderRequest.ShipPostalCode,
                        ShipCountry = orderRequest.ShipCountry
                    };

                    _context.Orders.Add(order);
                    _context.SaveChanges();  // Save order first to generate OrderId

                    // Create order details for each ordered product ID
                    foreach (var productId in orderRequest.ProductIDs)
                    {
                        var product = _context.Products.Find(productId);
                        if (product != null)
                        {
                            var orderDetail = new OrderDetail
                            {
                                OrderId = order.OrderId,
                                ProductId = product.ProductId,
                                UnitPrice = product.UnitPrice,
                                Quantity = orderRequest.Quantity,
                                Discount = 0 // Assuming no discount is applied for now
                            };
                            _context.OrderDetails.Add(orderDetail);
                        }
                        // product id not found
                        else
                        {
                            return BadRequest("Product ID not found");
                        }
                    }

                    _context.SaveChanges();

                    transaction.Commit();  // Commit transaction if all operations succeed

                    return Ok("Order successfully created");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

    }
}
