using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Models.Queries.GetAllModels;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست مدل‌ها
/// </summary>
public sealed class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, IEnumerable<ModelDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست مدل‌ها
    /// </summary>
    public GetAllModelsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست مدل‌ها
    /// </summary>
    public async Task<IEnumerable<ModelDto>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Models
            .Include(m => m.Brand)
            .Include(m => m.Products)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(m => 
                m.Name.ToLower().Contains(searchLower) ||
                (m.Description != null && m.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس برند
        if (request.BrandId.HasValue)
        {
            query = query.Where(m => m.BrandId == request.BrandId.Value);
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        if (request.IsActive.HasValue)
        {
            query = query.Where(m => m.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(m => m.SortOrder).ThenBy(m => m.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var models = await query.ToListAsync(cancellationToken);
        
        return models.Select(m => new ModelDto
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            BrandId = m.BrandId,
            BrandName = m.Brand?.Name,
            IsActive = m.IsActive,
            SortOrder = m.SortOrder,
            ProductCount = m.Products?.Count ?? 0,
            CreatedAt = m.CreatedAt,
            UpdatedAt = m.UpdatedAt
        });
    }
}
