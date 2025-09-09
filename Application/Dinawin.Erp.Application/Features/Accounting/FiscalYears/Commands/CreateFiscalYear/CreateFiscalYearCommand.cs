namespace Dinawin.Erp.Application.Features.Accounting.FiscalYears.Commands.CreateFiscalYear;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

public sealed record CreateFiscalYearCommand(string Code, DateTime YearStart, DateTime YearEnd, bool IsActive = true) : IRequest<Guid>;

public sealed class CreateFiscalYearCommandHandler(IApplicationDbContext db) : IRequestHandler<CreateFiscalYearCommand, Guid>
{
    public async Task<Guid> Handle(CreateFiscalYearCommand request, CancellationToken cancellationToken)
    {
        var fy = new FiscalYear
        {
            Id = Guid.NewGuid(),
            Code = request.Code,
            YearStart = request.YearStart,
            YearEnd = request.YearEnd,
            IsActive = request.IsActive
        };
        db.FiscalYears.Add(fy);
        await db.SaveChangesAsync(cancellationToken);
        return fy.Id;
    }
}


