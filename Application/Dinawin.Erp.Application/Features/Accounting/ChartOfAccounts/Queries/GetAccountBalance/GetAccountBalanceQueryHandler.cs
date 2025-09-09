using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAccountBalance;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت مانده حساب
/// </summary>
public sealed class GetAccountBalanceQueryHandler : IRequestHandler<GetAccountBalanceQuery, AccountBalanceDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت مانده حساب
    /// </summary>
    public GetAccountBalanceQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت مانده حساب
    /// </summary>
    public async Task<AccountBalanceDto?> Handle(GetAccountBalanceQuery request, CancellationToken cancellationToken)
    {
        // دریافت اطلاعات حساب
        var account = await _context.ChartOfAccounts
            .FirstOrDefaultAsync(a => a.Id == request.AccountId, cancellationToken);

        if (account == null)
        {
            return null;
        }

        // دریافت لیست حساب‌های مورد نظر (شامل فرزندان در صورت نیاز)
        var accountIds = new List<Guid> { request.AccountId };
        
        if (request.IncludeChildren)
        {
            var childAccountIds = await GetChildAccountIds(request.AccountId, cancellationToken);
            accountIds.AddRange(childAccountIds);
        }

        // محاسبه مانده حساب
        var balance = await CalculateAccountBalance(accountIds, request.FromDate, request.ToDate, cancellationToken);

        // ایجاد DTO
        var balanceDto = new AccountBalanceDto
        {
            AccountId = account.Id,
            AccountCode = account.AccountCode,
            AccountName = account.AccountName,
            AccountType = account.AccountType,
            AccountCategory = account.AccountCategory,
            DebitBalance = balance.DebitBalance,
            CreditBalance = balance.CreditBalance,
            NetBalance = balance.NetBalance,
            BalanceType = balance.NetBalance >= 0 ? "بدهکار" : "بستانکار",
            Currency = account.Currency,
            ExchangeRate = account.ExchangeRate,
            BalanceInBaseCurrency = balance.BalanceInBaseCurrency,
            FromDate = request.FromDate,
            ToDate = request.ToDate,
            TransactionCount = balance.TransactionCount,
            TotalDebit = balance.TotalDebit,
            TotalCredit = balance.TotalCredit,
            OpeningBalance = balance.OpeningBalance,
            ClosingBalance = balance.ClosingBalance,
            IncludesChildren = request.IncludeChildren,
            ChildrenCount = request.IncludeChildren ? accountIds.Count - 1 : 0,
            LastTransactionDate = balance.LastTransactionDate,
            CalculatedAt = DateTime.UtcNow
        };

        // دریافت مانده‌های حساب‌های فرزند در صورت نیاز
        if (request.IncludeChildren)
        {
            var childBalances = new List<AccountBalanceDto>();
            
            foreach (var childId in accountIds.Skip(1))
            {
                var childAccount = await _context.ChartOfAccounts
                    .FirstOrDefaultAsync(a => a.Id == childId, cancellationToken);
                
                if (childAccount != null)
                {
                    var childBalance = await CalculateAccountBalance(new List<Guid> { childId }, 
                        request.FromDate, request.ToDate, cancellationToken);
                    
                    childBalances.Add(new AccountBalanceDto
                    {
                        AccountId = childAccount.Id,
                        AccountCode = childAccount.AccountCode,
                        AccountName = childAccount.AccountName,
                        AccountType = childAccount.AccountType,
                        AccountCategory = childAccount.AccountCategory,
                        DebitBalance = childBalance.DebitBalance,
                        CreditBalance = childBalance.CreditBalance,
                        NetBalance = childBalance.NetBalance,
                        BalanceType = childBalance.NetBalance >= 0 ? "بدهکار" : "بستانکار",
                        Currency = childAccount.Currency,
                        ExchangeRate = childAccount.ExchangeRate,
                        BalanceInBaseCurrency = childBalance.BalanceInBaseCurrency,
                        TransactionCount = childBalance.TransactionCount,
                        TotalDebit = childBalance.TotalDebit,
                        TotalCredit = childBalance.TotalCredit,
                        OpeningBalance = childBalance.OpeningBalance,
                        ClosingBalance = childBalance.ClosingBalance,
                        LastTransactionDate = childBalance.LastTransactionDate,
                        CalculatedAt = DateTime.UtcNow
                    });
                }
            }
            
            balanceDto.ChildrenBalances = childBalances;
        }

        return balanceDto;
    }

    /// <summary>
    /// دریافت شناسه‌های حساب‌های فرزند
    /// </summary>
    private async Task<List<Guid>> GetChildAccountIds(Guid parentId, CancellationToken cancellationToken)
    {
        var childIds = new List<Guid>();
        var directChildren = await _context.ChartOfAccounts
            .Where(a => a.ParentAccountId == parentId)
            .Select(a => a.Id)
            .ToListAsync(cancellationToken);

        childIds.AddRange(directChildren);

        // دریافت فرزندان به صورت بازگشتی
        foreach (var childId in directChildren)
        {
            var grandChildren = await GetChildAccountIds(childId, cancellationToken);
            childIds.AddRange(grandChildren);
        }

        return childIds;
    }

    /// <summary>
    /// محاسبه مانده حساب
    /// </summary>
    private async Task<AccountBalanceInfo> CalculateAccountBalance(List<Guid> accountIds, 
        DateTime? fromDate, DateTime? toDate, CancellationToken cancellationToken)
    {
        var query = _context.GeneralLedgerEntries
            .Where(gl => accountIds.Contains(gl.AccountId));

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
                .Where(gl => accountIds.Contains(gl.AccountId) && gl.TransactionDate < fromDate.Value)
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
            BalanceInBaseCurrency = netBalance, // در صورت نیاز می‌توان نرخ ارز را اعمال کرد
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
        public decimal? BalanceInBaseCurrency { get; set; }
        public int TransactionCount { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal ClosingBalance { get; set; }
        public DateTime? LastTransactionDate { get; set; }
    }
}
