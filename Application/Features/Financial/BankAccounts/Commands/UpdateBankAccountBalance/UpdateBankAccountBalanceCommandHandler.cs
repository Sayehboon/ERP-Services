using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccountBalance;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی موجودی حساب بانکی
/// </summary>
public sealed class UpdateBankAccountBalanceCommandHandler : IRequestHandler<UpdateBankAccountBalanceCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی موجودی حساب بانکی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateBankAccountBalanceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی موجودی حساب بانکی
    /// </summary>
    public async Task<bool> Handle(UpdateBankAccountBalanceCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FirstOrDefaultAsync(ba => ba.Id == request.Id, cancellationToken);
        if (bankAccount == null)
        {
            throw new ArgumentException($"حساب بانکی با شناسه {request.Id} یافت نشد");
        }

        // بررسی اعتبار موجودی جدید
        if (request.NewBalance < 0)
        {
            throw new ArgumentException("موجودی حساب نمی‌تواند منفی باشد");
        }

        // محاسبه تغییر موجودی
        var balanceChange = request.NewBalance - bankAccount.CurrentBalance;

        // به‌روزرسانی موجودی
        bankAccount.CurrentBalance = request.NewBalance;
        bankAccount.UpdatedBy = request.UpdatedBy;
        bankAccount.UpdatedAt = DateTime.UtcNow;

        // ثبت تراکنش در صورت وجود تغییر
        if (balanceChange != 0)
        {
            var cashTransaction = new CashTransaction
            {
                Id = Guid.NewGuid(),
                BankAccountId = request.Id,
                TransactionType = request.TransactionType,
                Amount = new Domain.ValueObjects.Money(Math.Abs(balanceChange), "IRR"),
                Description = request.TransactionDescription ?? $"به‌روزرسانی موجودی حساب {bankAccount.AccountName}",
                ReferenceId = request.ReferenceId,
                ReferenceType = request.ReferenceType,
                TransactionDate = DateTime.UtcNow,
                CreatedBy = request.UpdatedBy,
                CreatedAt = DateTime.UtcNow
            };

            _context.CashTransactions.Add(cashTransaction);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
