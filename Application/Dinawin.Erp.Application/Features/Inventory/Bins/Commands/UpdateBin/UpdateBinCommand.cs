namespace Dinawin.Erp.Application.Features.Inventory.Bins.Commands.UpdateBin;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateBinCommand(
    Guid Id,
    string? Code = null,
    string? Name = null,
    string? Description = null,
    string? Aisle = null,
    string? Shelf = null,
    bool? IsActive = null
) : IRequest<bool>;

public class UpdateBinCommandHandler : IRequestHandler<UpdateBinCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateBinCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateBinCommand request, CancellationToken cancellationToken)
    {
        var bin = await _db.Bins.FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);
        if (bin == null) return false;

        if (request.Code != null) bin.Code = request.Code;
        if (request.Name != null) bin.Name = request.Name;
        if (request.Description != null) bin.Description = request.Description;
        if (request.Aisle != null) bin.Aisle = request.Aisle;
        if (request.Shelf != null) bin.Shelf = request.Shelf;
        if (request.IsActive.HasValue) bin.IsActive = request.IsActive.Value;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
