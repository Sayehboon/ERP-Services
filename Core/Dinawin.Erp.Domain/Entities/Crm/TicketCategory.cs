using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// دسته‌بندی تیکت‌ها مطابق Supabase: public.ticket_categories
/// Ticket category entity
/// </summary>
public class TicketCategory : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام دسته‌بندی
    /// Name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد یکتا
    /// Code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// رنگ نمایش
    /// Color
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// وضعیت فعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }
}

/// <summary>
/// پیکربندی موجودیت دسته‌بندی تیکت
/// TicketCategory entity configuration
/// </summary>
public class TicketCategoryConfiguration : IEntityTypeConfiguration<TicketCategory>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<TicketCategory> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Color).HasMaxLength(50);

        builder.HasIndex(e => new { e.BusinessId, e.Code }).IsUnique();
        builder.HasIndex(e => e.Name);
    }
}


