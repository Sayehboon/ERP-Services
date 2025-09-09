using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت تیکت CRM
/// CRM Ticket entity
/// </summary>
public class Ticket : BaseEntity
{
    /// <summary>
    /// عنوان تیکت
    /// Ticket title
    /// </summary>
    public string Title { get; set; } = string.Empty;

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
    public string TicketType { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? CreatedById { get; set; }
    public Guid? AssignedToId { get; set; }
    public Guid? ProductId { get; set; }
    public Guid? SalesOrderId { get; set; }
    public Guid? OpportunityId { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string? CloseReason { get; set; }
    public string? Tags { get; set; }
    public string Category { get; set; }
    public string ContactName { get; set; }
    public string CustomerName { get; set; }
    public string Subject { get; set; }
    public string Number { get; set; }
    public int ResponseCount { get; set; }
}
