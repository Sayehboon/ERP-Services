namespace Dinawin.Erp.Application.Features.Accounting.Bills.Commands.CreatePurchaseBill;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

public record CreatePurchaseBillCommand(Guid VendorId, DateTime BillDate, string? Notes, IReadOnlyList<CreatePurchaseBillLineDto> LineItems) : IRequest<Guid>;
public record CreatePurchaseBillLineDto(Guid AccountId, decimal Quantity, decimal UnitPrice, decimal LineDiscount, decimal TaxRate, decimal TaxAmount, string? Description);

public class CreatePurchaseBillCommandHandler : IRequestHandler<CreatePurchaseBillCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreatePurchaseBillCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreatePurchaseBillCommand request, CancellationToken cancellationToken)
    {
        var bill = new PurchaseBill
        {
            Id = Guid.NewGuid(), VendorId = request.VendorId, BillDate = request.BillDate, Notes = request.Notes, Status = "draft"
        };
        foreach (var l in request.LineItems)
        {
            bill.LineItems.Add(new PurchaseBillLine
            {
                Id = Guid.NewGuid(), PurchaseBillId = bill.Id, AccountId = l.AccountId, Quantity = l.Quantity, UnitPrice = l.UnitPrice,
                LineDiscount = l.LineDiscount, TaxRate = l.TaxRate, TaxAmount = l.TaxAmount, LineTotal = Math.Round(l.Quantity * l.UnitPrice - l.LineDiscount, 2), Description = l.Description
            });
        }
        _db.PurchaseBills.Add(bill);
        await _db.SaveChangesAsync(cancellationToken);
        return bill.Id;
    }
}


