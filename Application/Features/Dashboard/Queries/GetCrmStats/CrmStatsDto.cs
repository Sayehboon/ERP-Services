namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetCrmStats;

/// <summary>
/// مدل انتقال داده آمار CRM
/// </summary>
public sealed class CrmStatsDto
{
    /// <summary>
    /// تعداد کل مشتریان
    /// </summary>
    public int TotalCustomers { get; set; }

    /// <summary>
    /// تعداد مشتریان فعال
    /// </summary>
    public int ActiveCustomers { get; set; }

    /// <summary>
    /// تعداد مشتریان جدید
    /// </summary>
    public int NewCustomers { get; set; }

    /// <summary>
    /// تعداد کل لیدها
    /// </summary>
    public int TotalLeads { get; set; }

    /// <summary>
    /// تعداد لیدهای فعال
    /// </summary>
    public int ActiveLeads { get; set; }

    /// <summary>
    /// تعداد لیدهای تبدیل شده
    /// </summary>
    public int ConvertedLeads { get; set; }

    /// <summary>
    /// تعداد کل فرصت‌ها
    /// </summary>
    public int TotalOpportunities { get; set; }

    /// <summary>
    /// تعداد فرصت‌های فعال
    /// </summary>
    public int ActiveOpportunities { get; set; }

    /// <summary>
    /// تعداد فرصت‌های بسته شده
    /// </summary>
    public int ClosedOpportunities { get; set; }

    /// <summary>
    /// ارزش کل فرصت‌ها
    /// </summary>
    public decimal TotalOpportunityValue { get; set; }

    /// <summary>
    /// تعداد کل تیکت‌ها
    /// </summary>
    public int TotalTickets { get; set; }

    /// <summary>
    /// تعداد تیکت‌های باز
    /// </summary>
    public int OpenTickets { get; set; }

    /// <summary>
    /// تعداد تیکت‌های بسته شده
    /// </summary>
    public int ClosedTickets { get; set; }

    /// <summary>
    /// تعداد کل فعالیت‌ها
    /// </summary>
    public int TotalActivities { get; set; }

    /// <summary>
    /// آمار لیدها بر اساس منبع
    /// </summary>
    public List<LeadSourceStatsDto> LeadSourceStats { get; set; } = new();

    /// <summary>
    /// آمار فرصت‌ها بر اساس مرحله
    /// </summary>
    public List<OpportunityStageStatsDto> OpportunityStageStats { get; set; } = new();

    /// <summary>
    /// آمار تیکت‌ها بر اساس اولویت
    /// </summary>
    public List<TicketPriorityStatsDto> TicketPriorityStats { get; set; } = new();
}

/// <summary>
/// مدل آمار لیدها بر اساس منبع
/// </summary>
public sealed class LeadSourceStatsDto
{
    /// <summary>
    /// منبع لید
    /// </summary>
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// تعداد لیدها
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}

/// <summary>
/// مدل آمار فرصت‌ها بر اساس مرحله
/// </summary>
public sealed class OpportunityStageStatsDto
{
    /// <summary>
    /// مرحله فرصت
    /// </summary>
    public string Stage { get; set; } = string.Empty;

    /// <summary>
    /// تعداد فرصت‌ها
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// مجموع ارزش
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}

/// <summary>
/// مدل آمار تیکت‌ها بر اساس اولویت
/// </summary>
public sealed class TicketPriorityStatsDto
{
    /// <summary>
    /// اولویت تیکت
    /// </summary>
    public string Priority { get; set; } = string.Empty;

    /// <summary>
    /// تعداد تیکت‌ها
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// درصد از کل
    /// </summary>
    public decimal Percentage { get; set; }
}
