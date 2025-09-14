namespace Dinawin.Erp.Application.Features.Accounting.Customers.Queries.GetAllCustomers;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.Customers.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت مشتریان
/// Query to get customers
/// </summary>
public record GetAllCustomersQuery(string Keyword = null) : IRequest<IReadOnlyList<CustomerDto>>;

/// <summary>
/// هندلر کوئری دریافت مشتریان
/// Handler for GetAllCustomersQuery
/// </summary>
public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IReadOnlyList<CustomerDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllCustomersQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var q = _db.Customers.AsNoTracking().Where(c => c.IsActive);
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var k = request.Keyword.Trim();
            q = q.Where(c => c.Name.Contains(k) || c.Code.Contains(k));
        }
        return await q
            .OrderBy(c => c.Name)
            .Select(c => new CustomerDto { Id = c.Id, Code = c.Code, Name = c.Name })
            .ToListAsync(cancellationToken);
    }
}


