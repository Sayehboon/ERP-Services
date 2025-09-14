namespace Dinawin.Erp.Application.Features.Products.Uoms.Queries.GetAllUoms;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DTO واحد
/// UOM DTO
/// </summary>
public class UomDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
}

/// <summary>
/// کوئری لیست واحدها
/// Query get all uoms
/// </summary>
public record GetAllUomsQuery(string Type = null) : IRequest<IReadOnlyList<UomDto>>;

/// <summary>
/// هندلر دریافت واحدها
/// Handler
/// </summary>
public class GetAllUomsQueryHandler : IRequestHandler<GetAllUomsQuery, IReadOnlyList<UomDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllUomsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<UomDto>> Handle(GetAllUomsQuery request, CancellationToken cancellationToken)
    {
        var q = _db.UnitsOfMeasures.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(request.Type))
            q = q.Where(u => u.Type.ToString().ToLower() == (request.Type ?? string.Empty).ToLower());
        return await q.OrderBy(u => u.Name)
            .Select(u => new UomDto { Id = u.Id, Name = u.Name, Symbol = u.Symbol, Type = u.Type.ToString() })
            .ToListAsync(cancellationToken);
    }
}


