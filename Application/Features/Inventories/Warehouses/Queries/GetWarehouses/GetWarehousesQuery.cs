namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Queries.GetWarehouses;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت انبارها
/// Query to get warehouses
/// </summary>
public record GetWarehousesQuery() : IRequest<IReadOnlyList<WarehouseDto>>;

/// <summary>
/// DTO انبار
/// Warehouse DTO
/// </summary>
public class WarehouseDto
{
    /// <summary>شناسه</summary>
    public Guid Id { get; set; }
    /// <summary>نام</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>کد</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>توضیحات</summary>
    public string Description { get; set; }
    /// <summary>نوع انبار</summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>ظرفیت</summary>
    public decimal? Capacity { get; set; }
    /// <summary>فعال است؟</summary>
    public bool IsActive { get; set; }
    /// <summary>انبار اصلی است؟</summary>
    public bool IsMainWarehouse { get; set; }
    /// <summary>شناسه کسب‌وکار</summary>
    public string BusinessId { get; set; } = string.Empty;
}

/// <summary>
/// هندلر دریافت انبارها
/// Handler for GetWarehousesQuery
/// </summary>
public class GetWarehousesQueryHandler : IRequestHandler<GetWarehousesQuery, IReadOnlyList<WarehouseDto>>
{
    private readonly IApplicationDbContext _db;
    public GetWarehousesQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<WarehouseDto>> Handle(GetWarehousesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Warehouses.AsNoTracking()
            .OrderBy(w => w.Name)
            .Select(w => new WarehouseDto 
            { 
                Id = w.Id, 
                Name = w.Name,
                Code = w.Code,
                Description = w.Description,
                Type = w.Type.ToString(),
                Capacity = w.Capacity,
                IsActive = w.IsActive,
                IsMainWarehouse = w.IsMainWarehouse,
                BusinessId = w.BusinessId
            })
            .ToListAsync(cancellationToken);
    }
}
