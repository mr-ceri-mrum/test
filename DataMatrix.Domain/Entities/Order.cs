using System.ComponentModel.DataAnnotations;
using DataMatrix.Domain.Enums;

namespace DataMatrix.Domain.Entities;

public class Order : BaseEntity<Guid>
{
    /// <summary>
    /// prise of the order
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// status of the order
    /// </summary>
    [Range(1, 5)] 
    public int StatusId { get; set; } = (int)OrderStatus.Expected;
    /// <summary>
    /// Discount of the order 
    /// </summary>
    public decimal? Discount { get; set; }
    /// <summary>
    /// Descriptions
    /// </summary>
    [MaxLength(500)]
    public required string Descriptions { get; set; }
}