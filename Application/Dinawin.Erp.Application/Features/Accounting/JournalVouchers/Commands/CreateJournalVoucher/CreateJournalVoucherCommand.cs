namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Commands.CreateJournalVoucher;

using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;
using MediatR;

public record CreateJournalVoucherCommand(
    Guid FiscalYearId,
    Guid FiscalPeriodId,
    DateTime VoucherDate,
    string? Description,
    IReadOnlyList<CreateJournalLineDto> Lines
) : IRequest<Guid>;

public record CreateJournalLineDto(Guid AccountId, string? Description, decimal Debit, decimal Credit);

public class CreateJournalVoucherCommandHandler : IRequestHandler<CreateJournalVoucherCommand, Guid>
{
    private readonly IApplicationDbContext _db;
    public CreateJournalVoucherCommandHandler(IApplicationDbContext db) { _db = db; }

    public async Task<Guid> Handle(CreateJournalVoucherCommand request, CancellationToken cancellationToken)
    {
        var voucher = new JournalVoucher
        {
            Id = Guid.NewGuid(),
            FiscalYearId = request.FiscalYearId,
            FiscalPeriodId = request.FiscalPeriodId,
            VoucherDate = request.VoucherDate,
            Description = request.Description,
            Type = "JV",
            Status = "draft"
        };

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

        _db.JournalVouchers.Add(voucher);
        await _db.SaveChangesAsync(cancellationToken);
        return voucher.Id;
    }
}
