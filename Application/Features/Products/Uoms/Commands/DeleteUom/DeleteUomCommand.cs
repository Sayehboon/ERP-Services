namespace Dinawin.Erp.Application.Features.Products.Uoms.Commands.DeleteUom;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان حذف واحد
/// Command to delete UOM
/// </summary>
public record DeleteUomCommand(Guid Id) : IRequest<bool>;

/// <summary>
/// هندلر حذف واحد
/// Handler
/// </summary>
public class DeleteUomCommandHandler : IRequestHandler<DeleteUomCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public DeleteUomCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(DeleteUomCommand request, CancellationToken cancellationToken)
    {
        var u = await _db.UnitsOfMeasures.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (u == null) return false;
        _db.UnitsOfMeasures.Remove(u);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


