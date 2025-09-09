namespace Dinawin.Erp.Application.Features.Inventories.Movements.Queries.GetMovementsByProduct;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DTO حرکت انبار برای محصول
/// Inventory movement DTO for product
/// </summary>
public class InventoryMovementDto
{
    public Guid Id { get; set; }
    public DateTime MovementDate { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalValue { get; set; }
    public Guid WarehouseId { get; set; }
}

/// <summary>
/// کوئری حرکات انبار برای محصول
/// Query for inventory movements by product id
/// </summary>
public record GetMovementsByProductQuery(Guid ProductId) : IRequest<IReadOnlyList<InventoryMovementDto>>;

/// <summary>
/// هندلر کوئری
/// Handler
/// </summary>
public class GetMovementsByProductQueryHandler : IRequestHandler<GetMovementsByProductQuery, IReadOnlyList<InventoryMovementDto>>
{
    private readonly IApplicationDbContext _db;
    public GetMovementsByProductQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<InventoryMovementDto>> Handle(GetMovementsByProductQuery request, CancellationToken cancellationToken)
    {
        return await _db.InventoryMovements.AsNoTracking()
            .Where(m => m.ProductId == request.ProductId)
            .OrderByDescending(m => m.MovementDate)
            .Select(m => new InventoryMovementDto
            {
                Id = m.Id,
                MovementDate = m.MovementDate,
                Type = m.Type.ToString(),
                Quantity = m.Quantity,
                UnitCost = m.UnitCost.Amount,
                TotalValue = m.TotalValue.Amount,
                WarehouseId = m.WarehouseId
            })
            .ToListAsync(cancellationToken);
    }
}


