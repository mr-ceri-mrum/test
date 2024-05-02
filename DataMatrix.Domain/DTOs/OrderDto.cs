namespace DataMatrix.Domain.DTOs;

public class OrderDto
{
    public string Id { get; set; }
    public decimal Price { get; set; }
    public int StatusId { get; set; }
    public string Descriptions { get; set; }
}

public class CreateOrderDto
{
    public decimal Price { get; set; }
    public string Descriptions { get; set; }
    public decimal? Discount { get; set; }
}