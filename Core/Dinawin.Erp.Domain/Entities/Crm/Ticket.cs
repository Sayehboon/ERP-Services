using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت تیکت CRM مطابق Supabase: public.tickets
/// CRM Ticket entity aligned with Supabase
/// </summary>
public class Ticket : BaseEntity
{
    /// <summary>
    /// عنوان تیکت
    /// Ticket title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// شماره تیکت (Supabase: ticket_number)
    /// Ticket number
    /// </summary>
    public string? TicketNumber { get; set; }

    /// <summary>
    /// توضیحات تیکت
    /// Ticket description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع تیکت
    /// Ticket type
    /// </summary>
    public string Type { get; set; } = string.Empty;

    /// <summary>
    /// اولویت تیکت
    /// Ticket priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت تیکت
    /// Ticket status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// شناسه مخاطب مرتبط
    /// Related contact ID
    /// </summary>
    public Guid? ContactId { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// ایجاد شده توسط (Supabase: created_by)
    /// Created by user id
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه بیزینس (Supabase: business_id)
    /// Business id
    /// </summary>
    public Guid? BusinessId { get; set; }

    /// <summary>
    /// تاریخ حل شدن
    /// Resolution date
    /// </summary>
    public DateTime? ResolvedAt { get; set; }

    /// <summary>
    /// راه‌حل تیکت
    /// Ticket resolution
    /// </summary>
    public string? Resolution { get; set; }

    /// <summary>
    /// یادداشت‌های تیکت
    /// Ticket notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// وضعیت فعال بودن تیکت
    /// Ticket active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// مخاطب مرتبط با تیکت
    /// Related contact
    /// </summary>
    public Contact? Contact { get; set; }

    /// <summary>
    /// کاربر مسئول تیکت
    /// Assigned user
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? AssignedUser { get; set; }

    /// <summary>
    /// دسته‌بندی تیکت (Supabase: category)
    /// Ticket category
    /// </summary>
    public string Category { get; set; } = "general";

    /// <summary>
    /// نام/ایمیل/تلفن مشتری (Supabase: customer_*)
    /// Customer info
    /// </summary>
    public string? CustomerName { get; set; }
    public string? CustomerEmail { get; set; }
    public string? CustomerPhone { get; set; }

    /// <summary>
    /// موضوع (Supabase: subject)
    /// Subject
    /// </summary>
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ بسته شدن (Supabase: closed_at)
    /// Closed at
    /// </summary>
    public DateTime? ClosedAt { get; set; }
}

/// <summary>
/// پیکربندی موجودیت تیکت CRM
/// CRM Ticket entity configuration
/// </summary>
public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Title).HasMaxLength(250);
        builder.Property(e => e.TicketNumber).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(2000);
        builder.Property(e => e.Type).HasMaxLength(100);
        builder.Property(e => e.Priority).HasMaxLength(50);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Category).HasMaxLength(100);
        builder.Property(e => e.CustomerName).HasMaxLength(200);
        builder.Property(e => e.CustomerEmail).HasMaxLength(200);
        builder.Property(e => e.CustomerPhone).HasMaxLength(50);
        builder.Property(e => e.Subject).HasMaxLength(250);

        builder.HasIndex(e => e.TicketNumber).IsUnique(false);
        builder.HasIndex(e => e.Status);
        builder.HasIndex(e => e.CreatedAt);
    }
}
