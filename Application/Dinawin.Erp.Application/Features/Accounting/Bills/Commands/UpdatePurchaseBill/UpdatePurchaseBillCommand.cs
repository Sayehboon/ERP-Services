namespace Dinawin.Erp.Application.Features.Accounting.Bills.Commands.UpdatePurchaseBill;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdatePurchaseBillCommand(Guid Id, Guid VendorId, DateTime BillDate, string? Notes, IReadOnlyList<UpdatePurchaseBillLineDto> LineItems) : IRequest<bool>;
public record UpdatePurchaseBillLineDto(Guid AccountId, decimal Quantity, decimal UnitPrice, decimal LineDiscount, decimal TaxRate, decimal TaxAmount, string? Description);

public class UpdatePurchaseBillCommandHandler : IRequestHandler<UpdatePurchaseBillCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdatePurchaseBillCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdatePurchaseBillCommand request, CancellationToken cancellationToken)
    {
        var bill = await _db.PurchaseBills.Include(x => x.LineItems).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (bill == null) return false;
        bill.VendorId = request.VendorId; bill.BillDate = request.BillDate; bill.Notes = request.Notes;
        _db.PurchaseBillLines.RemoveRange(bill.LineItems); bill.LineItems.Clear();
        foreach (var l in request.LineItems)
        {
            bill.LineItems.Add(new PurchaseBillLine
            {
                Id = Guid.NewGuid(), PurchaseBillId = bill.Id, AccountId = l.AccountId, Quantity = l.Quantity, UnitPrice = l.UnitPrice,
                LineDiscount = l.LineDiscount, TaxRate = l.TaxRate, TaxAmount = l.TaxAmount, LineTotal = Math.Round(l.Quantity * l.UnitPrice - l.LineDiscount, 2), Description = l.Description
            });
        }
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


