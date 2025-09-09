using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// تنظیمات حسابداری
/// Accounting Settings
/// </summary>
public class AccSetting : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// واحد پول پیش‌فرض
    /// Default currency
    /// </summary>
    public string DefaultCurrency { get; set; } = "IRR";

    /// <summary>
    /// نرخ مالیات بر ارزش افزوده
    /// VAT rate
    /// </summary>
    public decimal VatRate { get; set; } = 0m;

    /// <summary>
    /// نرخ مالیات تکلیفی
    /// Withholding rate
    /// </summary>
    public decimal WithholdingRate { get; set; } = 0m;

    /// <summary>
    /// کد حساب VAT
    /// VAT account code
    /// </summary>
    public string? VatAccountCode { get; set; }

    /// <summary>
    /// کد حساب مالیات تکلیفی
    /// Withholding account code
    /// </summary>
    public string? WithholdingAccountCode { get; set; }

    /// <summary>
    /// کد حساب سود تسعیر ارز
    /// FX gain account code
    /// </summary>
    public string? FxGainAccountCode { get; set; }

    /// <summary>
    /// کد حساب زیان تسعیر ارز
    /// FX loss account code
    /// </summary>
    public string? FxLossAccountCode { get; set; }

    /// <summary>
    /// شناسه کاربر ایجادکننده
    /// Created by user Id
    /// </summary>
    public Guid? CreatedByUserId { get; set; }

    /// <summary>
    /// کاربر ایجادکننده
    /// Created by user
    /// </summary>
    public virtual Users.User? CreatedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تنظیمات حسابداری
/// Accounting Settings entity configuration
/// </summary>
public class AccSettingConfiguration : IEntityTypeConfiguration<AccSetting>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<AccSetting> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DefaultCurrency)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.VatRate)
            .HasColumnType("decimal(6,4)");

        builder.Property(e => e.WithholdingRate)
            .HasColumnType("decimal(6,4)");

        builder.Property(e => e.VatAccountCode).HasMaxLength(100);
        builder.Property(e => e.WithholdingAccountCode).HasMaxLength(100);
        builder.Property(e => e.FxGainAccountCode).HasMaxLength(100);
        builder.Property(e => e.FxLossAccountCode).HasMaxLength(100);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.DefaultCurrency);
    }
}
