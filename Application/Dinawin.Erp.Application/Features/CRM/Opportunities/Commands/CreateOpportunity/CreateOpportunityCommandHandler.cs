using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Commands.CreateOpportunity;

/// <summary>
/// مدیریت‌کننده دستور ایجاد فرصت
/// </summary>
public sealed class CreateOpportunityCommandHandler : IRequestHandler<CreateOpportunityCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد فرصت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateOpportunityCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد فرصت
    /// </summary>
    public async Task<Guid> Handle(CreateOpportunityCommand request, CancellationToken cancellationToken)
    {
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

        var opportunity = new Opportunity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LeadId = request.LeadId,
            CustomerId = request.CustomerId,
            AccountId = request.AccountId,
            Stage = request.Stage,
            Status = request.Status,
            Probability = request.Probability,
            Amount = request.Amount,
            Currency = request.Currency,
            ExpectedCloseDate = request.ExpectedCloseDate,
            ActualCloseDate = request.ActualCloseDate,
            OpportunityType = request.OpportunityType,
            Source = request.Source,
            AssignedToId = request.AssignedToId,
            Priority = request.Priority,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Opportunities.Add(opportunity);
        await _context.SaveChangesAsync(cancellationToken);
        return opportunity.Id;
    }
}
