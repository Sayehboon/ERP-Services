using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Queries.GetAllLeads;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست لیدها
/// </summary>
public sealed class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<LeadDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست لیدها
    /// </summary>
    public GetAllLeadsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست لیدها
    /// </summary>
    public async Task<IEnumerable<LeadDto>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Leads
            .Include(l => l.AssignedTo)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(l => 
                l.Name.ToLower().Contains(searchLower) ||
                (l.CompanyName != null && l.CompanyName.ToLower().Contains(searchLower)) ||
                (l.Email != null && l.Email.ToLower().Contains(searchLower)) ||
                (l.Phone != null && l.Phone.Contains(searchLower)) ||
                (l.Mobile != null && l.Mobile.Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت
        if (!string.IsNullOrWhiteSpace(request.Status))
        {
            query = query.Where(l => l.Status == request.Status);
        }

        // فیلتر بر اساس منبع لید
        if (!string.IsNullOrWhiteSpace(request.LeadSource))
        {
            query = query.Where(l => l.LeadSource == request.LeadSource);
        }

        // فیلتر بر اساس کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            query = query.Where(l => l.AssignedToId == request.AssignedToId.Value);
        }

        // فیلتر بر اساس اولویت
        if (!string.IsNullOrWhiteSpace(request.Priority))
        {
            query = query.Where(l => l.Priority == request.Priority);
        }

        // فیلتر بر اساس تاریخ ایجاد
        if (request.CreatedFrom.HasValue)
        {
            query = query.Where(l => l.CreatedAt >= request.CreatedFrom.Value);
        }

        if (request.CreatedTo.HasValue)
        {
            query = query.Where(l => l.CreatedAt <= request.CreatedTo.Value);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(l => l.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var leads = await query.ToListAsync(cancellationToken);
        
        return leads.Select(l => new LeadDto
        {
            Id = l.Id,
            Name = l.Name,
            CompanyName = l.CompanyName,
            Email = l.Email,
            Phone = l.Phone,
            Mobile = l.Mobile,
            Address = l.Address,
            City = l.City,
            Province = l.Province,
            PostalCode = l.PostalCode,
            LeadSource = l.LeadSource,
            Status = l.Status,
            Priority = l.Priority,
            EstimatedValue = l.EstimatedValue,
            ExpectedCloseDate = l.ExpectedCloseDate,
            AssignedToId = l.AssignedToId,
            AssignedToName = l.AssignedTo != null ? $"{l.AssignedTo.FirstName} {l.AssignedTo.LastName}" : null,
            Notes = l.Notes,
            CreatedAt = l.CreatedAt,
            UpdatedAt = l.UpdatedAt,
            CreatedBy = l.CreatedBy,
            UpdatedBy = l.UpdatedBy
        });
    }
}
