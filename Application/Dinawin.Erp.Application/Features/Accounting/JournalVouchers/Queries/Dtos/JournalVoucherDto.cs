namespace Dinawin.Erp.Application.Features.Accounting.JournalVouchers.Queries.Dtos;

public class JournalVoucherDto
{
    public Guid Id { get; set; }
    public string? Number { get; set; }
    public int? SeqNo { get; set; }
    public DateTime VoucherDate { get; set; }
    public string Type { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Status { get; set; } = string.Empty;
    public int? ApprovalStage { get; set; }
    public string? ApprovalStatus { get; set; }
    public Guid FiscalYearId { get; set; }
    public Guid FiscalPeriodId { get; set; }
    public ICollection<JournalLineDto> Lines { get; set; } = new List<JournalLineDto>();
}

public class JournalLineDto
{
    public Guid Id { get; set; }
    public Guid AccountId { get; set; }
    public string? Description { get; set; }
    public decimal Debit { get; set; }
    public decimal Credit { get; set; }
}
