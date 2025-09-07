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
        var entry = await _context.JournalEntries.FirstOrDefaultAsync(je => je.Id == request.Id, cancellationToken);
        if (entry == null)
        {
            throw new ArgumentException($"سند حسابداری با شناسه {request.Id} یافت نشد");
        }

        // بررسی تأیید سند
        if (entry.IsApproved)
        {
            throw new InvalidOperationException("امکان حذف سند تأیید شده وجود ندارد");
        }

        _context.JournalEntries.Remove(entry);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
