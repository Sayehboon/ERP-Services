using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.UpdateChartOfAccount;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی حساب کل
/// </summary>
public sealed class UpdateChartOfAccountCommandHandler : IRequestHandler<UpdateChartOfAccountCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی حساب کل
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateChartOfAccountCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی حساب کل
    /// </summary>
    public async Task<Guid> Handle(UpdateChartOfAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _context.ChartOfAccounts.FirstOrDefaultAsync(ca => ca.Id == request.Id, cancellationToken);
        if (account == null)
        {
            throw new ArgumentException($"حساب کل با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی کد حساب
        var codeExists = await _context.ChartOfAccounts
            .AnyAsync(ca => ca.AccountCode == request.AccountCode && ca.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"حساب با کد {request.AccountCode} قبلاً وجود دارد");
        }

        // بررسی وجود حساب والد (در صورت ارائه)
        if (request.ParentAccountId.HasValue)
        {
            var parentExists = await _context.ChartOfAccounts
                .AnyAsync(ca => ca.Id == request.ParentAccountId.Value, cancellationToken);
            if (!parentExists)
            {
                throw new ArgumentException($"حساب والد با شناسه {request.ParentAccountId} یافت نشد");
            }

            // بررسی چرخه در سلسله مراتب
            if (await HasCircularReference(request.Id, request.ParentAccountId.Value, cancellationToken))
            {
                throw new ArgumentException("امکان ایجاد چرخه در سلسله مراتب حساب‌ها وجود ندارد");
            }
        }

        account.AccountCode = request.AccountCode;
        account.AccountName = request.AccountName;
        account.ParentAccountId = request.ParentAccountId;
        account.AccountType = request.AccountType;
        account.AccountCategory = request.AccountCategory;
        account.Level = request.Level;
        account.IsActive = request.IsActive;
        account.IsEditable = request.IsEditable;
        account.IsDeletable = request.IsDeletable;
        account.Description = request.Description;
        account.UpdatedBy = request.UpdatedBy;
        account.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return account.Id;
    }

    /// <summary>
    /// بررسی وجود چرخه در سلسله مراتب
    /// </summary>
    private async Task<bool> HasCircularReference(Guid accountId, Guid parentId, CancellationToken cancellationToken)
    {
        var currentParentId = parentId;
        var visited = new HashSet<Guid> { accountId };

        while (currentParentId != Guid.Empty)
        {
            if (visited.Contains(currentParentId))
            {
                return true; // چرخه پیدا شد
            }

            visited.Add(currentParentId);

            var parent = await _context.ChartOfAccounts
                .FirstOrDefaultAsync(ca => ca.Id == currentParentId, cancellationToken);
            
            if (parent == null)
            {
                break;
            }

            currentParentId = parent.ParentAccountId ?? Guid.Empty;
        }

        return false;
    }
}
