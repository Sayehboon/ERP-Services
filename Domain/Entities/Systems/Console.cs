using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// کنسول‌های سیستم (منوهای اصلی) مطابق Supabase public.consoles
/// System consoles (top-level menus)
/// </summary>
public class Console : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام کنسول
    /// Console name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد کنسول (یکتا)
    /// Console code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// عملیات/منوهای زیرمجموعه
    /// Operations children
    /// </summary>
    public ICollection<Operation> Operations { get; set; } = new List<Operation>();
}

/// <summary>
/// پیکربندی موجودیت کنسول سیستم
/// Console entity configuration
/// </summary>
public class ConsoleConfiguration : IEntityTypeConfiguration<Console>
{
    public void Configure(EntityTypeBuilder<Console> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);

        builder.HasIndex(e => e.Code).IsUnique();
    }
}


