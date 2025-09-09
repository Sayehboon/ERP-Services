namespace Dinawin.Erp.Application.Features.Accounting.FiscalPeriods.Commands.CreateFiscalPeriod;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

public sealed record CreateFiscalPeriodCommand(Guid FiscalYearId, int PeriodNo, string Name, DateTime StartDate, DateTime EndDate) : IRequest<Guid>;

public sealed class CreateFiscalPeriodCommandHandler(IApplicationDbContext db) : IRequestHandler<CreateFiscalPeriodCommand, Guid>
{
    public async Task<Guid> Handle(CreateFiscalPeriodCommand request, CancellationToken cancellationToken)
    {
        var period = new FiscalPeriod
        {
            Id = Guid.NewGuid(),
            FiscalYearId = request.FiscalYearId,
            PeriodNo = request.PeriodNo,
            Name = request.Name,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = "open"
        };
        db.FiscalPeriods.Add(period);
        await db.SaveChangesAsync(cancellationToken);
        return period.Id;
    }
}


