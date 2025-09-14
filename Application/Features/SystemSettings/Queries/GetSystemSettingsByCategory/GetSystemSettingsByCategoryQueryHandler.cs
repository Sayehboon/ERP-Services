using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingsByCategory;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تنظیمات سیستم بر اساس دسته‌بندی
/// </summary>
public sealed class GetSystemSettingsByCategoryQueryHandler : IRequestHandler<GetSystemSettingsByCategoryQuery, IEnumerable<SystemSettingDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تنظیمات سیستم بر اساس دسته‌بندی
    /// </summary>
    public GetSystemSettingsByCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت تنظیمات سیستم بر اساس دسته‌بندی
    /// </summary>
    public async Task<IEnumerable<SystemSettingDto>> Handle(GetSystemSettingsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SystemSettings
            .Where(ss => ss.Category == request.Category)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(ss => 
                (ss.Key != null && ss.Key.ToLower().Contains(searchLower)) ||
                (ss.Value != null && ss.Value.ToLower().Contains(searchLower)) ||
                (ss.Description != null && ss.Description.ToLower().Contains(searchLower)));
        }

        // مرتب‌سازی
        query = query.OrderBy(ss => ss.Key);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var systemSettings = await query.ToListAsync(cancellationToken);
        
        return systemSettings.Select(ss => new SystemSettingDto
        {
            Id = ss.Id,
            Key = ss.Key,
            Value = ss.Value,
            Description = ss.Description ?? string.Empty,
            Category = ss.Category,
            DataType = ss.DataType,
            IsEditable = ss.IsEditable,
            IsActive = ss.IsActive,
            DefaultValue = ss.DefaultValue,
            CreatedAt = ss.CreatedAt,
            UpdatedAt = ss.UpdatedAt,
            CreatedBy = ss.CreatedBy,
            UpdatedBy = ss.UpdatedBy
        });
    }
}
