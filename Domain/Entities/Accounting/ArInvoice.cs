using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// فاکتور حساب‌های دریافتنی
/// Accounts Receivable Invoice
/// </summary>
public class ArInvoice : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// شماره فاکتور
    /// Invoice number
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// تاریخ فاکتور
    /// Invoice date
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// تاریخ سررسید
    /// Due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ خالص
    /// Subtotal
    /// </summary>
    public decimal Subtotal { get; set; } = 0;

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ تخفیف
    /// Discount amount
    /// </summary>
    public decimal DiscountAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal Total { get; set; } = 0;

    /// <summary>
    /// وضعیت فاکتور
    /// Invoice status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// وضعیت تایید
    /// Approval status
    /// </summary>
    public string ApprovalStatus { get; set; } = "draft";

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal period ID
    /// </summary>
    public Guid? FiscalPeriodId { get; set; }

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal year ID
    /// </summary>
    public Guid? FiscalYearId { get; set; }

    /// <summary>
    /// پست شده؟
    /// Is posted?
    /// </summary>
    public bool Posted { get; set; } = false;

    /// <summary>
    /// تاریخ پست
    /// Posted at
    /// </summary>
    public DateTime? PostedAt { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public ArCustomer Customer { get; set; } = null!;

    /// <summary>
    /// خطوط فاکتور
    /// Invoice lines
    /// </summary>
    public ICollection<ArInvoiceLine> Lines { get; set; } = new List<ArInvoiceLine>();

    /// <summary>
    /// تسویه‌های فاکتور
    /// Invoice settlements
    /// </summary>
    public ICollection<ArSettlement> Settlements { get; set; } = new List<ArSettlement>();

    /// <summary>
    /// دوره مالی
    /// Fiscal period
    /// </summary>
    public FiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// سال مالی
    /// Fiscal year
    /// </summary>
    public FiscalYear? FiscalYear { get; set; }
}

/// <summary>
/// پیکربندی موجودیت فاکتور حساب‌های دریافتنی
/// Accounts Receivable Invoice entity configuration
/// </summary>
public class ArInvoiceConfiguration : IEntityTypeConfiguration<ArInvoice>
{
    public void Configure(EntityTypeBuilder<ArInvoice> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.ApprovalStatus).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);
        builder.Property(e => e.Subtotal).HasPrecision(18, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.DiscountAmount).HasPrecision(18, 2);
        builder.Property(e => e.Total).HasPrecision(18, 2);

        builder.HasOne(e => e.Customer)
            .WithMany(c => c.Invoices)
            .HasForeignKey(e => e.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.FiscalYear)
            .WithMany()
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.InvoiceDate);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.CustomerId);
    }
}
