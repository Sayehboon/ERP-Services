namespace Dinawin.Erp.Application.Features.Accounting.Vendors.Queries.GetAllVendors;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAllVendorsQuery(string? Keyword = null) : IRequest<IReadOnlyList<VendorDto>>;

public class VendorDto { public Guid Id { get; set; } public string Code { get; set; } = string.Empty; public string Name { get; set; } = string.Empty; }

public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, IReadOnlyList<VendorDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllVendorsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<VendorDto>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        var q = _db.Vendors.AsNoTracking().Where(v => v.IsActive);
        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            var k = request.Keyword.Trim();
            q = q.Where(v => v.Name.Contains(k) || v.Code.Contains(k));
        }
        return await q.OrderBy(v => v.Name)
            .Select(v => new VendorDto { Id = v.Id, Code = v.Code, Name = v.Name })
            .ToListAsync(cancellationToken);
    }
}


