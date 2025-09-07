using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Product;

/// <summary>
/// Entity for Vehicle Trims - تیپ‌ها و مشخصات خودرو
/// </summary>
[Table("product_trims")]
public class Trim
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Code { get; set; }

    [Required]
    public Guid ModelId { get; set; }

    [ForeignKey("ModelId")]
    public virtual Model Model { get; set; } = null!;

    [MaxLength(50)]
    public string? Engine { get; set; } // مثال: 2.5L

    [MaxLength(50)]
    public string? Transmission { get; set; } // مثال: اتوماتیک، دستی

    [MaxLength(50)]
    public string? Drivetrain { get; set; } // مثال: جلو، عقب، چهارچرخ

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(200)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    // Navigation properties
    public virtual ICollection<Year> Years { get; set; } = new List<Year>();
}
