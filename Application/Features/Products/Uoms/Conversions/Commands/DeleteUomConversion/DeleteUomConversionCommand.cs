namespace Dinawin.Erp.Application.Features.Products.Uoms.Conversions.Commands.DeleteUomConversion;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان حذف تبدیل واحد
/// Delete UOM conversion
/// </summary>
public record DeleteUomConversionCommand(Guid Id) : IRequest<bool>;

public class DeleteUomConversionCommandHandler(IApplicationDbContext db) : IRequestHandler<DeleteUomConversionCommand, bool>
{
    public async Task<bool> Handle(DeleteUomConversionCommand request, CancellationToken cancellationToken)
    {
        var c = await db.UomConversions.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (c == null) return false;
        db.UomConversions.Remove(c);
        await db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
