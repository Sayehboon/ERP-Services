using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.CreateBankAccount;

/// <summary>
/// مدیریت‌کننده دستور ایجاد حساب بانکی جدید
/// </summary>
public sealed class CreateBankAccountCommandHandler : IRequestHandler<CreateBankAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد حساب بانکی جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateBankAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد حساب بانکی جدید
    /// </summary>
    public async Task<Guid> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی شماره حساب
        var accountNumberExists = await _context.BankAccounts
            .AnyAsync(ba => ba.AccountNumber == request.AccountNumber, cancellationToken);
        if (accountNumberExists)
        {
            throw new ArgumentException($"حساب بانکی با شماره {request.AccountNumber} قبلاً وجود دارد");
        }

        // بررسی یکتایی شماره شبا در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.Iban))
        {
            var ibanExists = await _context.BankAccounts
                .AnyAsync(ba => ba.Iban == request.Iban, cancellationToken);
            if (ibanExists)
            {
                throw new ArgumentException($"حساب بانکی با شماره شبا {request.Iban} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره کارت در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.CardNumber))
        {
            var cardNumberExists = await _context.BankAccounts
                .AnyAsync(ba => ba.CardNumber == request.CardNumber, cancellationToken);
            if (cardNumberExists)
            {
                throw new ArgumentException($"حساب بانکی با شماره کارت {request.CardNumber} قبلاً وجود دارد");
            }
        }

        var bankAccount = new BankAccount
        {
            Id = Guid.NewGuid(),
            BankName = request.BankName,
            AccountName = request.AccountName,
            AccountNumber = request.AccountNumber,
            AccountType = request.AccountType,
            Currency = request.Currency,
            InitialBalance = request.InitialBalance,
            CurrentBalance = request.CurrentBalance,
            BranchName = request.BranchName,
            BranchCode = request.BranchCode,
            BranchAddress = request.BranchAddress,
            BranchPhone = request.BranchPhone,
            CardNumber = request.CardNumber,
            Iban = request.Iban,
            IsActive = request.IsActive,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.BankAccounts.Add(bankAccount);
        await _context.SaveChangesAsync(cancellationToken);
        return bankAccount.Id;
    }
}
