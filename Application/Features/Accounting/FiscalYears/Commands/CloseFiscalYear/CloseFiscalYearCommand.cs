namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.CloseFiscalYear;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record CloseFiscalYearCommand(Guid Id) : IRequest<bool>;

public sealed class CloseFiscalYearCommandHandler(IApplicationDbContext db) : IRequestHandler<CloseFiscalYearCommand, bool>
{
    public async Task<bool> Handle(CloseFiscalYearCommand request, CancellationToken cancellationToken)
    {
        var fy = await db.FiscalYears.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (fy == null) return false;
        fy.IsActive = false;
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


