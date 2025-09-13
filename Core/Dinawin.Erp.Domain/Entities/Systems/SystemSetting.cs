namespace Dinawin.Erp.Domain.Entities.Systems;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت تنظیمات سیستم
/// System settings entity
/// </summary>
public class SystemSetting : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// دسته‌بندی تنظیمات
    /// Settings category
    /// </summary>
    public required string Category { get; set; }

    /// <summary>
    /// کلید تنظیمات
    /// Settings key
    /// </summary>
    public required string Key { get; set; }

    /// <summary>
    /// مقدار تنظیمات (JSON)
    /// Settings value (JSON)
    /// </summary>
    public string? Value { get; set; }

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public string BusinessId { get; set; } = "default";
    public string Description { get; set; }
    public string DataType { get; set; }
    public bool IsActive { get; set; }
    public bool IsEditable { get; set; }
    public string DefaultValue { get; set; }

    ///// <summary>
    ///// شناسه کاربر به‌روزرسانی‌کننده
    ///// Updated by user ID
    ///// </summary>
    //public Guid? UpdatedBy { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تنظیمات سیستم
/// System Setting entity configuration
/// </summary>
public class SystemSettingConfiguration : IEntityTypeConfiguration<SystemSetting>
{
    public void Configure(EntityTypeBuilder<SystemSetting> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Category).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Key).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Value).HasMaxLength(4000);
        builder.Property(e => e.BusinessId).HasMaxLength(100);

        builder.HasIndex(e => new { e.Category, e.Key, e.BusinessId }).IsUnique();
        builder.HasIndex(e => e.Category);
    }
}
