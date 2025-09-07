using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Product;

/// <summary>
/// Entity for Vehicle Years - سال‌های تولید خودرو
/// </summary>
[Table("product_years")]
public class Year
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string YearValue { get; set; } = string.Empty; // مثال: 2024

    [Required]
    public Guid TrimId { get; set; }

    [ForeignKey("TrimId")]
    public virtual Trim Trim { get; set; } = null!;

    [MaxLength(1000)]
    public string? Changes { get; set; } // تغییرات این سال

    [MaxLength(50)]
    public string? EpcCode { get; set; } // کد EPC

    public bool HasEpc { get; set; } = false;

    [MaxLength(200)]
    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }
}
