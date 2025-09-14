namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.UpdateFiscalPeriod;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record UpdateFiscalPeriodCommand(Guid Id, string Name, DateTime StartDate, DateTime EndDate, string Status) : IRequest<bool>;

public sealed class UpdateFiscalPeriodCommandHandler(IApplicationDbContext db) : IRequestHandler<UpdateFiscalPeriodCommand, bool>
{
    public async Task<bool> Handle(UpdateFiscalPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await db.FiscalPeriods.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (period == null) return false;
        period.Name = request.Name;
        period.StartDate = request.StartDate;
        period.EndDate = request.EndDate;
        period.Status = request.Status;
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


