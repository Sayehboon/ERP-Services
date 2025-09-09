using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// خط فاکتور حساب‌های دریافتنی
/// Accounts Receivable Invoice Line
/// </summary>
public class ArInvoiceLine : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice ID
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// شماره خط
    /// Line number
    /// </summary>
    public int LineNo { get; set; }

    /// <summary>
    /// شناسه محصول
    /// Product ID
    /// </summary>
    public Guid? ProductId { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// تعداد
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; } = 0;

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; } = 0;

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; } = 0;

    /// <summary>
    /// نرخ مالیات
    /// Tax rate
    /// </summary>
    public decimal? TaxRate { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; } = 0;

    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    // Navigation Properties
    /// <summary>
    /// فاکتور مرتبط
    /// Related invoice
    /// </summary>
    public ArInvoice Invoice { get; set; } = null!;

    /// <summary>
    /// محصول مرتبط
    /// Related product
    /// </summary>
    public Products.Product? Product { get; set; }

    /// <summary>
    /// حساب مرتبط
    /// Related account
    /// </summary>
    public Account Account { get; set; } = null!;
}

/// <summary>
/// پیکربندی موجودیت خط فاکتور حساب‌های دریافتنی
/// Accounts Receivable Invoice Line entity configuration
/// </summary>
public class ArInvoiceLineConfiguration : IEntityTypeConfiguration<ArInvoiceLine>
{
    public void Configure(EntityTypeBuilder<ArInvoiceLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Quantity).HasColumnType("decimal(18,4)");
        builder.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
        builder.Property(e => e.Amount).HasColumnType("decimal(18,2)");
        builder.Property(e => e.TaxRate).HasColumnType("decimal(5,2)");
        builder.Property(e => e.TaxAmount).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Invoice)
            .WithMany(i => i.Lines)
            .HasForeignKey(e => e.InvoiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Product)
            .WithMany()
            .HasForeignKey(e => e.ProductId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.InvoiceId);
        builder.HasIndex(e => e.LineNo);
    }
}
