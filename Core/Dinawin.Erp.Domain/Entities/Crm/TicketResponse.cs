using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// پاسخ/کامنت تیکت مطابق Supabase: public.ticket_responses
/// Ticket response entity
/// </summary>
public class TicketResponse : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه تیکت
    /// Ticket ID
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// متن پاسخ
    /// Content
    /// </summary>
    public required string Content { get; set; }

    /// <summary>
    /// داخلی است؟
    /// Is internal
    /// </summary>
    public bool IsInternal { get; set; }

    /// <summary>
    /// ایجادکننده
    /// Created by
    /// </summary>
    public Guid? CreatedBy { get; set; }
}

/// <summary>
/// پیکربندی موجودیت پاسخ تیکت
/// TicketResponse entity configuration
/// </summary>
public class TicketResponseConfiguration : IEntityTypeConfiguration<TicketResponse>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<TicketResponse> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Content).IsRequired().HasMaxLength(4000);

        builder.HasIndex(e => e.TicketId);
        builder.HasIndex(e => e.CreatedAt);
    }
}


