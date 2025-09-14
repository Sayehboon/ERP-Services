namespace Dinawin.Erp.Application.Features.Accounting.Bills.Commands.PostPurchaseBill;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record PostPurchaseBillCommand(Guid Id) : IRequest<bool>;

public class PostPurchaseBillCommandHandler : IRequestHandler<PostPurchaseBillCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public PostPurchaseBillCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(PostPurchaseBillCommand request, CancellationToken cancellationToken)
    {
        var bill = await _db.PurchaseBills.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (bill == null) return false;
        if (bill.Status == "posted") return true;
        bill.Status = "posted";
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}


