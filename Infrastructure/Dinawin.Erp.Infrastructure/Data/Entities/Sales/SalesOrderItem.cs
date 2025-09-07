using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Sales;

/// <summary>
/// Entity for Sales Order Items - آیتم‌های سفارش فروش
/// </summary>
[Table("sales_order_items")]
public class SalesOrderItem
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid SalesOrderId { get; set; }

    [ForeignKey("SalesOrderId")]
    public virtual SalesOrder SalesOrder { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? ProductCode { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal TotalAmount { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }
}
