namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

/// <summary>
/// پیکربندی موجودیت ثبت روزنامه
/// Journal Entry entity configuration
/// </summary>
public class JournalEntryConfiguration : IEntityTypeConfiguration<JournalEntry>
{
	public void Configure(EntityTypeBuilder<JournalEntry> builder)
	{
		builder.HasKey(e => e.Id);

		builder.Property(e => e.EntryNumber).IsRequired().HasMaxLength(100);
		builder.Property(e => e.EntryType).IsRequired().HasMaxLength(50);
		builder.Property(e => e.Description).IsRequired().HasMaxLength(1000);
		builder.Property(e => e.Currency).HasMaxLength(10);
		builder.Property(e => e.Reference).HasMaxLength(200);
		builder.Property(e => e.ReferenceType).HasMaxLength(50);

		builder.Property(e => e.DebitAmount).HasPrecision(18, 2);
		builder.Property(e => e.CreditAmount).HasPrecision(18, 2);
		builder.Property(e => e.ExchangeRate).HasPrecision(18, 6);

		builder.HasOne(e => e.Account)
			.WithMany()
			.HasForeignKey(e => e.AccountId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(e => e.EntryNumber).IsUnique(false);
		builder.HasIndex(e => e.EntryDate);
		builder.HasIndex(e => e.EntryType);
	}
}

/// <summary>
/// پیکربندی موجودیت خط ثبت روزنامه
/// Journal Entry Line entity configuration
/// </summary>
public class JournalEntryLineConfiguration : IEntityTypeConfiguration<JournalEntryLine>
{
	public void Configure(EntityTypeBuilder<JournalEntryLine> builder)
	{
		builder.HasKey(e => e.Id);

		builder.Property(e => e.Description).HasMaxLength(1000);

		builder.Property(e => e.Debit).HasPrecision(18, 2);
		builder.Property(e => e.Credit).HasPrecision(18, 2);

		builder.HasOne(e => e.JournalEntry)
			.WithMany(j => j.Lines)
			.HasForeignKey(e => e.JournalEntryId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(e => e.Account)
			.WithMany()
			.HasForeignKey(e => e.AccountId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasIndex(e => e.JournalEntryId);
		builder.HasIndex(e => e.AccountId);
	}
}
