namespace Dinawin.Erp.Application.Features.Inventory.Bins.Commands.CreateBin;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Inventories;
using MediatR;

public record CreateBinCommand(
    string Code,
    string? Name = null,
    string? Description = null,
    string? Aisle = null,
    string? Shelf = null,
    Guid WarehouseId = default
) : IRequest<Guid>;

public class CreateBinCommandHandler : IRequestHandler<CreateBinCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateBinCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateBinCommand request, CancellationToken cancellationToken)
    {
        var bin = new Bin
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            Name = request.Name,
            Description = request.Description,
            Aisle = request.Aisle,
            Shelf = request.Shelf,
            WarehouseId = request.WarehouseId,
            IsActive = true
        };

        _db.Bins.Add(bin);
        await _db.SaveChangesAsync(cancellationToken);
        return bin.Id;
    }
}
