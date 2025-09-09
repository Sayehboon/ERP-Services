namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

public class JournalEntry : BaseEntity, IAggregateRoot
{
	public string EntryNumber { get; set; } = string.Empty;
	public DateTime EntryDate { get; set; }
	public string EntryType { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public Guid AccountId { get; set; }
	public decimal DebitAmount { get; set; }
	public decimal CreditAmount { get; set; }
	public string? Currency { get; set; }
	public decimal? ExchangeRate { get; set; }
	public string? Reference { get; set; }
	public Guid? ReferenceId { get; set; }
	public string? ReferenceType { get; set; }
	public bool IsApproved { get; set; }
	public DateTime? ApprovedAt { get; set; }
	public Guid? ApprovedBy { get; set; }

	// Navigation properties
	public Account? Account { get; set; }
	public ICollection<JournalEntryLine> Lines { get; set; } = new List<JournalEntryLine>();
}

public class JournalEntryLine : BaseEntity
{
	public Guid JournalEntryId { get; set; }
	public Guid AccountId { get; set; }
	public string? Description { get; set; }
	public decimal Debit { get; set; }
	public decimal Credit { get; set; }

	// Navigation properties
	public JournalEntry? JournalEntry { get; set; }
	public Account? Account { get; set; }
}
