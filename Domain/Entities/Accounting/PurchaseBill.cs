namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت صورتحساب خرید
/// Purchase bill entity
/// </summary>
public class PurchaseBill : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره صورتحساب
    /// Bill number
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// تاریخ صورتحساب
    /// Bill date
    /// </summary>
    public DateTime BillDate { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor Id
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// توضیحات
    /// Notes
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// اقلام صورتحساب
    /// Bill lines
    /// </summary>
    public ICollection<PurchaseBillLine> LineItems { get; set; } = new List<PurchaseBillLine>();

    /// <summary>
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public Vendor? Vendor { get; set; }
}

/// <summary>
/// ردیف صورتحساب خرید
/// Purchase bill line item
/// </summary>
public class PurchaseBillLine : BaseEntity
{
    public Guid PurchaseBillId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineDiscount { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public string Description { get; set; }
    public decimal LineTotal { get; set; }

    /// <summary>
    /// صورتحساب مرتبط
    /// Related bill
    /// </summary>
    public PurchaseBill? PurchaseBill { get; set; }

    /// <summary>
    /// حساب مرتبط
    /// Related account
    /// </summary>
    public Account? Account { get; set; }
}

/// <summary>
/// پیکربندی موجودیت صورتحساب خرید
/// Purchase Bill entity configuration
/// </summary>
public class PurchaseBillConfiguration : IEntityTypeConfiguration<PurchaseBill>
{
    public void Configure(EntityTypeBuilder<PurchaseBill> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Number).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Notes).HasMaxLength(1000);

        builder.HasOne(e => e.Vendor)
            .WithMany(v => v.PurchaseBills)
            .HasForeignKey(e => e.VendorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Number).IsUnique(false);
        builder.HasIndex(e => e.BillDate);
        builder.HasIndex(e => e.VendorId);
        builder.HasIndex(e => e.Status);
    }
}

/// <summary>
/// پیکربندی موجودیت ردیف صورتحساب خرید
/// Purchase Bill Line entity configuration
/// </summary>
public class PurchaseBillLineConfiguration : IEntityTypeConfiguration<PurchaseBillLine>
{
    public void Configure(EntityTypeBuilder<PurchaseBillLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.Property(e => e.Quantity).HasPrecision(18, 4);
        builder.Property(e => e.UnitPrice).HasPrecision(18, 2);
        builder.Property(e => e.LineDiscount).HasPrecision(18, 2);
        builder.Property(e => e.TaxRate).HasPrecision(5, 2);
        builder.Property(e => e.TaxAmount).HasPrecision(18, 2);
        builder.Property(e => e.LineTotal).HasPrecision(18, 2);

        builder.HasOne(e => e.PurchaseBill)
            .WithMany(pb => pb.LineItems)
            .HasForeignKey(e => e.PurchaseBillId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.PurchaseBillId);
        builder.HasIndex(e => e.AccountId);
    }
}

