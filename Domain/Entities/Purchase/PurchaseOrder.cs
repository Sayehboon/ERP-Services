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
    /// شماره سفارش (نام مستعار)
    /// Order number (alias)
    /// </summary>
    public string Number => OrderNumber;

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
    public string Type { get; set; }

    /// <summary>
    /// نوع سفارش (نام مستعار)
    /// Order type (alias)
    /// </summary>
    public string OrderType => Type;

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
    public string Description { get; set; }

    /// <summary>
    /// یادداشت‌های سفارش
    /// Order notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
    public Guid? CreatedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده (نام مستعار)
    /// Created by user ID (alias)
    /// </summary>
    public Guid? CreatedById => CreatedByUserId;

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول (نام مستعار)
    /// Assigned to user ID (alias)
    /// </summary>
    public Guid? AssignedToId => AssignedTo;

    /// <summary>
    /// ایمیل تامین‌کننده
    /// Vendor email
    /// </summary>
    public string VendorEmail { get; set; }

    /// <summary>
    /// تلفن تامین‌کننده
    /// Vendor phone
    /// </summary>
    public string VendorPhone { get; set; }

    /// <summary>
    /// اولویت سفارش
    /// Order priority
    /// </summary>
    public string Priority { get; set; }

    /// <summary>
    /// درخواست‌کننده
    /// Requested by
    /// </summary>
    public string RequestedBy { get; set; }

    /// <summary>
    /// آدرس تحویل
    /// Delivery address
    /// </summary>
    public string DeliveryAddress { get; set; }

    /// <summary>
    /// شرایط پرداخت
    /// Payment terms
    /// </summary>
    public string PaymentTerms { get; set; }

    /// <summary>
    /// نرخ تبدیل ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ کل به ارز پایه
    /// Total amount in base currency
    /// </summary>
    public decimal TotalAmountInBaseCurrency { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// انبار مرتبط
    /// Related warehouse
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Inventories.Warehouse? Warehouse { get; set; }

    /// <summary>
    /// یادداشت‌های داخلی
    /// Internal notes
    /// </summary>
    public string InternalNotes { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// Created by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? CreatedByUser { get; set; }

    /// <summary>
    /// شناسه کاربر تاییدکننده
    /// Approved by user ID
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// کاربر تاییدکننده
    /// Approved by user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? ApprovedByUser { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// Approval date
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سفارش
    /// Order active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// نام تامین‌کننده
    /// Vendor name
    /// </summary>
    public string VendorName { get; set; }

    /// <summary>
    /// روش پرداخت
    /// Payment method
    /// </summary>
    public string PaymentMethod { get; set; }

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
        builder.Property(e => e.VendorEmail).HasMaxLength(100);
        builder.Property(e => e.VendorPhone).HasMaxLength(20);
        builder.Property(e => e.Priority).HasMaxLength(20);
        builder.Property(e => e.RequestedBy).HasMaxLength(100);
        builder.Property(e => e.DeliveryAddress).HasMaxLength(500);
        builder.Property(e => e.PaymentTerms).HasMaxLength(200);

        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);
        builder.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
        builder.Property(e => e.DiscountAmount).HasPrecision(18, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.FinalAmount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.TotalAmountInBaseCurrency).HasPrecision(18, 2);

        builder.HasIndex(e => e.OrderNumber).IsUnique(false);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}
