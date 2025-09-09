namespace Dinawin.Erp.Application.Features.Treasury.BankAccounts.Queries.GetBankAccountsByBusiness;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Treasury.BankAccounts.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetBankAccountsByBusinessQuery(string BusinessId = "default") : IRequest<IReadOnlyList<BankAccountDto>>;

public class GetBankAccountsByBusinessQueryHandler : IRequestHandler<GetBankAccountsByBusinessQuery, IReadOnlyList<BankAccountDto>>
{
    private readonly IApplicationDbContext _db;
    public GetBankAccountsByBusinessQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<BankAccountDto>> Handle(GetBankAccountsByBusinessQuery request, CancellationToken cancellationToken)
    {
        return await _db.BankAccounts.AsNoTracking()
            .Where(ba => ba.BusinessId == request.BusinessId && ba.IsActive)
            .OrderBy(ba => ba.AccountName)
            .Select(ba => new BankAccountDto
            {
                Id = ba.Id,
                Name = ba.AccountName,
                Iban = ba.Iban,
                Currency = ba.Currency,
                ControlAccountId = ba.ControlAccountId,
                BusinessId = ba.BusinessId,
                IsActive = ba.IsActive,
                CreatedAt = ba.CreatedAt
            })
            .ToListAsync(cancellationToken);
    }
}
