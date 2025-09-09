namespace Dinawin.Erp.Application.Features.Inventories.Movements.Queries.GetInventoryMovements;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت حرکات موجودی
/// Query to get inventory movements
/// </summary>
public record GetInventoryMovementsQuery(
    Guid? ProductId = null,
    Guid? WarehouseId = null,
    int Page = 1,
    int PageSize = 25
) : IRequest<IReadOnlyList<InventoryMovementDto>>;

/// <summary>
/// DTO حرکت موجودی
/// Inventory movement DTO
/// </summary>
public class InventoryMovementDto
{
    /// <summary>شناسه حرکت</summary>
    public Guid Id { get; set; }
    /// <summary>نام کالا</summary>
    public string ProductName { get; set; } = string.Empty;
    /// <summary>نام انبار</summary>
    public string WarehouseName { get; set; } = string.Empty;
    /// <summary>نوع حرکت</summary>
    public string Type { get; set; } = string.Empty;
    /// <summary>مقدار حرکت</summary>
    public decimal Quantity { get; set; }
    /// <summary>قیمت واحد</summary>
    public decimal? UnitCost { get; set; }
    /// <summary>مجموع ارزش حرکت</summary>
    public decimal? TotalValue { get; set; }
    /// <summary>موجودی قبل از حرکت</summary>
    public decimal BalanceBefore { get; set; }
    /// <summary>موجودی بعد از حرکت</summary>
    public decimal BalanceAfter { get; set; }
    /// <summary>شماره مرجع</summary>
    public string? ReferenceNumber { get; set; }
    /// <summary>دلیل حرکت</summary>
    public string Reason { get; set; } = string.Empty;
    /// <summary>یادداشت</summary>
    public string? Notes { get; set; }
    /// <summary>تاریخ حرکت</summary>
    public DateTime MovementDate { get; set; }
    /// <summary>تاریخ ایجاد</summary>
    public DateTime CreatedAt { get; set; }
}

/// <summary>
/// هندلر دریافت حرکات موجودی
/// Handler for GetInventoryMovementsQuery
/// </summary>
public class GetInventoryMovementsQueryHandler : IRequestHandler<GetInventoryMovementsQuery, IReadOnlyList<InventoryMovementDto>>
{
    private readonly IApplicationDbContext _db;
    public GetInventoryMovementsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<InventoryMovementDto>> Handle(GetInventoryMovementsQuery request, CancellationToken cancellationToken)
    {
        var query = _db.InventoryMovements.AsNoTracking()
            .Include(m => m.Product)
            .Include(m => m.Warehouse)
            .AsQueryable();

        if (request.ProductId.HasValue)
            query = query.Where(m => m.ProductId == request.ProductId.Value);
        
        if (request.WarehouseId.HasValue)
            query = query.Where(m => m.WarehouseId == request.WarehouseId.Value);

        var movements = await query
            .OrderByDescending(m => m.MovementDate)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(m => new InventoryMovementDto
            {
                Id = m.Id,
                ProductName = m.Product.Name,
                WarehouseName = m.Warehouse.Name,
                Type = m.Type.ToString(),
                Quantity = m.Quantity,
                UnitCost = m.UnitCost.Amount,
                TotalValue = m.TotalValue.Amount,
                BalanceBefore = m.BalanceBefore,
                BalanceAfter = m.BalanceAfter,
                ReferenceNumber = m.ReferenceNumber,
                Reason = m.Reason,
                Notes = m.Notes,
                MovementDate = m.MovementDate,
                CreatedAt = m.CreatedAt
            })
            .ToListAsync(cancellationToken);

        return movements;
    }
}
