namespace NorthwindWebApp.DTOs;
public class OrderResponseDTO
{
    public string Message { get; set; }
    public string CustomerId { get; set; }
    public int OrderId { get; set; }
    public List<int> ProductIds { get; set; }
}
