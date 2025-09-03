namespace Dinawin.Erp.Application.Features.Treasury.CashBoxes.Commands.CreateCashBox;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;
using MediatR;

public record CreateCashBoxCommand(
    string Name,
    string? Location = null,
    string BusinessId = "default"
) : IRequest<Guid>;

public class CreateCashBoxCommandHandler : IRequestHandler<CreateCashBoxCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateCashBoxCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateCashBoxCommand request, CancellationToken cancellationToken)
    {
        var cashBox = new CashBox
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Location = request.Location,
            BusinessId = request.BusinessId,
            IsActive = true
        };

        _db.CashBoxes.Add(cashBox);
        await _db.SaveChangesAsync(cancellationToken);
        return cashBox.Id;
    }
}
