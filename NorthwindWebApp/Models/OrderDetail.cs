namespace NorthwindWebApp.Models
{
    // OrderDetail model
    public class OrderDetail
    {
        // foreign key for order
        public int OrderId { get; set; }
        public Order Order { get; set; }

        // foreign key for product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}
