namespace Dinawin.Erp.Application.Features.Treasury.BankAccounts.Commands.CreateBankAccount;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;
using MediatR;

public record CreateBankAccountCommand(
    string Name,
    string? Iban = null,
    string Currency = "IRR",
    Guid? ControlAccountId = null,
    string BusinessId = "default"
) : IRequest<Guid>;

public class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateBankAccountCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = new BankAccount
        {
            Id = Guid.NewGuid(),
            AccountName = request.Name,
            Iban = request.Iban,
            Currency = request.Currency,
            ControlAccountId = request.ControlAccountId,
            BusinessId = request.BusinessId,
            IsActive = true
        };

        _db.BankAccounts.Add(bankAccount);
        await _db.SaveChangesAsync(cancellationToken);
        return bankAccount.Id;
    }
}
