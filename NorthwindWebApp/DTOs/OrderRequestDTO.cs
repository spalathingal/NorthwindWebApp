namespace NorthwindWebApp.DTOs;
public class OrderRequestDTO
{
    public CustomerDTO Customer { get; set; }
    public List<int> ProductIDs { get; set; }
    public OrderDTO Order { get; set; }
}