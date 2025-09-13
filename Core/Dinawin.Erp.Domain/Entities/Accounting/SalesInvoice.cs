namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت فاکتور فروش
/// Sales invoice entity
/// </summary>
public class SalesInvoice : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره فاکتور
    /// Invoice number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// تاریخ فاکتور
    /// Invoice date
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer Id
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// شناسه سفارش فروش
    /// Sales order ID
    /// </summary>
    public Guid? SalesOrderId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// توضیحات
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// ردیف‌های فاکتور
    /// Invoice line items
    /// </summary>
    public ICollection<SalesInvoiceLine> LineItems { get; set; } = new List<SalesInvoiceLine>();
}

/// <summary>
/// ردیف فاکتور فروش
/// Sales invoice line item
/// </summary>
public class SalesInvoiceLine : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice Id
    /// </summary>
    public Guid SalesInvoiceId { get; set; }

    /// <summary>
    /// شناسه حساب درآمد/فروش
    /// Revenue account Id
    /// </summary>
    public Guid AccountId { get; set; }

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
    /// تخفیف خط
    /// Line discount
    /// </summary>
    public decimal LineDiscount { get; set; }

    /// <summary>
    /// نرخ مالیات
    /// Tax rate (%)
    /// </summary>
    public decimal TaxRate { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// شرح سطر
    /// Line description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// جمع خط
    /// Line total
    /// </summary>
    public decimal LineTotal { get; set; }

    public SalesInvoice SalesInvoice { get; set; }
}

/// <summary>
/// پیکربندی موجودیت فاکتور فروش
/// Sales Invoice entity configuration
/// </summary>
public class SalesInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
{
    public void Configure(EntityTypeBuilder<SalesInvoice> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Notes).HasMaxLength(1000);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.InvoiceDate);
        builder.HasIndex(e => e.CustomerId);
        builder.HasIndex(e => e.Status);
    }
}

/// <summary>
/// پیکربندی موجودیت ردیف فاکتور فروش
/// Sales Invoice Line entity configuration
/// </summary>
public class SalesInvoiceLineConfiguration : IEntityTypeConfiguration<SalesInvoiceLine>
{
    public void Configure(EntityTypeBuilder<SalesInvoiceLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.LineDiscount).HasPrecision(18, 2);
        builder.Property(e => e.TaxRate).HasPrecision(5, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.LineTotal).HasPrecision(18, 2);

        builder.HasOne(e => e.SalesInvoice)
            .WithMany(si => si.LineItems)
            .HasForeignKey(e => e.SalesInvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.SalesInvoiceId);
        builder.HasIndex(e => e.AccountId);
    }
}

