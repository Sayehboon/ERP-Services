namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.GetAllJournalVouchers;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAllJournalVouchersQuery(
    string? Status = null,
    string? Type = null,
    string? Number = null,
    DateTime? FromDate = null,
    DateTime? ToDate = null,
    string? SortBy = "seq_no"
) : IRequest<IReadOnlyList<JournalVoucherDto>>;

public class GetAllJournalVouchersQueryHandler : IRequestHandler<GetAllJournalVouchersQuery, IReadOnlyList<JournalVoucherDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllJournalVouchersQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<JournalVoucherDto>> Handle(GetAllJournalVouchersQuery request, CancellationToken cancellationToken)
    {
        var q = _db.JournalVouchers.AsNoTracking();
        
        if (!string.IsNullOrWhiteSpace(request.Status) && request.Status != "all")
            q = q.Where(jv => jv.Status == request.Status);
        
        if (!string.IsNullOrWhiteSpace(request.Type) && request.Type != "all")
            q = q.Where(jv => jv.Type == request.Type);
        
        if (!string.IsNullOrWhiteSpace(request.Number))
            q = q.Where(jv => jv.Number != null && jv.Number.Contains(request.Number));
        
        if (request.FromDate.HasValue)
            q = q.Where(jv => jv.VoucherDate >= request.FromDate.Value);
        
        if (request.ToDate.HasValue)
            q = q.Where(jv => jv.VoucherDate <= request.ToDate.Value);

        q = request.SortBy switch
        {
            "seq_no" => q.OrderBy(jv => jv.SeqNo),
            "voucher_date" => q.OrderBy(jv => jv.VoucherDate),
            _ => q.OrderBy(jv => jv.SeqNo)
        };

        return await q.Select(jv => new JournalVoucherDto
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
            FiscalPeriodId = jv.FiscalPeriodId
        }).ToListAsync(cancellationToken);
    }
}
