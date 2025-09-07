using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Trims.Queries.GetAllTrims;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست تریم‌ها
/// </summary>
public sealed class GetAllTrimsQueryHandler : IRequestHandler<GetAllTrimsQuery, IEnumerable<TrimDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست تریم‌ها
    /// </summary>
    public GetAllTrimsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست تریم‌ها
    /// </summary>
    public async Task<IEnumerable<TrimDto>> Handle(GetAllTrimsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Trims
            .Include(t => t.Model)
            .Include(t => t.Products)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(t => 
                t.Name.ToLower().Contains(searchLower) ||
                (t.Description != null && t.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس مدل
        if (request.ModelId.HasValue)
        {
            query = query.Where(t => t.ModelId == request.ModelId.Value);
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(t => t.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(t => t.SortOrder).ThenBy(t => t.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var trims = await query.ToListAsync(cancellationToken);
        
        return trims.Select(t => new TrimDto
        {
            Id = t.Id,
            Name = t.Name,
            Description = t.Description,
            ModelId = t.ModelId,
            ModelName = t.Model?.Name,
            IsActive = t.IsActive,
            SortOrder = t.SortOrder,
            ProductCount = t.Products?.Count ?? 0,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        });
    }
}
