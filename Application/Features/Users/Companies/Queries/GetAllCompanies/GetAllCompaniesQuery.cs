namespace Dinawin.Erp.Application.Features.Users.Companies.Queries.GetAllCompanies;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAllCompaniesQuery() : IRequest<IReadOnlyList<CompanyDto>>;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string TradeName { get; set; }
    public bool IsActive { get; set; }
}

public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, IReadOnlyList<CompanyDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllCompaniesQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<CompanyDto>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        return await _db.Companies.AsNoTracking()
            .Where(c => c.IsActive)
            .OrderBy(c => c.Name)
            .Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                TradeName = c.TradeName,
                IsActive = c.IsActive
            })
            .ToListAsync(cancellationToken);
    }
}
