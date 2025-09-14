namespace Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.GetCashTransactionsByCashBoxes;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetCashTransactionsByCashBoxesQuery(Guid[] CashBoxIds) : IRequest<IReadOnlyList<CashTransactionDto>>;

public class GetCashTransactionsByCashBoxesQueryHandler : IRequestHandler<GetCashTransactionsByCashBoxesQuery, IReadOnlyList<CashTransactionDto>>
{
    private readonly IApplicationDbContext _db;
    public GetCashTransactionsByCashBoxesQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<CashTransactionDto>> Handle(GetCashTransactionsByCashBoxesQuery request, CancellationToken cancellationToken)
    {
        return await _db.CashTransactions.AsNoTracking()
            .Where(ct => request.CashBoxIds.Contains(ct.CashBoxId))
            .Include(ct => ct.CashBox)
            .OrderByDescending(ct => ct.TransactionDate)
            .ThenByDescending(ct => ct.CreatedAt)
            .Select(ct => new CashTransactionDto
            {
                Id = ct.Id,
                CashBoxId = ct.CashBoxId,
                CashBoxName = ct.CashBox.Name,
                TransactionDate = ct.TransactionDate,
                Type = ct.Type.ToString(),
                Amount = ct.Amount.Amount,
                Currency = ct.Amount.Currency,
                Description = ct.Description,
                Status = ct.Status.ToString(),
                IsPosted = ct.IsPosted,
                CreatedAt = ct.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}
