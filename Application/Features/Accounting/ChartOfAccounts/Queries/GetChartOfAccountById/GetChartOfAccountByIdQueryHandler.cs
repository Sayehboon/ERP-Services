using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetChartOfAccountById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت حساب کل بر اساس شناسه
/// </summary>
public sealed class GetChartOfAccountByIdQueryHandler : IRequestHandler<GetChartOfAccountByIdQuery, ChartOfAccountDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت حساب کل بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetChartOfAccountByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت حساب کل بر اساس شناسه
    /// </summary>
    public async Task<ChartOfAccountDto> Handle(GetChartOfAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var account = await _context.ChartOfAccounts
            .Include(ca => ca.ParentAccount)
            .FirstOrDefaultAsync(ca => ca.Id == request.Id, cancellationToken);

        if (account == null)
        {
            return null;
        }

        // محاسبه تعداد فرزندان
        var childrenCount = await _context.ChartOfAccounts
            .CountAsync(ca => ca.ParentAccountId == request.Id, cancellationToken);

        return new ChartOfAccountDto
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
            ChildrenCount = childrenCount
        };
    }
}
