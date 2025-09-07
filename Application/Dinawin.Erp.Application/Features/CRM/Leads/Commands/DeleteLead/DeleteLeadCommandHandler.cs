using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Commands.DeleteLead;

/// <summary>
/// مدیریت‌کننده دستور حذف لید
/// </summary>
public sealed class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف لید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteLeadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف لید
    /// </summary>
    public async Task<bool> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
        if (lead == null)
        {
            throw new ArgumentException($"لید با شناسه {request.Id} یافت نشد");
        }

        // بررسی تبدیل شدن لید به فرصت
        var hasOpportunities = await _context.Opportunities.AnyAsync(o => o.LeadId == request.Id, cancellationToken);
        if (hasOpportunities)
        {
            throw new InvalidOperationException("امکان حذف لید وجود ندارد زیرا به فرصت تبدیل شده است");
        }

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
