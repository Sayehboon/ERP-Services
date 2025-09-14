using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Inventories;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// سفارش خرید
/// Purchase Order
/// </summary>
public class PoOrder : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره سفارش
    /// Order Number
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سفارش
    /// Order Date
    /// </summary>
    public DateTime OrderDate { get; set; }

    /// <summary>
    /// شناسه تامین کننده
    /// Vendor ID
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// نوع سفارش
    /// Order Type
    /// </summary>
    public string OrderType { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت سفارش
    /// Order Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// شرح سفارش
    /// Order Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// مرجع
    /// Reference
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// Created By User ID
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approved By User ID
    /// </summary>
    public Guid? ApprovedByUserId { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// تاریخ مورد انتظار تحویل
    /// Expected Delivery Date
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; set; }

    /// <summary>
    /// تاریخ تحویل واقعی
    /// Actual Delivery Date
    /// </summary>
    public DateTime? ActualDeliveryDate { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// Project ID
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// شناسه مرکز هزینه
    /// Cost Center ID
    /// </summary>
    public Guid? CostCenterId { get; set; }

    /// <summary>
    /// مجموع سفارش
    /// Order Total
    /// </summary>
    public decimal OrderTotal { get; set; } = 0;

    /// <summary>
    /// مجموع مالیات
    /// Tax Total
    /// </summary>
    public decimal TaxTotal { get; set; } = 0;

    /// <summary>
    /// مجموع کل
    /// Grand Total
    /// </summary>
    public decimal GrandTotal { get; set; } = 0;

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange Rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مجموع سفارش به ارز اصلی
    /// Order Total in Base Currency
    /// </summary>
    public decimal OrderTotalBase { get; set; } = 0;

    /// <summary>
    /// مجموع مالیات به ارز اصلی
    /// Tax Total in Base Currency
    /// </summary>
    public decimal TaxTotalBase { get; set; } = 0;

    /// <summary>
    /// مجموع کل به ارز اصلی
    /// Grand Total in Base Currency
    /// </summary>
    public decimal GrandTotalBase { get; set; } = 0;

    /// <summary>
    /// توضیحات اضافی
    /// Additional Notes
    /// </summary>
    public string AdditionalNotes { get; set; }

    // Navigation Properties
    /// <summary>
    /// تامین کننده
    /// Vendor
    /// </summary>
    public virtual Vendor? Vendor { get; set; }

    /// <summary>
    /// انبار
    /// Warehouse
    /// </summary>
    public virtual Warehouse? Warehouse { get; set; }

    /// <summary>
    /// کاربر ایجاد کننده
    /// Created By User
    /// </summary>
    public virtual User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }

    /// <summary>
    /// بخش
    /// Department
    /// </summary>
    public virtual Department? Department { get; set; }

    /// <summary>
    /// پروژه
    /// Project
    /// </summary>
    public virtual Project? Project { get; set; }

    /// <summary>
    /// سطرهای سفارش
    /// Order Lines
    /// </summary>
    public virtual ICollection<PoOrderLine> OrderLines { get; set; } = new List<PoOrderLine>();
}

/// <summary>
/// پیکربندی موجودیت سفارش خرید
/// Purchase Order entity configuration
/// </summary>
public class PoOrderConfiguration : IEntityTypeConfiguration<PoOrder>
{
    public void Configure(EntityTypeBuilder<PoOrder> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderNumber).HasMaxLength(100);
        builder.Property(e => e.OrderType).HasMaxLength(50);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Reference).HasMaxLength(200);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.AdditionalNotes).HasMaxLength(2000);

        builder.Property(e => e.OrderTotal).HasPrecision(18, 2);
        builder.Property(e => e.TaxTotal).HasPrecision(18, 2);
        builder.Property(e => e.GrandTotal).HasPrecision(18, 2);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.OrderTotalBase).HasPrecision(18, 2);
        builder.Property(e => e.TaxTotalBase).HasPrecision(18, 2);
        builder.Property(e => e.GrandTotalBase).HasPrecision(18, 2);

        builder.HasIndex(e => e.OrderNumber).IsUnique(false);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}
