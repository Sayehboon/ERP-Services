using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Commands.DeleteOpportunity;

/// <summary>
/// مدیریت‌کننده دستور حذف فرصت
/// </summary>
public sealed class DeleteOpportunityCommandHandler : IRequestHandler<DeleteOpportunityCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف فرصت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteOpportunityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف فرصت
    /// </summary>
    public async Task<bool> Handle(DeleteOpportunityCommand request, CancellationToken cancellationToken)
    {
        var opportunity = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        if (opportunity == null)
        {
            throw new ArgumentException($"فرصت با شناسه {request.Id} یافت نشد");
        }

        // بررسی تبدیل شدن فرصت به سفارش فروش
        var hasSalesOrders = await _context.SalesOrders.AnyAsync(so => so.OpportunityId == request.Id, cancellationToken);
        if (hasSalesOrders)
        {
            throw new InvalidOperationException("امکان حذف فرصت وجود ندارد زیرا به سفارش فروش تبدیل شده است");
        }

        _context.Opportunities.Remove(opportunity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
