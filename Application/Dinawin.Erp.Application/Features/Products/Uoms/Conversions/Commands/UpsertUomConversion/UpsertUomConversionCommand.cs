namespace Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.UpsertUomConversion;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ایجاد/ویرایش تبدیل واحد
/// Upsert UOM conversion
/// </summary>
public record UpsertUomConversionCommand(Guid? Id, Guid FromUomId, Guid ToUomId, decimal Factor) : IRequest<Guid>;

public class UpsertUomConversionCommandHandler(IApplicationDbContext db) : IRequestHandler<UpsertUomConversionCommand, Guid>
{
    public async Task<Guid> Handle(UpsertUomConversionCommand request, CancellationToken cancellationToken)
    {
        if (request.Id.HasValue)
        {
            var c = await db.UomConversions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (c == null) throw new KeyNotFoundException("Conversion not found");
            c.FromUomId = request.FromUomId; 
            c.ToUomId = request.ToUomId;
            c.ConversionFactor = request.Factor;
            await db.SaveChangesAsync(cancellationToken);
            return c.Id;
        }
        else
        {
            var c = new UomConversion
            {
                Id = Guid.NewGuid(),
                FromUomId = request.FromUomId,
                ToUomId = request.ToUomId,
                ConversionFactor = request.Factor
            };
            db.UomConversions.Add(c);
            await db.SaveChangesAsync(cancellationToken);
            return c.Id;
        }
    }
}
