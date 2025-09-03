namespace Dinawin.Erp.Application.Features.SalesInvoices.Commands.DeleteSalesInvoice;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان حذف فاکتور فروش
/// Command to delete sales invoice
/// </summary>
public record DeleteSalesInvoiceCommand(Guid Id) : IRequest<bool>;

/// <summary>
/// هندلر حذف فاکتور فروش
/// Handler for DeleteSalesInvoiceCommand
/// </summary>
public class DeleteSalesInvoiceCommandHandler : IRequestHandler<DeleteSalesInvoiceCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public DeleteSalesInvoiceCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(DeleteSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _db.SalesInvoices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (invoice == null) return false;
        _db.SalesInvoices.Remove(invoice);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


