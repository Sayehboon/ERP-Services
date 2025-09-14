using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Inventories.Bins.DTOs;

namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetAllBins;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست مکان‌ها
/// </summary>
public sealed class GetAllBinsQueryHandler : IRequestHandler<GetAllBinsQuery, IEnumerable<BinDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست مکان‌ها
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllBinsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست مکان‌ها
    /// </summary>
    public async Task<IEnumerable<BinDto>> Handle(GetAllBinsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Bins
            .Include(b => b.Warehouse)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm?.ToLower() ?? string.Empty;
            query = query.Where(b => 
                (b.Name != null && b.Name.ToLower().Contains(searchTerm)) ||
                (b.Code != null && b.Code.ToLower().Contains(searchTerm)) ||
                (b.Description != null && b.Description.ToLower().Contains(searchTerm)) ||
                (b.Location != null && b.Location.ToLower().Contains(searchTerm)));
        }

        if (request.WarehouseId.HasValue)
        {
            query = query.Where(b => b.WarehouseId == request.WarehouseId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.BinType))
        {
            query = query.Where(b => b.BinType == request.BinType);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(b => b.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(b => b.Warehouse.Name)
                    .ThenBy(b => b.Name);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var bins = await query.ToListAsync(cancellationToken);

        return bins.Select(b => new BinDto
        {
            Id = b.Id,
            Name = b.Name,
            Code = b.Code,
            WarehouseId = b.WarehouseId,
            WarehouseName = b.Warehouse?.Name ?? string.Empty,
            BinType = b.BinType,
            Capacity = b.Capacity,
            CapacityUnit = b.CapacityUnit,
            Width = b.Width,
            Length = b.Length,
            Height = b.Height,
            Location = b.Location,
            Description = b.Description,
            IsActive = b.IsActive,
            CreatedAt = b.CreatedAt,
            UpdatedAt = b.UpdatedAt,
            CreatedBy = b.CreatedBy,
            UpdatedBy = b.UpdatedBy
        });
    }
}
