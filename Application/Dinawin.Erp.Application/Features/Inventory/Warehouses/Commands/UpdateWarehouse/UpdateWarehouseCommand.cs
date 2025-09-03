namespace Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.UpdateWarehouse;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateWarehouseCommand(
    Guid Id,
    string? Name = null,
    string? Code = null,
    string? Description = null
) : IRequest<bool>;

public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateWarehouseCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = await _db.Warehouses.FirstOrDefaultAsync(w => w.Id == request.Id, cancellationToken);
        if (warehouse == null) return false;

        if (request.Name != null) warehouse.Name = request.Name;
        if (request.Code != null) warehouse.Code = request.Code;
        if (request.Description != null) warehouse.Description = request.Description;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
