namespace Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.GetAccountsByBusiness;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAccountsByBusinessQuery(string BusinessId = "default") : IRequest<IReadOnlyList<AccountDto>>;

public class GetAccountsByBusinessQueryHandler : IRequestHandler<GetAccountsByBusinessQuery, IReadOnlyList<AccountDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAccountsByBusinessQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<AccountDto>> Handle(GetAccountsByBusinessQuery request, CancellationToken cancellationToken)
    {
        return await _db.Accounts.AsNoTracking()
            .Where(a => a.BusinessId == request.BusinessId)
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
