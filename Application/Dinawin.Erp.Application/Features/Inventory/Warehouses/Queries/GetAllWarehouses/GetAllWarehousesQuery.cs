namespace Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetAllWarehouses;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت انبارها
/// Query to get warehouses
/// </summary>
public record GetAllWarehousesQuery() : IRequest<IReadOnlyList<WarehouseListItemDto>>;

/// <summary>
/// DTO لیست انبار
/// Warehouse list DTO
/// </summary>
public class WarehouseListItemDto
{
    /// <summary>شناسه</summary>
    public Guid Id { get; set; }
    /// <summary>نام</summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>کد</summary>
    public string Code { get; set; } = string.Empty;
    /// <summary>شناسه کسب‌وکار</summary>
    public string BusinessId { get; set; } = string.Empty;
}

/// <summary>
/// هندلر دریافت انبارها
/// Handler for GetAllWarehousesQuery
/// </summary>
public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IReadOnlyList<WarehouseListItemDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllWarehousesQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<WarehouseListItemDto>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Warehouses.AsNoTracking()
            .OrderBy(w => w.Name)
            .Select(w => new WarehouseListItemDto 
            { 
                Id = w.Id, 
                Name = w.Name,
                Code = w.Code,
                BusinessId = w.BusinessId
            })
            .ToListAsync(cancellationToken);
    }
}


