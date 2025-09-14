using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// ابزار مالی (چک، سفته، و غیره)
/// Financial Instrument (Check, Promissory Note, etc.)
/// </summary>
public class Instrument : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// نوع ابزار
    /// Instrument type
    /// </summary>
    public string InstrumentType { get; set; } = string.Empty;

    /// <summary>
    /// شماره ابزار
    /// Instrument number
    /// </summary>
    public string InstrumentNumber { get; set; }

    /// <summary>
    /// تاریخ صدور
    /// Issue date
    /// </summary>
    public DateTime IssueDate { get; set; }

    /// <summary>
    /// تاریخ سررسید
    /// Due date
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// مبلغ
    /// Amount
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// شناسه حساب بانکی
    /// Bank account ID
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// شناسه حساب بدهکار
    /// Debit account ID
    /// </summary>
    public Guid? DebitAccountId { get; set; }

    /// <summary>
    /// شناسه حساب بستانکار
    /// Credit account ID
    /// </summary>
    public Guid? CreditAccountId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "pending";

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// حساب بانکی مرتبط
    /// Related bank account
    /// </summary>
    public BankAccount? BankAccount { get; set; }

    /// <summary>
    /// حساب بدهکار مرتبط
    /// Related debit account
    /// </summary>
    public Accounting.Account? DebitAccount { get; set; }

    /// <summary>
    /// حساب بستانکار مرتبط
    /// Related credit account
    /// </summary>
    public Accounting.Account? CreditAccount { get; set; }

    /// <summary>
    /// جریان‌های ابزار
    /// Instrument flows
    /// </summary>
    public ICollection<InstrumentFlow> Flows { get; set; } = new List<InstrumentFlow>();
}

/// <summary>
/// پیکربندی موجودیت ابزار مالی
/// Financial Instrument entity configuration
/// </summary>
public class InstrumentConfiguration : IEntityTypeConfiguration<Instrument>
{
    public void Configure(EntityTypeBuilder<Instrument> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.InstrumentType).IsRequired().HasMaxLength(50);
        builder.Property(e => e.InstrumentNumber).HasMaxLength(100);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.BankAccount)
            .WithMany()
            .HasForeignKey(e => e.BankAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.DebitAccount)
            .WithMany()
            .HasForeignKey(e => e.DebitAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.CreditAccount)
            .WithMany()
            .HasForeignKey(e => e.CreditAccountId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.InstrumentNumber).IsUnique(false);
        builder.HasIndex(e => e.InstrumentType);
        builder.HasIndex(e => e.IssueDate);
        builder.HasIndex(e => e.DueDate);
        builder.HasIndex(e => e.Status);
    }
}
