using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// موجودیت سفارش خرید
/// Purchase Order entity
/// </summary>
public class PurchaseOrder : BaseEntity
{
    /// <summary>
    /// شماره سفارش
    /// Order number
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سفارش
    /// Order date
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// تاریخ تحویل مورد انتظار
    /// Expected delivery date
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; set; }

    /// <summary>
    /// تاریخ تحویل واقعی
    /// Actual delivery date
    /// </summary>
    public DateTime? ActualDeliveryDate { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor ID
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// وضعیت سفارش
    /// Order status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع سفارش
    /// Order type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// مبلغ کل سفارش
    /// Total order amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// ارز سفارش
    /// Order currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// درصد تخفیف
    /// Discount percentage
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// مبلغ تخفیف
    /// Discount amount
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// مبلغ نهایی
    /// Final amount
    /// </summary>
    public decimal FinalAmount { get; set; }

    /// <summary>
    /// توضیحات سفارش
    /// Order description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های سفارش
    /// Order notes
    /// </summary>
    public string? Notes { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سفارش
    /// Order active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Accounting.Vendor? Vendor { get; set; }

    /// <summary>
    /// آیتم‌های سفارش
    /// Order items
    /// </summary>
    public ICollection<PurchaseOrderItem> Items { get; set; } = new List<PurchaseOrderItem>();

    /// <summary>
    /// پرداخت‌های سفارش
    /// Order payments
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment> Payments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.PurchasePayment>();
}

/// <summary>
/// پیکربندی موجودیت سفارش خرید
/// Purchase Order entity configuration
/// </summary>
public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Type).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.DiscountPercentage).HasColumnType("decimal(5,2)");
        builder.Property(e => e.DiscountAmount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.TaxAmount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.FinalAmount).HasColumnType("decimal(18,2)");

        builder.HasIndex(e => e.OrderNumber).IsUnique(false);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}
