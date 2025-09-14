using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// موجودیت سفارش مشتری
/// Customer Order entity
/// </summary>
public class CustomerOrder : BaseEntity
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
    /// توضیحات سفارش
    /// Order description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user ID
    /// </summary>
}

/// <summary>
/// پیکربندی موجودیت سفارش مشتری
/// Customer Order entity configuration
/// </summary>
public class CustomerOrderConfiguration : IEntityTypeConfiguration<CustomerOrder>
{
    public void Configure(EntityTypeBuilder<CustomerOrder> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Status).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);

        builder.HasIndex(e => e.OrderNumber).IsUnique(false);
        builder.HasIndex(e => e.OrderDate);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.Status);
    }
}
