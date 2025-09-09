namespace Dinawin.Erp.Application.Features.Treasury.BankAccounts.Commands.UpdateBankAccount;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateBankAccountCommand(
    Guid Id,
    string? Name = null,
    string? Iban = null,
    string? Currency = null,
    Guid? ControlAccountId = null
) : IRequest<bool>;

public class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateBankAccountCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _db.BankAccounts.FirstOrDefaultAsync(ba => ba.Id == request.Id, cancellationToken);
        if (bankAccount == null) return false;

        if (request.Name != null) bankAccount.AccountName = request.Name;
        if (request.Iban != null) bankAccount.Iban = request.Iban;
        if (request.Currency != null) bankAccount.Currency = request.Currency;
        if (request.ControlAccountId != null) bankAccount.ControlAccountId = request.ControlAccountId;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
