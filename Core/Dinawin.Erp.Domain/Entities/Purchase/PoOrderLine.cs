using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Purchase;

/// <summary>
/// سطر سفارش خرید
/// Purchase Order Line
/// </summary>
public class PoOrderLine : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه سفارش خرید
    /// Purchase Order ID
    /// </summary>
    public Guid PoOrderId { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// تعداد سفارش
    /// Ordered Quantity
    /// </summary>
    public decimal OrderedQuantity { get; set; }

    /// <summary>
    /// تعداد دریافت شده
    /// Received Quantity
    /// </summary>
    public decimal ReceivedQuantity { get; set; }

    /// <summary>
    /// تعداد باقی مانده
    /// Remaining Quantity
    /// </summary>
    public decimal RemainingQuantity { get; set; }

    /// <summary>
    /// واحد اندازه گیری
    /// Unit of Measure
    /// </summary>
    public string UnitOfMeasure { get; set; } = string.Empty;

    /// <summary>
    /// قیمت واحد
    /// Unit Price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// قیمت کل
    /// Total Price
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// درصد تخفیف
    /// Discount Percentage
    /// </summary>
    public decimal DiscountPercentage { get; set; } = 0;

    /// <summary>
    /// مبلغ تخفیف
    /// Discount Amount
    /// </summary>
    public decimal DiscountAmount { get; set; } = 0;

    /// <summary>
    /// قیمت پس از تخفیف
    /// Price After Discount
    /// </summary>
    public decimal PriceAfterDiscount { get; set; }

    /// <summary>
    /// درصد مالیات
    /// Tax Percentage
    /// </summary>
    public decimal TaxPercentage { get; set; } = 0;

    /// <summary>
    /// مبلغ مالیات
    /// Tax Amount
    /// </summary>
    public decimal TaxAmount { get; set; } = 0;

    /// <summary>
    /// قیمت نهایی
    /// Final Price
    /// </summary>
    public decimal FinalPrice { get; set; }

    /// <summary>
    /// شرح سطر
    /// Line Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شماره سطر
    /// Line Number
    /// </summary>
    public int LineNumber { get; set; }

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
    /// قیمت واحد به ارز اصلی
    /// Unit Price in Base Currency
    /// </summary>
    public decimal UnitPriceBase { get; set; }

    /// <summary>
    /// قیمت کل به ارز اصلی
    /// Total Price in Base Currency
    /// </summary>
    public decimal TotalPriceBase { get; set; }

    /// <summary>
    /// مبلغ تخفیف به ارز اصلی
    /// Discount Amount in Base Currency
    /// </summary>
    public decimal DiscountAmountBase { get; set; } = 0;

    /// <summary>
    /// مبلغ مالیات به ارز اصلی
    /// Tax Amount in Base Currency
    /// </summary>
    public decimal TaxAmountBase { get; set; } = 0;

    /// <summary>
    /// قیمت نهایی به ارز اصلی
    /// Final Price in Base Currency
    /// </summary>
    public decimal FinalPriceBase { get; set; }

    /// <summary>
    /// توضیحات اضافی
    /// Additional Notes
    /// </summary>
    public string? AdditionalNotes { get; set; }

    // Navigation Properties
    /// <summary>
    /// سفارش خرید
    /// Purchase Order
    /// </summary>
    public virtual PoOrder? PoOrder { get; set; }

    /// <summary>
    /// محصول
    /// Product
    /// </summary>
    public virtual Product? Product { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سطر سفارش خرید
/// Purchase Order Line entity configuration
/// </summary>
public class PoOrderLineConfiguration : IEntityTypeConfiguration<PoOrderLine>
{
    public void Configure(EntityTypeBuilder<PoOrderLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.OrderedQuantity).HasPrecision(18, 4);
        builder.Property(e => e.ReceivedQuantity).HasPrecision(18, 4);
        builder.Property(e => e.RemainingQuantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitOfMeasure).HasMaxLength(50);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.TotalPrice).HasPrecision(18, 2);
        builder.Property(e => e.DiscountPercentage).HasPrecision(5, 2);
        builder.Property(e => e.DiscountAmount).HasPrecision(18, 2);
        builder.Property(e => e.PriceAfterDiscount).HasPrecision(18, 2);
        builder.Property(e => e.TaxPercentage).HasPrecision(5, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.FinalPrice).HasPrecision(18, 2);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.UnitPriceBase).HasPrecision(18, 2);
        builder.Property(e => e.TotalPriceBase).HasPrecision(18, 2);
        builder.Property(e => e.DiscountAmountBase).HasPrecision(18, 2);
        builder.Property(e => e.TaxAmountBase).HasPrecision(18, 2);
        builder.Property(e => e.FinalPriceBase).HasPrecision(18, 2);
        builder.Property(e => e.AdditionalNotes).HasMaxLength(2000);

        builder.HasIndex(e => e.PoOrderId);
        builder.HasIndex(e => e.ProductId);
    }
}
