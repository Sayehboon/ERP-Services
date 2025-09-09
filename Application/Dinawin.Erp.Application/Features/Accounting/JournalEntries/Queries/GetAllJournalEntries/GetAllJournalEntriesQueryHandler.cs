using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetAllJournalEntries;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست اسناد حسابداری
/// </summary>
public sealed class GetAllJournalEntriesQueryHandler : IRequestHandler<GetAllJournalEntriesQuery, IEnumerable<JournalEntryDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست اسناد حسابداری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllJournalEntriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست اسناد حسابداری
    /// </summary>
    public async Task<IEnumerable<JournalEntryDto>> Handle(GetAllJournalEntriesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.JournalEntries
            .Include(je => je.Account)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(je => 
                je.EntryNumber.ToLower().Contains(searchTerm) ||
                je.Description.ToLower().Contains(searchTerm) ||
                je.Account.Name.ToLower().Contains(searchTerm) ||
                je.Account.Code.ToLower().Contains(searchTerm) ||
                (je.Reference != null && je.Reference.ToLower().Contains(searchTerm)));
        }

        if (request.AccountId.HasValue)
        {
            query = query.Where(je => je.AccountId == request.AccountId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.EntryType))
        {
            query = query.Where(je => je.EntryType == request.EntryType);
        }

        if (request.FromDate.HasValue)
        {
            query = query.Where(je => je.EntryDate >= request.FromDate.Value);
        }

        if (request.ToDate.HasValue)
        {
            query = query.Where(je => je.EntryDate <= request.ToDate.Value);
        }

        if (request.IsApproved.HasValue)
        {
            query = query.Where(je => je.IsApproved == request.IsApproved.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.ReferenceType))
        {
            query = query.Where(je => je.ReferenceType == request.ReferenceType);
        }

        // مرتب‌سازی
        query = query.OrderByDescending(je => je.EntryDate)
                    .ThenByDescending(je => je.CreatedAt);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var entries = await query.ToListAsync(cancellationToken);

        return entries.Select(entry => new JournalEntryDto
        {
            Id = entry.Id,
            EntryNumber = entry.EntryNumber,
            EntryDate = entry.EntryDate,
            EntryType = entry.EntryType,
            Description = entry.Description,
            AccountId = entry.AccountId,
            AccountCode = entry.Account?.Code,
            AccountName = entry.Account?.Name,
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
        });
    }
}
