namespace Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetBinsByWarehouse;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetBinsByWarehouseQuery(Guid? WarehouseId = null) : IRequest<IReadOnlyList<BinDto>>;

public class BinDto
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; }
    public string Description { get; set; }
    public string Aisle { get; set; }
    public string Shelf { get; set; }
    public bool IsActive { get; set; }
}

public class GetBinsByWarehouseQueryHandler : IRequestHandler<GetBinsByWarehouseQuery, IReadOnlyList<BinDto>>
{
    private readonly IApplicationDbContext _db;
    public GetBinsByWarehouseQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<BinDto>> Handle(GetBinsByWarehouseQuery request, CancellationToken cancellationToken)
    {
        var query = _db.Bins.AsNoTracking().Where(b => b.IsActive);
        
        if (request.WarehouseId.HasValue)
            query = query.Where(b => b.WarehouseId == request.WarehouseId.Value);
            
        return await query
            .OrderBy(b => b.Code)
                                   .Select(b => new BinDto
                       {
                           Id = b.Id,
                           Code = b.Code,
                           Name = b.Name,
                           Description = b.Description,
                           Aisle = b.Aisle,
                           Shelf = b.Shelf,
                           IsActive = b.IsActive
                       })
            .ToListAsync(cancellationToken);
    }
}
