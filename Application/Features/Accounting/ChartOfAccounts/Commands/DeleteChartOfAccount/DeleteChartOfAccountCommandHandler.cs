using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.DeleteChartOfAccount;

/// <summary>
/// مدیریت‌کننده دستور حذف حساب کل
/// </summary>
public sealed class DeleteChartOfAccountCommandHandler : IRequestHandler<DeleteChartOfAccountCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف حساب کل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteChartOfAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف حساب کل
    /// </summary>
    public async Task<bool> Handle(DeleteChartOfAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _context.ChartOfAccounts.FirstOrDefaultAsync(ca => ca.Id == request.Id, cancellationToken);
        if (account == null)
        {
            throw new ArgumentException($"حساب کل با شناسه {request.Id} یافت نشد");
        }

        // بررسی قابلیت حذف
        if (!account.IsDeletable)
        {
            throw new InvalidOperationException("این حساب قابل حذف نیست");
        }

        // بررسی وجود حساب‌های فرزند
        var hasChildren = await _context.ChartOfAccounts
            .AnyAsync(ca => ca.ParentAccountId == request.Id, cancellationToken);
        if (hasChildren)
        {
            throw new InvalidOperationException("امکان حذف حساب به دلیل وجود حساب‌های فرزند وجود ندارد");
        }

        // بررسی وابستگی‌ها در JournalEntries
        var hasJournalEntries = await _context.JournalEntries
            .AnyAsync(je => je.AccountId == request.Id, cancellationToken);
        if (hasJournalEntries)
        {
            throw new InvalidOperationException("امکان حذف حساب به دلیل وجود سندهای حسابداری وابسته وجود ندارد");
        }

        _context.ChartOfAccounts.Remove(account);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
