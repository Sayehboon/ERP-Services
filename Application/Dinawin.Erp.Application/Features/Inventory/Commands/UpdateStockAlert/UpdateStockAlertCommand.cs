namespace Dinawin.Erp.Application.Features.Inventory.Commands.UpdateStockAlert;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان به‌روزرسانی حداقل موجودی هشدار
/// Update stock alert command
/// </summary>
public record UpdateStockAlertCommand(Guid InventoryId, decimal MinStockAlert) : IRequest<bool>;

/// <summary>
/// هندلر فرمان به‌روزرسانی حداقل موجودی هشدار
/// Handler for UpdateStockAlertCommand
/// </summary>
public class UpdateStockAlertCommandHandler : IRequestHandler<UpdateStockAlertCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateStockAlertCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateStockAlertCommand request, CancellationToken cancellationToken)
    {
        var inventory = await _db.Inventories.FirstOrDefaultAsync(i => i.Id == request.InventoryId, cancellationToken);
        if (inventory == null) return false;

        inventory.MinStockAlert = request.MinStockAlert;
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
