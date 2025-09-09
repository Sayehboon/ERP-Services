using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت سرنخ CRM
/// CRM Lead entity
/// </summary>
public class Lead : BaseEntity
{
    /// <summary>
    /// نام سرنخ
    /// Lead name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی سرنخ
    /// Lead last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// ایمیل سرنخ
    /// Lead email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن سرنخ
    /// Lead phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// موبایل سرنخ
    /// Lead mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// نام شرکت سرنخ
    /// Lead company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// سمت سرنخ
    /// Lead position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// منبع سرنخ
    /// Lead source
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// وضعیت سرنخ
    /// Lead status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// اولویت سرنخ
    /// Lead priority
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// ارزش احتمالی سرنخ
    /// Lead estimated value
    /// </summary>
    public decimal? EstimatedValue { get; set; }

    /// <summary>
    /// ارز ارزش احتمالی
    /// Estimated value currency
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// تاریخ تبدیل احتمالی
    /// Expected conversion date
    /// </summary>
    public DateTime? ExpectedConversionDate { get; set; }

    /// <summary>
    /// توضیحات سرنخ
    /// Lead description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های سرنخ
    /// Lead notes
    /// </summary>
    public string? Notes { get; set; }

    

    /// <summary>
    /// شناسه کاربر مسئول
    /// Assigned to user ID
    /// </summary>
    public Guid? AssignedTo { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سرنخ
    /// Lead active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? PostalCode { get; set; }
    public string? LeadSource { get; set; }
    public DateTime? ExpectedCloseDate { get; set; }
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// کاربر مسئول سرنخ (ناوبری)
    /// Assigned user navigation
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Users.User? AssignedToUser { get; set; }

    /// <summary>
    /// فعالیت‌های مرتبط با سرنخ
    /// Related CRM activities
    /// </summary>
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    public int Score { get; set; }
}
