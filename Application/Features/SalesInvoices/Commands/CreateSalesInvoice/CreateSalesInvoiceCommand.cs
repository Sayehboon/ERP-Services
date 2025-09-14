namespace Dinawin.Erp.Application.Features.SalesInvoices.Commands.CreateSalesInvoice;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

/// <summary>
/// فرمان ایجاد فاکتور فروش
/// Command to create sales invoice
/// </summary>
public record CreateSalesInvoiceCommand(Guid CustomerId, DateTime InvoiceDate, string Notes, IReadOnlyList<CreateSalesInvoiceLineDto> LineItems) : IRequest<Guid>;

/// <summary>
/// DTO سطر فاکتور برای ایجاد
/// Line item DTO for creation
/// </summary>
public record CreateSalesInvoiceLineDto(Guid AccountId, decimal Quantity, decimal UnitPrice, decimal LineDiscount, decimal TaxRate, decimal TaxAmount, string Description);

/// <summary>
/// هندلر ایجاد فاکتور فروش
/// Handler to create sales invoice
/// </summary>
public class CreateSalesInvoiceCommandHandler : IRequestHandler<CreateSalesInvoiceCommand, Guid>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده
    /// Constructor
    /// </summary>
    public CreateSalesInvoiceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرا
    /// Handle
    /// </summary>
    public async Task<Guid> Handle(CreateSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = new SalesInvoice
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            InvoiceDate = request.InvoiceDate,
            Notes = request.Notes,
            Status = "draft"
        };

        foreach (var l in request.LineItems)
        {
            invoice.LineItems.Add(new SalesInvoiceLine
            {
                Id = Guid.NewGuid(),
                SalesInvoiceId = invoice.Id,
                AccountId = l.AccountId,
                Quantity = l.Quantity,
                UnitPrice = l.UnitPrice,
                LineDiscount = l.LineDiscount,
                TaxRate = l.TaxRate,
                TaxAmount = l.TaxAmount,
                LineTotal = Math.Round(l.Quantity * l.UnitPrice - l.LineDiscount, 2)
            });
        }

        _db.SalesInvoices.Add(invoice);
        await _db.SaveChangesAsync(cancellationToken);
        return invoice.Id;
    }
}


