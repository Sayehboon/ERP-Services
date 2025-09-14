using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetCrmStats;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت آمار CRM
/// </summary>
public sealed class GetCrmStatsQueryHandler : IRequestHandler<GetCrmStatsQuery, CrmStatsDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت آمار CRM
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetCrmStatsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت آمار CRM
    /// </summary>
    public async Task<CrmStatsDto> Handle(GetCrmStatsQuery request, CancellationToken cancellationToken)
    {
        var fromDate = request.FromDate ?? DateTime.UtcNow.AddMonths(-1);
        var toDate = request.ToDate ?? DateTime.UtcNow;

        // آمار مشتریان
        var totalCustomers = await _context.Customers.CountAsync(cancellationToken);
        var activeCustomers = await _context.Customers.CountAsync(c => c.IsActive, cancellationToken);
        var newCustomers = await _context.Customers
            .CountAsync(c => c.CreatedAt >= fromDate && c.CreatedAt <= toDate, cancellationToken);

        // آمار لیدها
        var totalLeads = await _context.Leads.CountAsync(cancellationToken);
        var activeLeads = await _context.Leads.CountAsync(l => l.IsActive, cancellationToken);
        var convertedLeads = await _context.Leads.CountAsync(l => l.Status == "تبدیل شده", cancellationToken);

        // آمار فرصت‌ها
        var totalOpportunities = await _context.Opportunities.CountAsync(cancellationToken);
        var activeOpportunities = await _context.Opportunities.CountAsync(o => o.IsActive, cancellationToken);
        var closedOpportunities = await _context.Opportunities.CountAsync(o => o.Status == "بسته شده", cancellationToken);
        var totalOpportunityValue = await _context.Opportunities.SumAsync(o => o.EstimatedValue, cancellationToken);

        // آمار تیکت‌ها
        var totalTickets = await _context.Tickets.CountAsync(cancellationToken);
        var openTickets = await _context.Tickets.CountAsync(t => t.Status == "باز", cancellationToken);
        var closedTickets = await _context.Tickets.CountAsync(t => t.Status == "بسته شده", cancellationToken);

        // آمار فعالیت‌ها
        var totalActivities = await _context.Activities.CountAsync(cancellationToken);

        // آمار لیدها بر اساس منبع
        var leadSourceStats = await _context.Leads
            .GroupBy(l => l.Source)
            .Select(g => new LeadSourceStatsDto
            {
                Source = g.Key ?? string.Empty,
                Count = g.Count()
            })
            .ToListAsync(cancellationToken);

        var totalLeadsCount = leadSourceStats.Sum(l => l.Count);
        foreach (var stat in leadSourceStats)
        {
            stat.Percentage = totalLeadsCount > 0 ? (stat.Count / (decimal)totalLeadsCount) * 100 : 0;
        }

        // آمار فرصت‌ها بر اساس مرحله
        var opportunityStageStats = await _context.Opportunities
            .GroupBy(o => o.Stage)
            .Select(g => new OpportunityStageStatsDto
            {
                Stage = g.Key,
                Count = g.Count(),
                TotalValue = g.Sum(o => o.EstimatedValue)
            })
            .ToListAsync(cancellationToken);

        var totalOpportunitiesCount = opportunityStageStats.Sum(o => o.Count);
        foreach (var stat in opportunityStageStats)
        {
            stat.Percentage = totalOpportunitiesCount > 0 ? (stat.Count / (decimal)totalOpportunitiesCount) * 100 : 0;
        }

        // آمار تیکت‌ها بر اساس اولویت
        var ticketPriorityStats = await _context.Tickets
            .GroupBy(t => t.Priority)
            .Select(g => new TicketPriorityStatsDto
            {
                Priority = g.Key,
                Count = g.Count()
            })
            .ToListAsync(cancellationToken);

        var totalTicketsCount = ticketPriorityStats.Sum(t => t.Count);
        foreach (var stat in ticketPriorityStats)
        {
            stat.Percentage = totalTicketsCount > 0 ? (stat.Count / (decimal)totalTicketsCount) * 100 : 0;
        }

        return new CrmStatsDto
        {
            TotalCustomers = totalCustomers,
            ActiveCustomers = activeCustomers,
            NewCustomers = newCustomers,
            TotalLeads = totalLeads,
            ActiveLeads = activeLeads,
            ConvertedLeads = convertedLeads,
            TotalOpportunities = totalOpportunities,
            ActiveOpportunities = activeOpportunities,
            ClosedOpportunities = closedOpportunities,
            TotalOpportunityValue = totalOpportunityValue,
            TotalTickets = totalTickets,
            OpenTickets = openTickets,
            ClosedTickets = closedTickets,
            TotalActivities = totalActivities,
            LeadSourceStats = leadSourceStats,
            OpportunityStageStats = opportunityStageStats,
            TicketPriorityStats = ticketPriorityStats
        };
    }
}
