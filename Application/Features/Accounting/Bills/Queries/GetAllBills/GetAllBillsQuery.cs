namespace Dinawin.Erp.Application.Features.Accounting.Bills.Queries.GetAllBills;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Accounting.Bills.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record GetAllBillsQuery(Guid? VendorId = null, string Status = null, DateTime? FromDate = null, DateTime? ToDate = null) : IRequest<IReadOnlyList<PurchaseBillDto>>;

public class GetAllBillsQueryHandler : IRequestHandler<GetAllBillsQuery, IReadOnlyList<PurchaseBillDto>>
{
    private readonly IApplicationDbContext _db;
    public GetAllBillsQueryHandler(IApplicationDbContext db) { _db = db; }

    public async Task<IReadOnlyList<PurchaseBillDto>> Handle(GetAllBillsQuery request, CancellationToken cancellationToken)
    {
        var q = _db.PurchaseBills.AsNoTracking();
        if (request.VendorId.HasValue) q = q.Where(b => b.VendorId == request.VendorId);
        if (!string.IsNullOrWhiteSpace(request.Status)) q = q.Where(b => b.Status == request.Status);
        if (request.FromDate.HasValue) q = q.Where(b => b.BillDate >= request.FromDate);
        if (request.ToDate.HasValue) q = q.Where(b => b.BillDate <= request.ToDate);
        return await q.OrderByDescending(b => b.BillDate)
            .Select(b => new PurchaseBillDto
            {
                Id = b.Id,
                Number = b.Number,
                BillDate = b.BillDate,
                VendorId = b.VendorId,
                VendorName = string.Empty,
                Total = 0,
                Status = b.Status
            })
            .ToListAsync(cancellationToken);
    }
}


