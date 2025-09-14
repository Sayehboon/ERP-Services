using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.UpdateJournalEntry;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی سند حسابداری
/// </summary>
public sealed class UpdateJournalEntryCommandHandler : IRequestHandler<UpdateJournalEntryCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی سند حسابداری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateJournalEntryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی سند حسابداری
    /// </summary>
    public async Task<Guid> Handle(UpdateJournalEntryCommand request, CancellationToken cancellationToken)
    {
        // در مدل فعلی، سند حسابداری معادل JournalVoucher است
        var voucher = await _context.JournalVouchers
            .Include(v => v.Lines)
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);
        if (voucher == null)
        {
            throw new ArgumentException($"سند حسابداری با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتا بودن شماره سند (Number)
        var numberExists = await _context.JournalVouchers
            .AnyAsync(v => v.Number == request.EntryNumber && v.Id != request.Id, cancellationToken);
        if (numberExists)
        {
            throw new ArgumentException($"سند با شماره {request.EntryNumber} قبلاً وجود دارد");
        }

        // به‌روزرسانی هد سند
        voucher.Number = request.EntryNumber;
        voucher.VoucherDate = request.EntryDate;
        voucher.Type = request.EntryType;
        voucher.Description = request.Description;

        // اگر وضعیت سند غیر از draft باشد، به‌روزرسانی خطوط مجاز نیست
        if (!string.Equals(voucher.Status, "draft", StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException("امکان به‌روزرسانی خطوط فقط در وضعیت پیش‌نویس وجود دارد");
        }

        // یافتن یا ایجاد اولین خط مطابق ورودی
        var line = voucher.Lines.FirstOrDefault();
        if (line == null)
        {
            line = new Dinawin.Erp.Domain.Entities.Accounting.JournalLine
            {
                VoucherId = voucher.Id
            };
            voucher.Lines.Add(line);
        }

        // قوانین بدهکار/بستانکار
        if (request.DebitAmount > 0 && request.CreditAmount > 0)
        {
            throw new ArgumentException("یک ردیف نمی‌تواند هم بدهکار و هم بستانکار باشد");
        }
        if (request.DebitAmount == 0 && request.CreditAmount == 0)
        {
            throw new ArgumentException("مبلغ ردیف نمی‌تواند صفر باشد");
        }

        // صحت حساب
        var accountExists = await _context.ChartOfAccounts
            .AnyAsync(a => a.Id == request.AccountId, cancellationToken);
        if (!accountExists)
        {
            throw new ArgumentException($"حساب با شناسه {request.AccountId} یافت نشد");
        }

        // به‌روزرسانی خط
        line.AccountId = request.AccountId;
        line.Description = request.Description;
        line.Debit = request.DebitAmount;
        line.Credit = request.CreditAmount;

        await _context.SaveChangesAsync(cancellationToken);
        return voucher.Id;
    }
}
