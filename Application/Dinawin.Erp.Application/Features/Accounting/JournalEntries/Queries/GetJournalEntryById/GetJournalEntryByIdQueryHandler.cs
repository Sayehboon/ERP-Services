using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetJournalEntryById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت سند حسابداری بر اساس شناسه
/// </summary>
public sealed class GetJournalEntryByIdQueryHandler : IRequestHandler<GetJournalEntryByIdQuery, JournalEntryDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت سند حسابداری بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetJournalEntryByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت سند حسابداری بر اساس شناسه
    /// </summary>
    public async Task<JournalEntryDto?> Handle(GetJournalEntryByIdQuery request, CancellationToken cancellationToken)
    {
        var entry = await _context.JournalEntries
            .Include(je => je.Account)
            .FirstOrDefaultAsync(je => je.Id == request.Id, cancellationToken);

        if (entry == null)
        {
            return null;
        }

        return new JournalEntryDto
        {
            Id = entry.Id,
            EntryNumber = entry.EntryNumber,
            EntryDate = entry.EntryDate,
            EntryType = entry.EntryType,
            Description = entry.Description,
            AccountId = entry.AccountId,
            AccountCode = entry.Account.Code,
            AccountName = entry.Account.Name,
            DebitAmount = entry.DebitAmount,
            CreditAmount = entry.CreditAmount,
            Currency = entry.Currency,
            ExchangeRate = entry.ExchangeRate,
            Reference = entry.Reference,
            ReferenceId = entry.ReferenceId,
            ReferenceType = entry.ReferenceType,
            IsApproved = entry.IsApproved,
            ApprovedAt = entry.ApprovedAt,
            ApprovedBy = entry.ApprovedBy,
            CreatedAt = entry.CreatedAt,
            UpdatedAt = entry.UpdatedAt,
            CreatedBy = entry.CreatedBy,
            UpdatedBy = entry.UpdatedBy
        };
    }
}
