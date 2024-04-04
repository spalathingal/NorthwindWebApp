﻿using NorthwindWebApp.Models;

namespace NorthwindWebApp.DTOs
{
    public class OrderRequestDTO
    {
        // references existing model classes
        public Customer Customer { get; set; }
        public List<int> ProductIDs { get; set; }

        // order fields
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public int Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public int Quantity { get; set; }
    }
}