namespace Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.PostCashTransaction;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record PostCashTransactionCommand(Guid Id) : IRequest<bool>;

public class PostCashTransactionCommandHandler : IRequestHandler<PostCashTransactionCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public PostCashTransactionCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(PostCashTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = await _db.CashTransactions.FirstOrDefaultAsync(ct => ct.Id == request.Id, cancellationToken);
        if (transaction == null) return false;

        transaction.Status = CashTransactionStatus.Posted;
        transaction.IsPosted = true;

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
