using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Commands.UpdateOpportunity;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی فرصت
/// </summary>
public sealed class UpdateOpportunityCommandHandler : IRequestHandler<UpdateOpportunityCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی فرصت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateOpportunityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی فرصت
    /// </summary>
    public async Task<Guid> Handle(UpdateOpportunityCommand request, CancellationToken cancellationToken)
    {
        var opportunity = await _context.Opportunities.FirstOrDefaultAsync(o => o.Id == request.Id, cancellationToken);
        if (opportunity == null)
        {
            throw new ArgumentException($"فرصت با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود لید
        if (request.LeadId.HasValue)
        {
            var leadExists = await _context.Leads
                .AnyAsync(l => l.Id == request.LeadId.Value, cancellationToken);
            if (!leadExists)
            {
                throw new ArgumentException($"لید با شناسه {request.LeadId} یافت نشد");
            }
        }

        // بررسی وجود مشتری
        if (request.CustomerId.HasValue)
        {
            var customerExists = await _context.Customers
                .AnyAsync(c => c.Id == request.CustomerId.Value, cancellationToken);
            if (!customerExists)
            {
                throw new ArgumentException($"مشتری با شناسه {request.CustomerId} یافت نشد");
            }
        }

        // بررسی وجود حساب
        if (request.AccountId.HasValue)
        {
            var accountExists = await _context.Accounts
                .AnyAsync(a => a.Id == request.AccountId.Value, cancellationToken);
            if (!accountExists)
            {
                throw new ArgumentException($"حساب با شناسه {request.AccountId} یافت نشد");
            }
        }

        // بررسی وجود کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToId.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.AssignedToId} یافت نشد");
            }
        }

        opportunity.Name = request.Name;
        opportunity.LeadId = request.LeadId;
        opportunity.CustomerId = request.CustomerId;
        opportunity.AccountId = request.AccountId;
        opportunity.Stage = request.Stage;
        opportunity.Status = request.Status;
        opportunity.Probability = request.Probability;
        opportunity.Amount = request.Amount;
        opportunity.Currency = request.Currency;
        opportunity.ExpectedCloseDate = request.ExpectedCloseDate;
        opportunity.ActualCloseDate = request.ActualCloseDate;
        opportunity.OpportunityType = request.OpportunityType;
        opportunity.Source = request.Source;
        opportunity.AssignedTo = request.AssignedToId;
        opportunity.Priority = request.Priority;
        opportunity.Notes = request.Notes;
        opportunity.UpdatedBy = request.UpdatedBy;
        opportunity.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return opportunity.Id;
    }
}
