namespace Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Queries.GetConversions;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// DTO تبدیل واحد
/// UOM conversion DTO
/// </summary>
public class UomConversionDto
{
    public Guid Id { get; set; }
    public Guid FromUomId { get; set; }
    public Guid ToUomId { get; set; }
    public decimal Factor { get; set; }
}

/// <summary>
/// کوئری دریافت تبدیل‌ها
/// Query
/// </summary>
public record GetUomConversionsQuery : IRequest<IReadOnlyList<UomConversionDto>>;

/// <summary>
/// هندلر دریافت تبدیل‌ها
/// Handler
/// </summary>
public class GetUomConversionsQueryHandler(IApplicationDbContext db) : IRequestHandler<GetUomConversionsQuery, IReadOnlyList<UomConversionDto>>
{
    public async Task<IReadOnlyList<UomConversionDto>> Handle(GetUomConversionsQuery request, CancellationToken cancellationToken)
    {
        return await db.UomConversions.AsNoTracking()
            .Select(c => new UomConversionDto
            {
                Id = c.Id,
                FromUomId = c.FromUomId,
                ToUomId = c.ToUomId,
                Factor = c.ConversionFactor
            })
            .ToListAsync(cancellationToken);
    }
}


