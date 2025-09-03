namespace Dinawin.Erp.Application.Features.SalesInvoices.Commands.PostSalesInvoice;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// فرمان ثبت فاکتور فروش
/// Command to post sales invoice
/// </summary>
public record PostSalesInvoiceCommand(Guid Id) : IRequest<bool>;

/// <summary>
/// هندلر ثبت فاکتور فروش
/// Handler for PostSalesInvoiceCommand
/// </summary>
public class PostSalesInvoiceCommandHandler : IRequestHandler<PostSalesInvoiceCommand, bool>
{
    private readonly IApplicationDbContext _db;

    /// <summary>
    /// سازنده
    /// Constructor
    /// </summary>
    public PostSalesInvoiceCommandHandler(IApplicationDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// اجرا
    /// Handle
    /// </summary>
    public async Task<bool> Handle(PostSalesInvoiceCommand request, CancellationToken cancellationToken)
    {
        var invoice = await _db.SalesInvoices.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (invoice == null) return false;

        if (invoice.Status == "posted") return true;

        invoice.Status = "posted";
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


