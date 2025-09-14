namespace Dinawin.Erp.Application.Features.SalesInvoices.Queries.GetSalesInvoiceById;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.SalesInvoices.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// کوئری دریافت فاکتور فروش با شناسه
/// Query to get sales invoice by id
/// </summary>
public record GetSalesInvoiceByIdQuery(Guid Id) : IRequest<SalesInvoiceDto>;

/// <summary>
/// هندلر کوئری دریافت فاکتور فروش با شناسه
/// Handler for GetSalesInvoiceByIdQuery
/// </summary>
public class GetSalesInvoiceByIdQueryHandler : IRequestHandler<GetSalesInvoiceByIdQuery, SalesInvoiceDto>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده
    /// Constructor
    /// </summary>
    public GetSalesInvoiceByIdQueryHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرا
    /// Handle
    /// </summary>
    public async Task<SalesInvoiceDto> Handle(GetSalesInvoiceByIdQuery request, CancellationToken cancellationToken)
    {
        var x = await _db.SalesInvoices.AsNoTracking().FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);
        if (x == null) return null;

        return new SalesInvoiceDto
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
        };
    }
}


