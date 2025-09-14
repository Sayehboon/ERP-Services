namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Commands.CreateWarehouse;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;
using MediatR;

public record CreateWarehouseCommand(
    string Name,
    string Code,
    string Description = null,
    string BusinessId = "default"
) : IRequest<Guid>;

public class CreateWarehouseCommandHandler : IRequestHandler<CreateWarehouseCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateWarehouseCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateWarehouseCommand request, CancellationToken cancellationToken)
    {
        var warehouse = new Warehouse
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            BusinessId = request.BusinessId,
            Type = WarehouseType.General,
            IsActive = true
        };

        _db.Warehouses.Add(warehouse);
        await _db.SaveChangesAsync(cancellationToken);
        return warehouse.Id;
    }
}
