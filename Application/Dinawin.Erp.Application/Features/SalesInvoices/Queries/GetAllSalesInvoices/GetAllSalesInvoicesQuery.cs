namespace Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetAllSalesInvoices;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت فاکتورهای فروش
/// Query to get sales invoices
/// </summary>
public record GetAllSalesInvoicesQuery(Guid? CustomerId, string? Status, DateTime? FromDate, DateTime? ToDate, int Page = 1, int PageSize = 25) : IRequest<IReadOnlyList<SalesInvoiceDto>>;

/// <summary>
/// هندلر کوئری دریافت فاکتورهای فروش
/// Handler for GetAllSalesInvoicesQuery
/// </summary>
public class GetAllSalesInvoicesQueryHandler : IRequestHandler<GetAllSalesInvoicesQuery, IReadOnlyList<SalesInvoiceDto>>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده
    /// Constructor
    /// </summary>
    public GetAllSalesInvoicesQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرا
    /// Handle
    /// </summary>
    public async Task<IReadOnlyList<SalesInvoiceDto>> Handle(GetAllSalesInvoicesQuery request, CancellationToken cancellationToken)
    {
        var query = _db.SalesInvoices.AsNoTracking();

        if (request.CustomerId is Guid cid)
            query = query.Where(x => x.CustomerId == cid);

        if (!string.IsNullOrWhiteSpace(request.Status))
            query = query.Where(x => x.Status == request.Status);

        if (request.FromDate.HasValue)
            query = query.Where(x => x.InvoiceDate >= request.FromDate.Value);

        if (request.ToDate.HasValue)
            query = query.Where(x => x.InvoiceDate <= request.ToDate.Value);

        var items = await query
            .OrderByDescending(x => x.InvoiceDate)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(x => new SalesInvoiceDto
            {
                Id = x.Id,
                Number = x.Number,
                InvoiceDate = x.InvoiceDate,
                CustomerId = x.CustomerId,
                CustomerName = string.Empty,
                Total = 0,
                Tax = 0,
                Discount = 0,
                Notes = x.Notes,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        return items;
    }
}


