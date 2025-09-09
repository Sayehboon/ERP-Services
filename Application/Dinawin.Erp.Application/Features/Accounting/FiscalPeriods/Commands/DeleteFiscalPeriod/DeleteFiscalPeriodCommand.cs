namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.DeleteFiscalPeriod;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public sealed record DeleteFiscalPeriodCommand(Guid Id) : IRequest<bool>;

public sealed class DeleteFiscalPeriodCommandHandler(IApplicationDbContext db) : IRequestHandler<DeleteFiscalPeriodCommand, bool>
{
    public async Task<bool> Handle(DeleteFiscalPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = await db.FiscalPeriods.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (period == null) return false;
        db.FiscalPeriods.Remove(period);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


