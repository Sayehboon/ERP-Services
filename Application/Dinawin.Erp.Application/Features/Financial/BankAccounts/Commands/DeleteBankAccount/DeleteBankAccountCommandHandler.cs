using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.DeleteBankAccount;

/// <summary>
/// مدیریت‌کننده دستور حذف حساب بانکی
/// </summary>
public sealed class DeleteBankAccountCommandHandler : IRequestHandler<DeleteBankAccountCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف حساب بانکی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteBankAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف حساب بانکی
    /// </summary>
    public async Task<bool> Handle(DeleteBankAccountCommand request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts.FirstOrDefaultAsync(ba => ba.Id == request.Id, cancellationToken);
        if (bankAccount == null)
        {
            throw new ArgumentException($"حساب بانکی با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasTransactions = await _context.CashTransactions
            .AnyAsync(ct => ct.BankAccountId == request.Id, cancellationToken);
        
        if (hasTransactions)
        {
            throw new InvalidOperationException("امکان حذف حساب بانکی به دلیل وجود تراکنش‌های وابسته وجود ندارد");
        }

        _context.BankAccounts.Remove(bankAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
