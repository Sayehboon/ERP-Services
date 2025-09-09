using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.CreateAccount;

/// <summary>
/// پردازشگر دستور ایجاد حساب
/// </summary>
public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد حساب
    /// </summary>
    /// <param name="request">درخواست ایجاد حساب</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه حساب ایجاد شده</returns>
    public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود کد حساب تکراری
        var existingAccount = await _context.ChartOfAccounts
            .FirstOrDefaultAsync(a => a.AccountCode == request.AccountCode, cancellationToken);

        if (existingAccount != null)
        {
            throw new InvalidOperationException($"حسابی با کد {request.AccountCode} قبلاً وجود دارد");
        }

        // بررسی وجود حساب والد
        if (request.ParentAccountId.HasValue)
        {
            var parentAccount = await _context.ChartOfAccounts
                .FirstOrDefaultAsync(a => a.Id == request.ParentAccountId.Value, cancellationToken);

            if (parentAccount == null)
            {
                throw new InvalidOperationException("حساب والد یافت نشد");
            }

            // سطح حساب باید یک سطح بیشتر از حساب والد باشد
            request.Level = parentAccount.Level + 1;
        }

        var account = new ChartOfAccount
        {
            Id = Guid.NewGuid(),
            AccountCode = request.AccountCode,
            AccountName = request.AccountName,
            AccountNameEn = request.AccountNameEn,
            ParentAccountId = request.ParentAccountId,
            AccountType = request.AccountType,
            Level = request.Level,
            BalanceType = request.BalanceType,
            IsActive = request.IsActive,
            IsEditable = request.IsEditable,
            IsDeletable = request.IsDeletable,
            DisplayOrder = request.DisplayOrder,
            Description = request.Description,
            CreatedByUserId = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.ChartOfAccounts.Add(account);
        await _context.SaveChangesAsync(cancellationToken);

        return account.Id;
    }
}
