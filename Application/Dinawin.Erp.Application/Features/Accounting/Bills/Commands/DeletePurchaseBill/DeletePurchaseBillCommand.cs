namespace Dinawin.Erp.Application.Features.Accounting.Bills.Commands.DeletePurchaseBill;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record DeletePurchaseBillCommand(Guid Id) : IRequest<bool>;

public class DeletePurchaseBillCommandHandler : IRequestHandler<DeletePurchaseBillCommand, bool>
{
	private readonly IApplicationDbContext _db;
	public DeletePurchaseBillCommandHandler(IApplicationDbContext db) { _db = db; }

	public async Task<bool> Handle(DeletePurchaseBillCommand request, CancellationToken cancellationToken)
	{
		var bill = await _db.PurchaseBills.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
		if (bill == null) return false;
		_db.PurchaseBills.Remove(bill);
		await _db.SaveChangesAsync(cancellationToken);
		return true;
	}
}
