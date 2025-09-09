namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.GetJournalVoucherById;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// پرس‌وجو برای دریافت سند حسابداری بر اساس شناسه
/// </summary>
public sealed record GetJournalVoucherByIdQuery(Guid Id) : IRequest<JournalVoucherDto?>;

/// <summary>
/// پردازشگر پرس‌وجو دریافت سند حسابداری بر اساس شناسه
/// </summary>
public sealed class GetJournalVoucherByIdQueryHandler : IRequestHandler<GetJournalVoucherByIdQuery, JournalVoucherDto?>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    public GetJournalVoucherByIdQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<JournalVoucherDto?> Handle(GetJournalVoucherByIdQuery request, CancellationToken cancellationToken)
    {
        var jv = await _db.JournalVouchers
            .Include(v => v.Lines)
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

        if (jv == null)
            return null;

        return new JournalVoucherDto
        {
            Id = jv.Id,
            Number = jv.Number,
            SeqNo = jv.SeqNo,
            VoucherDate = jv.VoucherDate,
            Type = jv.Type,
            Description = jv.Description,
            Status = jv.Status,
            ApprovalStage = jv.ApprovalStage,
            ApprovalStatus = jv.ApprovalStatus,
            FiscalYearId = jv.FiscalYearId,
            FiscalPeriodId = jv.FiscalPeriodId,
            Lines = jv.Lines.Select(l => new JournalLineDto
            {
                Id = l.Id,
                AccountId = l.AccountId,
                Description = l.Description,
                Debit = l.Debit,
                Credit = l.Credit
            }).ToList()
        };
    }
}


