namespace Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.CreateCashTransaction;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;
using Dinawin.Erp.Domain.ValueObjects;
using MediatR;

public record CreateCashTransactionCommand(
    Guid CashBoxId,
    DateTime TransactionDate,
    string Type,
    decimal Amount,
    string Currency,
    string? Description = null
) : IRequest<Guid>;

public class CreateCashTransactionCommandHandler : IRequestHandler<CreateCashTransactionCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateCashTransactionCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateCashTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new CashTransaction
        {
            Id = Guid.NewGuid(),
            CashBoxId = request.CashBoxId,
            TransactionDate = request.TransactionDate,
            Type = Enum.Parse<CashTransactionType>(request.Type, true),
            Amount = new Money(request.Amount, request.Currency),
            Description = request.Description,
            Status = CashTransactionStatus.Draft,
            IsPosted = false
        };

        _db.CashTransactions.Add(transaction);
        await _db.SaveChangesAsync(cancellationToken);
        return transaction.Id;
    }
}
