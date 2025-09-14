using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetTrialBalance;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تراز آزمایشی
/// </summary>
public sealed class GetTrialBalanceQueryHandler : IRequestHandler<GetTrialBalanceQuery, TrialBalanceDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تراز آزمایشی
    /// </summary>
    public GetTrialBalanceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت تراز آزمایشی
    /// </summary>
    public async Task<TrialBalanceDto> Handle(GetTrialBalanceQuery request, CancellationToken cancellationToken)
    {
        // دریافت حساب‌ها
        var accountsQuery = _context.ChartOfAccounts.AsQueryable();

        // فیلتر بر اساس نوع حساب
        if (request.AccountType.HasValue)
        {
            accountsQuery = accountsQuery.Where(a => a.AccountType == request.AccountType.Value);
        }

        // فیلتر بر اساس دسته‌بندی حساب
        if (!string.IsNullOrEmpty(request.AccountCategory))
        {
            accountsQuery = accountsQuery.Where(a => a.AccountCategory == request.AccountCategory);
        }

        // فیلتر بر اساس سطح حساب
        if (request.Level.HasValue)
        {
            accountsQuery = accountsQuery.Where(a => a.Level == request.Level.Value);
        }

        // فیلتر بر اساس وضعیت فعال
        if (!request.IncludeInactiveAccounts)
        {
            accountsQuery = accountsQuery.Where(a => a.IsActive);
        }

        var accounts = await accountsQuery
            .OrderBy(a => a.AccountCode)
            .ToListAsync(cancellationToken);

        var trialBalanceItems = new List<TrialBalanceItemDto>();
        decimal totalDebit = 0;
        decimal totalCredit = 0;

        foreach (var account in accounts)
        {
            // محاسبه مانده حساب
            var balance = await CalculateAccountBalance(account.Id, request.FromDate, request.ToDate, cancellationToken);

            // فیلتر بر اساس مانده غیر صفر
            if (request.OnlyNonZeroBalances && balance.NetBalance == 0)
            {
                continue;
            }

            var item = new TrialBalanceItemDto
            {
                AccountId = account.Id,
                AccountCode = account.AccountCode,
                AccountName = account.AccountName,
                AccountType = account.AccountType,
                AccountCategory = account.AccountCategory ?? string.Empty,
                Level = account.Level,
                DebitBalance = balance.DebitBalance,
                CreditBalance = balance.CreditBalance,
                NetBalance = balance.NetBalance,
                BalanceType = balance.NetBalance >= 0 ? "بدهکار" : "بستانکار",
                TransactionCount = balance.TransactionCount,
                TotalDebit = balance.TotalDebit,
                TotalCredit = balance.TotalCredit,
                OpeningBalance = balance.OpeningBalance,
                ClosingBalance = balance.ClosingBalance,
                LastTransactionDate = balance.LastTransactionDate,
                IsActive = account.IsActive
            };

            trialBalanceItems.Add(item);

            // محاسبه مجموع‌ها
            totalDebit += balance.DebitBalance;
            totalCredit += balance.CreditBalance;
        }

        // ایجاد خلاصه بر اساس نوع حساب
        var summaryByType = trialBalanceItems
            .GroupBy(item => item.AccountType)
            .Select(group => new TrialBalanceSummaryDto
            {
                GroupName = group.Key.ToString(),
                AccountCount = group.Count(),
                TotalDebit = group.Sum(item => item.DebitBalance),
                TotalCredit = group.Sum(item => item.CreditBalance),
                NetBalance = group.Sum(item => item.NetBalance),
                BalanceType = group.Sum(item => item.NetBalance) >= 0 ? "بدهکار" : "بستانکار"
            })
            .OrderBy(s => s.GroupName)
            .ToList();

        // ایجاد خلاصه بر اساس دسته‌بندی حساب
        var summaryByCategory = trialBalanceItems
            .GroupBy(item => item.AccountCategory)
            .Select(group => new TrialBalanceSummaryDto
            {
                GroupName = group.Key.ToString(),
                AccountCount = group.Count(),
                TotalDebit = group.Sum(item => item.DebitBalance),
                TotalCredit = group.Sum(item => item.CreditBalance),
                NetBalance = group.Sum(item => item.NetBalance),
                BalanceType = group.Sum(item => item.NetBalance) >= 0 ? "بدهکار" : "بستانکار"
            })
            .OrderBy(s => s.GroupName)
            .ToList();

        var trialBalance = new TrialBalanceDto
        {
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            GeneratedAt = DateTime.UtcNow,
            Currency = "IRR",
            TotalAccounts = accounts.Count,
            NonZeroBalanceAccounts = trialBalanceItems.Count,
            TotalDebit = totalDebit,
            TotalCredit = totalCredit,
            Items = trialBalanceItems,
            SummaryByType = summaryByType,
            SummaryByCategory = summaryByCategory
        };

        return trialBalance;
    }

    /// <summary>
    /// محاسبه مانده حساب
    /// </summary>
    private async Task<AccountBalanceInfo> CalculateAccountBalance(Guid accountId, 
        DateTime? fromDate, DateTime? toDate, CancellationToken cancellationToken)
    {
        var query = _context.GeneralLedgerEntries
            .Where(gl => gl.AccountId == accountId);

        // فیلتر بر اساس تاریخ
        if (fromDate.HasValue)
            query = query.Where(gl => gl.TransactionDate >= fromDate.Value);
        if (toDate.HasValue)
            query = query.Where(gl => gl.TransactionDate <= toDate.Value);

        var entries = await query.ToListAsync(cancellationToken);

        var totalDebit = entries.Sum(e => e.DebitAmount);
        var totalCredit = entries.Sum(e => e.CreditAmount);
        var netBalance = totalDebit - totalCredit;
        var transactionCount = entries.Count;
        var lastTransactionDate = entries.Any() ? entries.Max(e => e.TransactionDate) : (DateTime?)null;

        // محاسبه مانده اولیه (قبل از دوره)
        var openingBalance = 0m;
        if (fromDate.HasValue)
        {
            var openingEntries = await _context.GeneralLedgerEntries
                .Where(gl => gl.AccountId == accountId && gl.TransactionDate < fromDate.Value)
                .ToListAsync(cancellationToken);
            
            openingBalance = openingEntries.Sum(e => e.DebitAmount) - openingEntries.Sum(e => e.CreditAmount);
        }

        // محاسبه مانده نهایی
        var closingBalance = openingBalance + netBalance;

        return new AccountBalanceInfo
        {
            DebitBalance = totalDebit,
            CreditBalance = totalCredit,
            NetBalance = netBalance,
            TransactionCount = transactionCount,
            TotalDebit = totalDebit,
            TotalCredit = totalCredit,
            OpeningBalance = openingBalance,
            ClosingBalance = closingBalance,
            LastTransactionDate = lastTransactionDate
        };
    }

    /// <summary>
    /// اطلاعات مانده حساب
    /// </summary>
    private class AccountBalanceInfo
    {
        public decimal DebitBalance { get; set; }
        public decimal CreditBalance { get; set; }
        public decimal NetBalance { get; set; }
        public int TransactionCount { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public DateTime? LastTransactionDate { get; set; }
    }
}
