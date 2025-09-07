using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Purchase;

/// <summary>
/// Entity for Purchase Orders - سفارشات خرید
/// </summary>
[Table("purchase_orders")]
public class PurchaseOrder
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string VendorName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? VendorEmail { get; set; }

    [MaxLength(20)]
    public string? VendorPhone { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    public DateTime? DeliveryDate { get; set; }

    public decimal TotalAmount { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "draft"; // draft، sent، confirmed، received، completed، cancelled

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(100)]
    public string? PaymentTerms { get; set; }

    [MaxLength(500)]
    public string? DeliveryAddress { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();
}
