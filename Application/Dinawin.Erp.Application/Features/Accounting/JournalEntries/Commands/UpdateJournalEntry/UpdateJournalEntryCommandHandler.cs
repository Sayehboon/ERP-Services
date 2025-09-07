using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.UpdateJournalEntry;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی سند حسابداری
/// </summary>
public sealed class UpdateJournalEntryCommandHandler : IRequestHandler<UpdateJournalEntryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی سند حسابداری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateJournalEntryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی سند حسابداری
    /// </summary>
    public async Task<Guid> Handle(UpdateJournalEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _context.JournalEntries.FirstOrDefaultAsync(je => je.Id == request.Id, cancellationToken);
        if (entry == null)
        {
            throw new ArgumentException($"سند حسابداری با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود حساب
        var accountExists = await _context.ChartOfAccounts
            .AnyAsync(ca => ca.Id == request.AccountId, cancellationToken);
        if (!accountExists)
        {
            throw new ArgumentException($"حساب با شناسه {request.AccountId} یافت نشد");
        }

        // بررسی یکتایی شماره سند
        var numberExists = await _context.JournalEntries
            .AnyAsync(je => je.EntryNumber == request.EntryNumber && je.Id != request.Id, cancellationToken);
        if (numberExists)
        {
            throw new ArgumentException($"سند با شماره {request.EntryNumber} قبلاً وجود دارد");
        }

        // بررسی قوانین حسابداری
        if (request.DebitAmount > 0 && request.CreditAmount > 0)
        {
            throw new ArgumentException("یک سطر نمی‌تواند هم بدهکار و هم بستانکار باشد");
        }

        if (request.DebitAmount == 0 && request.CreditAmount == 0)
        {
            throw new ArgumentException("مبلغ سطر نمی‌تواند صفر باشد");
        }

        entry.EntryNumber = request.EntryNumber;
        entry.EntryDate = request.EntryDate;
        entry.EntryType = request.EntryType;
        entry.Description = request.Description;
        entry.AccountId = request.AccountId;
        entry.DebitAmount = request.DebitAmount;
        entry.CreditAmount = request.CreditAmount;
        entry.Currency = request.Currency;
        entry.ExchangeRate = request.ExchangeRate;
        entry.Reference = request.Reference;
        entry.ReferenceId = request.ReferenceId;
        entry.ReferenceType = request.ReferenceType;
        entry.IsApproved = request.IsApproved;
        entry.ApprovedAt = request.ApprovedAt;
        entry.ApprovedBy = request.ApprovedBy;
        entry.UpdatedBy = request.UpdatedBy;
        entry.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return entry.Id;
    }
}
