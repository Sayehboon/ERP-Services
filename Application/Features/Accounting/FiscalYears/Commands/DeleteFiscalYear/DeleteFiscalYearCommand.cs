namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.DeleteFiscalYear;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record DeleteFiscalYearCommand(Guid Id) : IRequest<bool>;

public sealed class DeleteFiscalYearCommandHandler(IApplicationDbContext db) : IRequestHandler<DeleteFiscalYearCommand, bool>
{
    public async Task<bool> Handle(DeleteFiscalYearCommand request, CancellationToken cancellationToken)
    {
        var fy = await db.FiscalYears.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (fy == null) return false;
        db.FiscalYears.Remove(fy);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


