using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست حساب‌های کل
/// </summary>
public sealed class GetAllChartOfAccountsQueryHandler : IRequestHandler<GetAllChartOfAccountsQuery, IEnumerable<ChartOfAccountDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست حساب‌های کل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllChartOfAccountsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست حساب‌های کل
    /// </summary>
    public async Task<IEnumerable<ChartOfAccountDto>> Handle(GetAllChartOfAccountsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.ChartOfAccounts
            .Include(ca => ca.ParentAccount)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(ca => 
                ca.AccountCode.ToLower().Contains(searchTerm) ||
                ca.AccountName.ToLower().Contains(searchTerm) ||
                (ca.Description != null && ca.Description.ToLower().Contains(searchTerm)));
        }

        if (request.ParentAccountId.HasValue)
        {
            query = query.Where(ca => ca.ParentAccountId == request.ParentAccountId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.AccountType))
        {
            query = query.Where(ca => ca.AccountType == request.AccountType);
        }

        if (!string.IsNullOrWhiteSpace(request.AccountCategory))
        {
            query = query.Where(ca => ca.AccountCategory == request.AccountCategory);
        }

        if (request.Level.HasValue)
        {
            query = query.Where(ca => ca.Level == request.Level.Value);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(ca => ca.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(ca => ca.AccountCode);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var accounts = await query.ToListAsync(cancellationToken);

        // محاسبه تعداد فرزندان برای هر حساب
        var accountIds = accounts.Select(a => a.Id).ToList();
        var childrenCounts = await _context.ChartOfAccounts
            .Where(ca => ca.ParentAccountId.HasValue && accountIds.Contains(ca.ParentAccountId.Value))
            .GroupBy(ca => ca.ParentAccountId)
            .ToDictionaryAsync(g => g.Key!.Value, g => g.Count(), cancellationToken);

        return accounts.Select(account => new ChartOfAccountDto
        {
            Id = account.Id,
            AccountCode = account.AccountCode,
            AccountName = account.AccountName,
            ParentAccountId = account.ParentAccountId,
            ParentAccountName = account.ParentAccount?.AccountName,
            AccountType = account.AccountType,
            AccountCategory = account.AccountCategory,
            Level = account.Level,
            IsActive = account.IsActive,
            IsEditable = account.IsEditable,
            IsDeletable = account.IsDeletable,
            Description = account.Description,
            CreatedAt = account.CreatedAt,
            UpdatedAt = account.UpdatedAt,
            CreatedBy = account.CreatedBy,
            UpdatedBy = account.UpdatedBy,
            ChildrenCount = childrenCounts.GetValueOrDefault(account.Id, 0)
        });
    }
}
