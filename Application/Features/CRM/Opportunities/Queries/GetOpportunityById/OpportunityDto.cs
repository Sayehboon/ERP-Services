namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Queries.GetOpportunityById;

/// <summary>
/// DTO فرصت
/// </summary>
public class OpportunityDto
{
    /// <summary>
    /// شناسه فرصت
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// نام فرصت
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// شناسه لید
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// نام لید
    /// </summary>
    public string LeadName { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// نام مشتری
    /// </summary>
    public string CustomerName { get; set; }

    /// <summary>
    /// شناسه حساب
    /// </summary>
    public Guid? AccountId { get; set; }

    /// <summary>
    /// نام حساب
    /// </summary>
    public string AccountName { get; set; }

    /// <summary>
    /// مرحله فرصت
    /// </summary>
    public string Stage { get; set; } = string.Empty;

    /// <summary>
    /// وضعیت فرصت
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// احتمال موفقیت (درصد)
    /// </summary>
    public int Probability { get; set; }

    /// <summary>
    /// مبلغ فرصت
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    public string Currency { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ بسته شدن مورد انتظار
    /// </summary>
    public DateTime? ExpectedCloseDate { get; set; }

    /// <summary>
    /// تاریخ بسته شدن واقعی
    /// </summary>
    public DateTime? ActualCloseDate { get; set; }

    /// <summary>
    /// نوع فرصت
    /// </summary>
    public string OpportunityType { get; set; }

    /// <summary>
    /// منبع فرصت
    /// </summary>
    public string Source { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// نام کاربر مسئول
    /// </summary>
    public string AssignedToName { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    public string Priority { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    public string Notes { get; set; }

    /// <summary>
    /// تاریخ ایجاد
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// تاریخ به‌روزرسانی
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
