namespace Dinawin.Erp.Application.Features.Products.Uoms.Commands.UpsertUom;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ایجاد/ویرایش واحد
/// Command to create or update UOM
/// </summary>
public record UpsertUomCommand(Guid? Id, string Code, string Name, string Type, int Precision, bool IsActive) : IRequest<Guid>;

/// <summary>
/// هندلر ایجاد/ویرایش واحد
/// Handler
/// </summary>
public class UpsertUomCommandHandler(IApplicationDbContext db) : IRequestHandler<UpsertUomCommand, Guid>
{
    public async Task<Guid> Handle(UpsertUomCommand request, CancellationToken cancellationToken)
    {
        UnitType type = Enum.TryParse<UnitType>(request.Type, true, out var t) ? t : UnitType.Count;
        if (request.Id.HasValue)
        {
            var u = await db.UnitsOfMeasure.FirstOrDefaultAsync(x => x.Id == request.Id.Value, cancellationToken);
            if (u == null) throw new KeyNotFoundException("UOM not found");
            u.Code = request.Code; u.Name = request.Name; u.Type = type; u.Precision = request.Precision; u.IsActive = request.IsActive;
            await db.SaveChangesAsync(cancellationToken);
            return u.Id;
        }
        else
        {
            var u = new UnitOfMeasure
            {
                Id = Guid.NewGuid(),
                Code = request.Code,
                Name = request.Name,
                Type = type,
                Precision = request.Precision,
                IsActive = request.IsActive
            };
            db.UnitsOfMeasures.Add(u);
            await db.SaveChangesAsync(cancellationToken);
            return u.Id;
        }
    }
}


