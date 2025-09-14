using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Sales;

/// <summary>
/// موجودیت سفارش فروش
/// Sales Order entity
/// </summary>
public class SalesOrder : BaseEntity
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
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

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
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// ایمیل مشتری
    /// Customer email
    /// </summary>
    public string CustomerEmail { get; set; }

    /// <summary>
    /// تلفن مشتری
    /// Customer phone
    /// </summary>
    public string CustomerPhone { get; set; }

    /// <summary>
    /// اولویت سفارش
    /// Order priority
    /// </summary>
    public string Priority { get; set; }

    /// <summary>
    /// فروشنده
    /// Sales person
    /// </summary>
    public string SalesPerson { get; set; }

    /// <summary>
    /// تاریخ تحویل
    /// Delivery date
    /// </summary>
    public DateTime? DeliveryDate { get; set; }

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
    /// نرخ تبدیل ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// روش پرداخت
    /// Payment method
    /// </summary>
    public string PaymentMethod { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سفارش
    /// Order active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid OpportunityId { get; set; }

    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Accounting.Customer? Customer { get; set; }

    /// <summary>
    /// فرصت فروش مرتبط
    /// Related opportunity
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Crm.Opportunity? Opportunity { get; set; }

    /// <summary>
    /// آیتم‌های سفارش
    /// Order items
    /// </summary>
    public ICollection<SalesOrderItem> Items { get; set; } = new List<SalesOrderItem>();

    /// <summary>
    /// پرداخت‌های سفارش
    /// Order payments
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Accounting.SalePayment> Payments { get; set; } = new List<Dinawin.Erp.Domain.Entities.Accounting.SalePayment>();

    public Guid SalesPersonId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سفارش فروش
/// Sales Order entity configuration
/// </summary>
public class SalesOrderConfiguration : IEntityTypeConfiguration<SalesOrder>
{
    public void Configure(EntityTypeBuilder<SalesOrder> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderNumber).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Type).HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Notes).HasMaxLength(2000);
        builder.Property(e => e.CustomerName).HasMaxLength(200);
        builder.Property(e => e.CustomerEmail).HasMaxLength(100);
        builder.Property(e => e.CustomerPhone).HasMaxLength(20);
        builder.Property(e => e.Priority).HasMaxLength(20);
        builder.Property(e => e.SalesPerson).HasMaxLength(100);
        builder.Property(e => e.DeliveryAddress).HasMaxLength(500);
        builder.Property(e => e.PaymentTerms).HasMaxLength(200);

        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);
        builder.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
        builder.Property(e => e.DiscountAmount).HasPrecision(18, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.FinalAmount).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);

        builder.HasIndex(e => e.OrderNumber).IsUnique(false);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.Status);
    }
}
