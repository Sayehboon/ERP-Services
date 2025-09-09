using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.CreateChartOfAccount;

/// <summary>
/// پردازشگر دستور ایجاد حساب جدید
/// </summary>
public class CreateChartOfAccountCommandHandler : IRequestHandler<CreateChartOfAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateChartOfAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه حساب ایجاد شده</returns>
    public async Task<Guid> Handle(CreateChartOfAccountCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن کد حساب
        var existingAccount = await _context.ChartOfAccounts
            .FirstOrDefaultAsync(ca => ca.AccountCode == request.AccountCode, cancellationToken);

        if (existingAccount != null)
        {
            throw new InvalidOperationException($"حساب با کد {request.AccountCode} قبلاً وجود دارد");
        }

        // بررسی وجود حساب والد
        if (request.ParentAccountId.HasValue)
        {
            var parentAccount = await _context.ChartOfAccounts
                .FirstOrDefaultAsync(ca => ca.Id == request.ParentAccountId.Value, cancellationToken);

            if (parentAccount == null)
            {
                throw new InvalidOperationException($"حساب والد با شناسه {request.ParentAccountId} یافت نشد");
            }

            // بررسی سطح حساب
            if (request.Level <= parentAccount.Level)
            {
                throw new InvalidOperationException("سطح حساب فرزند باید بیشتر از حساب والد باشد");
            }
        }

        var account = new ChartOfAccount
        {
            Id = Guid.NewGuid(),
            AccountCode = request.AccountCode,
            AccountName = request.AccountName,
            AccountNameEn = request.AccountNameEn,
            ParentAccountId = request.ParentAccountId,
            AccountType = request.AccountType,
            AccountCategory = request.AccountCategory,
            Level = request.Level,
            NormalBalance = request.NormalBalance,
            IsPostable = request.IsPostable,
            IsActive = request.IsActive,
            Description = request.Description,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.ChartOfAccounts.Add(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account.Id;
    }
}
