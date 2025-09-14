using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تامین‌کننده حساب‌های پرداختنی
/// Accounts Payable Vendor
/// </summary>
public class ApVendor : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// کد تامین‌کننده
    /// Vendor code
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// نام تامین‌کننده
    /// Vendor name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مالیاتی
    /// Tax ID
    /// </summary>
    public string TaxId { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    // Navigation Properties
    /// <summary>
    /// فاکتورهای تامین‌کننده
    /// Vendor bills
    /// </summary>
    public ICollection<ApBill> Bills { get; set; } = new List<ApBill>();

    /// <summary>
    /// پرداخت‌های تامین‌کننده
    /// Vendor payments
    /// </summary>
    public ICollection<ApPayment> Payments { get; set; } = new List<ApPayment>();
}

/// <summary>
/// پیکربندی موجودیت تامین‌کننده حساب‌های پرداختنی
/// Accounts Payable Vendor entity configuration
/// </summary>
public class ApVendorConfiguration : IEntityTypeConfiguration<ApVendor>
{
    public void Configure(EntityTypeBuilder<ApVendor> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).HasMaxLength(50);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.TaxId).HasMaxLength(50);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.BusinessId);
    }
}
