namespace NorthwindWebApp.Models
{
    // Category model
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; } // Assuming Image maps to byte array
    }
}
