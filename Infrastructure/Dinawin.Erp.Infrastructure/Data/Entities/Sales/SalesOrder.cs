using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Sales;

/// <summary>
/// Entity for Sales Orders - سفارشات فروش
/// </summary>
[Table("sales_orders")]
public class SalesOrder
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string CustomerName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? CustomerEmail { get; set; }

    [MaxLength(20)]
    public string? CustomerPhone { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public DateTime? DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "تایید شده"; // تایید شده، در حال تولید، آماده ارسال، ارسال شده، تحویل داده شده

    [MaxLength(50)]
    public string Priority { get; set; } = "عادی"; // عادی، بالا، فوری

    [MaxLength(200)]
    public string? SalesPerson { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? DeliveryAddress { get; set; }

    [MaxLength(100)]
    public string? PaymentTerms { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();
}
