using System.ComponentModel.DataAnnotations;

namespace DataMatrix.Domain.Entities;

public class BaseEntity<TKey> 
{
    /// <summary>
    /// Primary key
    /// </summary>
    [Key]
    public TKey Id { get; set; }

    /// <summary>
    /// IsDeleted = false
    /// </summary>
    public bool IsDeleted { get; set; } = false;
    /// <summary>
    /// Created DataTime
    /// </summary>
    public DateTime Created { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Updated DataTime
    /// </summary>
    public DateTime? Updated { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Deleted DataTime
    /// </summary>
    public DateTime? Deleted { get; set; }
}