using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetAllSystemSettings;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست تنظیمات سیستم
/// </summary>
public sealed class GetAllSystemSettingsQueryHandler : IRequestHandler<GetAllSystemSettingsQuery, IEnumerable<SystemSettingDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست تنظیمات سیستم
    /// </summary>
    public GetAllSystemSettingsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست تنظیمات سیستم
    /// </summary>
    public async Task<IEnumerable<SystemSettingDto>> Handle(GetAllSystemSettingsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.SystemSettings.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(ss => 
                ss.Key.ToLower().Contains(searchLower) ||
                ss.Value.ToLower().Contains(searchLower) ||
                (ss.Description != null && ss.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس دسته‌بندی
        if (!string.IsNullOrWhiteSpace(request.Category))
        {
            query = query.Where(ss => ss.Category == request.Category);
        }

        // فیلتر بر اساس نوع داده
        if (!string.IsNullOrWhiteSpace(request.DataType))
        {
            query = query.Where(ss => ss.DataType == request.DataType);
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(ss => ss.IsActive == request.IsActive.Value);
        }

        // فیلتر بر اساس وضعیت قابل ویرایش بودن
        if (request.IsEditable.HasValue)
        {
            query = query.Where(ss => ss.IsEditable == request.IsEditable.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(ss => ss.Category).ThenBy(ss => ss.Key);

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
            Description = ss.Description,
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
