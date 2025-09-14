using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.DeleteJournalEntry;

/// <summary>
/// مدیریت‌کننده دستور حذف سند حسابداری
/// </summary>
public sealed class DeleteJournalEntryCommandHandler : IRequestHandler<DeleteJournalEntryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف سند حسابداری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteJournalEntryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف سند حسابداری
    /// </summary>
    public async Task<bool> Handle(DeleteJournalEntryCommand request, CancellationToken cancellationToken)
    {
        // در مدل فعلی، اسناد حسابداری به صورت JournalVoucher ذخیره می‌شوند
        var voucher = await _context.JournalVouchers.FirstOrDefaultAsync(jv => jv.Id == request.Id, cancellationToken);
        if (voucher == null)
        {
            throw new ArgumentException($"سند حسابداری با شناسه {request.Id} یافت نشد");
        }

        // فقط اسناد پیش‌نویس قابل حذف هستند
        if (!string.Equals(voucher.Status, "draft", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("امکان حذف فقط برای اسناد در وضعیت پیش‌نویس وجود دارد");
        }

        _context.JournalVouchers.Remove(voucher);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
