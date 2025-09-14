namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.PostJournalVoucher;

using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record PostJournalVoucherCommand(Guid Id) : IRequest<bool>;

public class PostJournalVoucherCommandHandler : IRequestHandler<PostJournalVoucherCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public PostJournalVoucherCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(PostJournalVoucherCommand request, CancellationToken cancellationToken)
    {
        var voucher = await _db.JournalVouchers.Include(x => x.Lines).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (voucher == null) return false;

        // Validate that voucher is balanced
        var totalDebit = voucher.Lines.Sum(l => l.Debit);
        var totalCredit = voucher.Lines.Sum(l => l.Credit);
        if (totalDebit != totalCredit || totalDebit == 0)
            return false;

        voucher.Status = "posted";
        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
