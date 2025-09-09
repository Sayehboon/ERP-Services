using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Crm;

/// <summary>
/// موجودیت فرصت CRM
/// CRM Opportunity entity
/// </summary>
public class Opportunity : BaseEntity
{
    /// <summary>
    /// نام فرصت
    /// Opportunity name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات فرصت
    /// Opportunity description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// ارزش فرصت
    /// Opportunity value
    /// </summary>
    public decimal Value { get; set; }

    /// <summary>
    /// ارز ارزش فرصت
    /// Opportunity value currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// مرحله فرصت
    /// Opportunity stage
    /// </summary>
    public string Stage { get; set; } = string.Empty;

    /// <summary>
    /// احتمال موفقیت فرصت
    /// Opportunity probability
    /// </summary>
    public int Probability { get; set; }

    /// <summary>
    /// تاریخ بسته شدن انتظاری
    /// Expected close date
    /// </summary>
    public DateTime? ExpectedCloseDate { get; set; }

    /// <summary>
    /// تاریخ بسته شدن واقعی
    /// Actual close date
    /// </summary>
    public DateTime? ActualCloseDate { get; set; }

    /// <summary>
    /// نوع فرصت
    /// Opportunity type
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// منبع فرصت
    /// Opportunity source
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// وضعیت فرصت
    /// Opportunity status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// شناسه سرنخ مرتبط
    /// Related lead ID
    /// </summary>
    public Guid? LeadId { get; set; }

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
    /// یادداشت‌های فرصت
    /// Opportunity notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// وضعیت فعال بودن فرصت
    /// Opportunity active status
    /// </summary>
    public bool IsActive { get; set; } = true;
    public Guid? AccountId { get; set; }
    public Guid? CustomerId { get; set; }
    public decimal Amount { get; set; }
    public string? OpportunityType { get; set; }
    public string? Priority { get; set; }

    /// <summary>
    /// سرنخ مرتبط
    /// Related lead
    /// </summary>
    public Lead? Lead { get; set; }

    /// <summary>
    /// مخاطب مرتبط
    /// Related contact
    /// </summary>
    public Contact? Contact { get; set; }

    /// <summary>
    /// فعالیت‌های مرتبط با فرصت
    /// Related activities
    /// </summary>
    public ICollection<Activity> Activities { get; set; } = new List<Activity>();

    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public Dinawin.Erp.Domain.Entities.Accounting.Customer? Customer { get; set; }
    public decimal EstimatedValue { get; set; }
    public string AccountName { get; set; }
    public string ContactName { get; set; }
    public DateTime CloseDate { get; set; }
    public string Owner { get; set; }
}
