using Microsoft.AspNetCore.Mvc;
using NorthwindWebApp.Context;
using NorthwindWebApp.DTOs;
using NorthwindWebApp.Models;

namespace NorthwindWebApp.Services;

// Implement the service
public class OrderService
{
    private readonly NorthwindDbContext _context;

    public OrderService(NorthwindDbContext context)
    {
        _context = context;
    }

    public ObjectResult CreateOrder(OrderRequestDTO orderRequest)
    {
        using (var transaction = _context.Database.BeginTransaction())
        {
            // Create Customer entity
            // Check if a customer with the same details already exists
            var customer = _context.Customers.FirstOrDefault(c =>
                c.CompanyName == orderRequest.Customer.CompanyName &&
                c.ContactName == orderRequest.Customer.ContactName &&
                c.ContactTitle == orderRequest.Customer.ContactTitle &&
                c.Address == orderRequest.Customer.Address &&
                c.City == orderRequest.Customer.City &&
                c.Region == orderRequest.Customer.Region &&
                c.PostalCode == orderRequest.Customer.PostalCode &&
                c.Country == orderRequest.Customer.Country &&
                c.Phone == orderRequest.Customer.Phone &&
                c.Fax == orderRequest.Customer.Fax);

            if (customer == null)
            {
                // Create a new customer only if it doesn't exist
                customer = new Customer
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
            }

            // Create Order entity
            var order = new Order
            {
                CustomerId = customer.CustomerId,  // Use generated CustomerId
                EmployeeId = orderRequest.Order.EmployeeId,
                OrderDate = orderRequest.Order.OrderDate,
                RequiredDate = orderRequest.Order.RequiredDate,
                ShippedDate = orderRequest.Order.ShippedDate,
                ShipVia = orderRequest.Order.ShipVia,
                Freight = orderRequest.Order.Freight,
                ShipName = orderRequest.Order.ShipName,
                ShipAddress = orderRequest.Order.ShipAddress,
                ShipCity = orderRequest.Order.ShipCity,
                ShipRegion = orderRequest.Order.ShipRegion,
                ShipPostalCode = orderRequest.Order.ShipPostalCode,
                ShipCountry = orderRequest.Order.ShipCountry
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
                        Quantity = orderRequest.Order.Quantity,
                        Discount = 0 // Assuming no discount is applied for now
                    };
                    _context.OrderDetails.Add(orderDetail);
                }
                // product id not found
                else
                {
                    transaction.Rollback();  // Roll back transaction if an exception occurs
                    return new ObjectResult("Product ID not found")
                    {
                        StatusCode = 400
                    };
                }
            }

            _context.SaveChanges();

            transaction.Commit();  // Commit transaction if all operations succeed

            // Get the newly created order details
            var customerId = customer.CustomerId;
            var orderId = order.OrderId;
            var productIds = orderRequest.ProductIDs;

            // Create a response object with the additional details
            var response = new OrderResponseDTO
            {
                Message = "Order successfully created",
                CustomerId = customerId,
                OrderId = orderId,
                ProductIds = productIds
            };

            return new OkObjectResult(response); // Return the response object
        }
    }
}