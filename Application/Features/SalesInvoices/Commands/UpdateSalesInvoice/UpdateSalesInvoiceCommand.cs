namespace Dinawin.Erp.Application.Features.SalesInvoices.Commands.UpdateSalesInvoice;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ویرایش فاکتور فروش
/// Command to update sales invoice
/// </summary>
public record UpdateSalesInvoiceCommand(
    Guid Id,
    Guid CustomerId,
    DateTime InvoiceDate,
    string Notes,
    IReadOnlyList<UpdateSalesInvoiceLineDto> LineItems
) : IRequest<bool>;

/// <summary>
/// DTO سطر فاکتور برای ویرایش
/// Line item DTO for update
/// </summary>
public record UpdateSalesInvoiceLineDto(Guid AccountId, decimal Quantity, decimal UnitPrice, decimal LineDiscount, decimal TaxRate, decimal TaxAmount, string Description);

/// <summary>
/// هندلر ویرایش فاکتور فروش
/// Handler for UpdateSalesInvoiceCommand
/// </summary>
public class UpdateSalesInvoiceCommandHandler : IRequestHandler<UpdateSalesInvoiceCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateSalesInvoiceCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _db.SalesInvoices.Include(x => x.LineItems)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (invoice == null) return false;

        invoice.CustomerId = request.CustomerId;
        invoice.InvoiceDate = request.InvoiceDate;
        invoice.Notes = request.Notes;

        // Replace lines
        _db.SalesInvoiceLines.RemoveRange(invoice.LineItems);
        invoice.LineItems.Clear();
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

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


