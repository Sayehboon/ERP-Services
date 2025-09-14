using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.DTOs;

namespace Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetAllBankAccounts;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست حساب‌های بانکی
/// </summary>
public sealed class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, IEnumerable<BankAccountDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست حساب‌های بانکی
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllBankAccountsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست حساب‌های بانکی
    /// </summary>
    public async Task<IEnumerable<BankAccountDto>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.BankAccounts.AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(ba => 
                (ba.AccountName != null && ba.AccountName.ToLower().Contains(searchTerm)) ||
                (ba.AccountNumber != null && ba.AccountNumber.ToLower().Contains(searchTerm)) ||
                (ba.BankName != null && ba.BankName.ToLower().Contains(searchTerm)) ||
                (ba.AccountHolderName != null && ba.AccountHolderName.ToLower().Contains(searchTerm)) ||
                (ba.Description != null && ba.Description.ToLower().Contains(searchTerm)));
        }

        if (!string.IsNullOrWhiteSpace(request.BankName))
        {
            query = query.Where(ba => ba.BankName == request.BankName);
        }

        if (!string.IsNullOrWhiteSpace(request.AccountType))
        {
            query = query.Where(ba => ba.AccountType == request.AccountType);
        }

        if (!string.IsNullOrWhiteSpace(request.Currency))
        {
            query = query.Where(ba => ba.Currency == request.Currency);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(ba => ba.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(ba => ba.BankName)
                    .ThenBy(ba => ba.AccountName);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var bankAccounts = await query.ToListAsync(cancellationToken);

        return bankAccounts.Select(ba => new BankAccountDto
        {
            Id = ba.Id,
            AccountName = ba.AccountName,
            AccountNumber = ba.AccountNumber,
            BankName = ba.BankName,
            BankCode = ba.BankCode,
            AccountType = ba.AccountType,
            Currency = ba.Currency,
            InitialBalance = ba.InitialBalance,
            CurrentBalance = ba.CurrentBalance,
            BranchAddress = ba.BranchAddress,
            BranchPhone = ba.BranchPhone,
            AccountHolderName = ba.AccountHolderName,
            IsActive = ba.IsActive,
            Description = ba.Description,
            CreatedAt = ba.CreatedAt,
            UpdatedAt = ba.UpdatedAt,
            CreatedBy = ba.CreatedBy,
            UpdatedBy = ba.UpdatedBy
        });
    }
}
