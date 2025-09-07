using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccount;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی حساب بانکی
/// </summary>
public sealed class UpdateBankAccountCommandHandler : IRequestHandler<UpdateBankAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی حساب بانکی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateBankAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی حساب بانکی
    /// </summary>
    public async Task<Guid> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FirstOrDefaultAsync(ba => ba.Id == request.Id, cancellationToken);
        if (bankAccount == null)
        {
            throw new ArgumentException($"حساب بانکی با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی شماره حساب
        var accountNumberExists = await _context.BankAccounts
            .AnyAsync(ba => ba.AccountNumber == request.AccountNumber && ba.Id != request.Id, cancellationToken);
        if (accountNumberExists)
        {
            throw new ArgumentException($"حساب بانکی با شماره {request.AccountNumber} قبلاً وجود دارد");
        }

        bankAccount.AccountName = request.AccountName;
        bankAccount.AccountNumber = request.AccountNumber;
        bankAccount.BankName = request.BankName;
        bankAccount.BankCode = request.BankCode;
        bankAccount.AccountType = request.AccountType;
        bankAccount.Currency = request.Currency;
        bankAccount.InitialBalance = request.InitialBalance;
        bankAccount.CurrentBalance = request.CurrentBalance;
        bankAccount.BranchAddress = request.BranchAddress;
        bankAccount.BranchPhone = request.BranchPhone;
        bankAccount.AccountHolderName = request.AccountHolderName;
        bankAccount.IsActive = request.IsActive;
        bankAccount.Description = request.Description;
        bankAccount.UpdatedBy = request.UpdatedBy;
        bankAccount.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return bankAccount.Id;
    }
}
