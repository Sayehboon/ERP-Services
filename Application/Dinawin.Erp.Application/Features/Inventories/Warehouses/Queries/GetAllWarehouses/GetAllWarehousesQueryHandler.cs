using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Queries.GetAllWarehouses;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست انبارها
/// </summary>
public sealed class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IEnumerable<WarehouseDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست انبارها
    /// </summary>
    public GetAllWarehousesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست انبارها
    /// </summary>
    public async Task<IEnumerable<WarehouseDto>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Warehouses.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(w => 
                w.Name.ToLower().Contains(searchLower) ||
                w.Code.ToLower().Contains(searchLower) ||
                (w.Address != null && w.Address.ToLower().Contains(searchLower)) ||
                (w.ManagerName != null && w.ManagerName.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس نوع انبار
        if (!string.IsNullOrWhiteSpace(request.WarehouseType))
        {
            query = query.Where(w => w.WarehouseType == request.WarehouseType);
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(w => w.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(w => w.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var warehouses = await query.ToListAsync(cancellationToken);
        
        return warehouses.Select(w => new WarehouseDto
        {
            Id = w.Id,
            Name = w.Name,
            Code = w.Code,
            Address = w.Address,
            PhoneNumber = w.PhoneNumber,
            Email = w.Email,
            ManagerName = w.ManagerName,
            Capacity = w.Capacity,
            CapacityUnit = w.CapacityUnit,
            WarehouseType = w.WarehouseType,
            Description = w.Description,
            IsActive = w.IsActive,
            BinsCount = _context.Bins.Count(b => b.WarehouseId == w.Id),
            ProductsCount = _context.Inventory.Count(i => i.WarehouseId == w.Id),
            TotalInventoryValue = _context.Inventory
                .Where(i => i.WarehouseId == w.Id)
                .Sum(i => i.Quantity * i.UnitPrice),
            CreatedAt = w.CreatedAt,
            UpdatedAt = w.UpdatedAt,
            CreatedBy = w.CreatedBy,
            UpdatedBy = w.UpdatedBy
        });
    }
}
