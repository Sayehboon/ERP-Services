namespace Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.GetAllAccounts;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت حساب‌ها
/// Query to get accounts
/// </summary>
public record GetAllAccountsQuery(string Keyword = null) : IRequest<IReadOnlyList<AccountDto>>;

/// <summary>
/// هندلر کوئری دریافت حساب‌ها
/// Handler for GetAllAccountsQuery
/// </summary>
public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IReadOnlyList<AccountDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllAccountsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<AccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
    {
        var q = _db.Accounts.AsNoTracking().Where(a => a.IsActive);
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var k = request.Keyword.Trim();
            q = q.Where(a => a.Name.Contains(k) || a.Code.Contains(k));
        }
        return await q
            .OrderBy(a => a.Code)
            .Select(a => new AccountDto 
            { 
                Id = a.Id, 
                Code = a.Code, 
                Name = a.Name,
                IsActive = a.IsActive,
                Description = a.Description,
                ParentId = a.ParentId,
                BusinessId = a.BusinessId
            })
            .ToListAsync(cancellationToken);
    }
}


