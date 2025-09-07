using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Queries.GetAllOpportunities;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست فرصت‌ها
/// </summary>
public sealed class GetAllOpportunitiesQueryHandler : IRequestHandler<GetAllOpportunitiesQuery, IEnumerable<OpportunityDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست فرصت‌ها
    /// </summary>
    public GetAllOpportunitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست فرصت‌ها
    /// </summary>
    public async Task<IEnumerable<OpportunityDto>> Handle(GetAllOpportunitiesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Opportunities
            .Include(o => o.Lead)
            .Include(o => o.Customer)
            .Include(o => o.Account)
            .Include(o => o.AssignedTo)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(o => 
                o.Name.ToLower().Contains(searchLower) ||
                (o.Lead != null && o.Lead.Name.ToLower().Contains(searchLower)) ||
                (o.Customer != null && o.Customer.Name.ToLower().Contains(searchLower)) ||
                (o.Account != null && o.Account.Name.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس مرحله
        if (!string.IsNullOrWhiteSpace(request.Stage))
        {
            query = query.Where(o => o.Stage == request.Stage);
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(o => o.Status == request.Status);
        }

        // فیلتر بر اساس کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            query = query.Where(o => o.AssignedToId == request.AssignedToId.Value);
        }

        // فیلتر بر اساس اولویت
        if (!string.IsNullOrWhiteSpace(request.Priority))
        {
            query = query.Where(o => o.Priority == request.Priority);
        }

        // فیلتر بر اساس نوع فرصت
        if (!string.IsNullOrWhiteSpace(request.OpportunityType))
        {
            query = query.Where(o => o.OpportunityType == request.OpportunityType);
        }

        // فیلتر بر اساس مبلغ
        if (request.MinAmount.HasValue)
        {
            query = query.Where(o => o.Amount >= request.MinAmount.Value);
        }

        if (request.MaxAmount.HasValue)
        {
            query = query.Where(o => o.Amount <= request.MaxAmount.Value);
        }

        // فیلتر بر اساس تاریخ بسته شدن مورد انتظار
        if (request.ExpectedCloseFrom.HasValue)
        {
            query = query.Where(o => o.ExpectedCloseDate >= request.ExpectedCloseFrom.Value);
        }

        if (request.ExpectedCloseTo.HasValue)
        {
            query = query.Where(o => o.ExpectedCloseDate <= request.ExpectedCloseTo.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(o => o.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var opportunities = await query.ToListAsync(cancellationToken);
        
        return opportunities.Select(o => new OpportunityDto
        {
            Id = o.Id,
            Name = o.Name,
            LeadId = o.LeadId,
            LeadName = o.Lead?.Name,
            CustomerId = o.CustomerId,
            CustomerName = o.Customer?.Name,
            AccountId = o.AccountId,
            AccountName = o.Account?.Name,
            Stage = o.Stage,
            Status = o.Status,
            Probability = o.Probability,
            Amount = o.Amount,
            Currency = o.Currency,
            ExpectedCloseDate = o.ExpectedCloseDate,
            ActualCloseDate = o.ActualCloseDate,
            OpportunityType = o.OpportunityType,
            Source = o.Source,
            AssignedToId = o.AssignedToId,
            AssignedToName = o.AssignedTo != null ? $"{o.AssignedTo.FirstName} {o.AssignedTo.LastName}" : null,
            Priority = o.Priority,
            Notes = o.Notes,
            CreatedAt = o.CreatedAt,
            UpdatedAt = o.UpdatedAt,
            CreatedBy = o.CreatedBy,
            UpdatedBy = o.UpdatedBy
        });
    }
}
