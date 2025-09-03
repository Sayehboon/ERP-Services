namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.UpdateJournalVoucher;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;
using Microsoft.EntityFrameworkCore;

public record UpdateJournalVoucherCommand(
    Guid Id,
    DateTime VoucherDate,
    string? Description,
    IReadOnlyList<UpdateJournalLineDto> Lines
) : IRequest<bool>;

public record UpdateJournalLineDto(Guid AccountId, string? Description, decimal Debit, decimal Credit);

public class UpdateJournalVoucherCommandHandler : IRequestHandler<UpdateJournalVoucherCommand, bool>
{
    private readonly IApplicationDbContext _db;
    public UpdateJournalVoucherCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<bool> Handle(UpdateJournalVoucherCommand request, CancellationToken cancellationToken)
    {
        var voucher = await _db.JournalVouchers.Include(x => x.Lines).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (voucher == null) return false;

        voucher.VoucherDate = request.VoucherDate;
        voucher.Description = request.Description;

        // Remove existing lines and add new ones
        _db.JournalLines.RemoveRange(voucher.Lines);
        voucher.Lines.Clear();

        foreach (var line in request.Lines)
        {
            voucher.Lines.Add(new JournalLine
            {
                Id = Guid.NewGuid(),
                VoucherId = voucher.Id,
                AccountId = line.AccountId,
                Description = line.Description,
                Debit = line.Debit,
                Credit = line.Credit
            });
        }

        await _db.SaveChangesAsync(cancellationToken);
        return true;
    }
}
