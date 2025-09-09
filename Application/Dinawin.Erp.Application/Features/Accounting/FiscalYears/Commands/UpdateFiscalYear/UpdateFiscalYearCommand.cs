namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.UpdateFiscalYear;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record UpdateFiscalYearCommand(Guid Id, string Code, DateTime YearStart, DateTime YearEnd, bool IsActive) : IRequest<bool>;

public sealed class UpdateFiscalYearCommandHandler(IApplicationDbContext db) : IRequestHandler<UpdateFiscalYearCommand, bool>
{
    public async Task<bool> Handle(UpdateFiscalYearCommand request, CancellationToken cancellationToken)
    {
        var fy = await db.FiscalYears.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (fy == null) return false;
        fy.Code = request.Code;
        fy.YearStart = request.YearStart;
        fy.YearEnd = request.YearEnd;
        fy.IsActive = request.IsActive;
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


