using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Product;

/// <summary>
/// Entity for Vehicle Models - مدل‌های خودرو
/// </summary>
[Table("product_models")]
public class Model
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Code { get; set; }

    [Required]
    public Guid BrandId { get; set; }

    [ForeignKey("BrandId")]
    public virtual Brand Brand { get; set; } = null!;

    [Required]
    public Guid CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; } = null!;

    [MaxLength(20)]
    public string? YearRange { get; set; } // مثال: 2020-2024

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(200)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    // Navigation properties
    public virtual ICollection<Trim> Trims { get; set; } = new List<Trim>();
}
