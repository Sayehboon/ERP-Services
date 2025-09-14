namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.DeleteJournalVoucher;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record DeleteJournalVoucherCommand(Guid Id) : IRequest<bool>;

public class DeleteJournalVoucherCommandHandler : IRequestHandler<DeleteJournalVoucherCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public DeleteJournalVoucherCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(DeleteJournalVoucherCommand request, CancellationToken cancellationToken)
    {
        var voucher = await _db.JournalVouchers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (voucher == null) return false;

        // Only allow deletion of draft vouchers
        if (voucher.Status != "draft") return false;

        _db.JournalVouchers.Remove(voucher);
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
