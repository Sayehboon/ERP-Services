using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// موجودیت آیتم سفارش خرید
/// Purchase Order Item entity
/// </summary>
public class PurchaseOrderItem : BaseEntity
{
    /// <summary>
    /// شناسه سفارش خرید
    /// Purchase order ID
    /// </summary>
    public Guid PurchaseOrderId { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// تعداد
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

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
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// نام محصول
    /// Product name
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// کد محصول
    /// Product code
    /// </summary>
    public string ProductCode { get; set; }

    /// <summary>
    /// توضیحات آیتم
    /// Item description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// یادداشت‌های آیتم
    /// Item notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// شناسه واحد اندازه‌گیری
    /// Unit of measure ID
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Products.Product? Product { get; set; }

    /// <summary>
    /// واحد اندازه‌گیری مرتبط
    /// Related unit of measure
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Products.UnitOfMeasure? Uom { get; set; }
}

/// <summary>
/// پیکربندی موجودیت آیتم سفارش خرید
/// Purchase Order Item entity configuration
/// </summary>
public class PurchaseOrderItemConfiguration : IEntityTypeConfiguration<PurchaseOrderItem>
{
    public void Configure(EntityTypeBuilder<PurchaseOrderItem> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
        builder.Property(e => e.DiscountAmount).HasPrecision(18, 2);
        builder.Property(e => e.TotalAmount).HasPrecision(18, 2);
        builder.Property(e => e.ProductName).HasMaxLength(200);
        builder.Property(e => e.ProductCode).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.HasIndex(e => e.PurchaseOrderId);
        builder.HasIndex(e => e.ProductId);
    }
}
