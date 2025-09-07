using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetBankAccountById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت حساب بانکی بر اساس شناسه
/// </summary>
public sealed class GetBankAccountByIdQueryHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccountDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت حساب بانکی بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetBankAccountByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت حساب بانکی بر اساس شناسه
    /// </summary>
    public async Task<BankAccountDto?> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
    {
        var bankAccount = await _context.BankAccounts
            .FirstOrDefaultAsync(ba => ba.Id == request.Id, cancellationToken);

        if (bankAccount == null)
        {
            return null;
        }

        return new BankAccountDto
        {
            Id = bankAccount.Id,
            AccountName = bankAccount.AccountName,
            AccountNumber = bankAccount.AccountNumber,
            BankName = bankAccount.BankName,
            BankCode = bankAccount.BankCode,
            AccountType = bankAccount.AccountType,
            Currency = bankAccount.Currency,
            InitialBalance = bankAccount.InitialBalance,
            CurrentBalance = bankAccount.CurrentBalance,
            BranchAddress = bankAccount.BranchAddress,
            BranchPhone = bankAccount.BranchPhone,
            AccountHolderName = bankAccount.AccountHolderName,
            IsActive = bankAccount.IsActive,
            Description = bankAccount.Description,
            CreatedAt = bankAccount.CreatedAt,
            UpdatedAt = bankAccount.UpdatedAt,
            CreatedBy = bankAccount.CreatedBy,
            UpdatedBy = bankAccount.UpdatedBy
        };
    }
}
