using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

public class Budget : BaseEntity, IAggregateRoot
{
    public Guid BusinessId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Currency { get; set; } = "IRR";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; } = "draft";
    public ICollection<BudgetLine> Lines { get; set; } = new List<BudgetLine>();
}

public class BudgetLine : BaseEntity
{
    public Guid BudgetId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public string? Notes { get; set; }

    public Budget Budget { get; set; } = null!;
}

public class ClosingRun : BaseEntity, IAggregateRoot
{
    public Guid FiscalYearId { get; set; }
    public DateTime RunDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "completed";
}

/// <summary>
/// پیکربندی موجودیت بودجه
/// Budget entity configuration
/// </summary>
public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Status).HasMaxLength(50);

        builder.HasIndex(e => e.BusinessId);
        builder.HasIndex(e => e.StartDate);
        builder.HasIndex(e => e.EndDate);
    }
}

/// <summary>
/// پیکربندی موجودیت خط بودجه
/// Budget Line entity configuration
/// </summary>
public class BudgetLineConfiguration : IEntityTypeConfiguration<BudgetLine>
{
    public void Configure(EntityTypeBuilder<BudgetLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Notes).HasMaxLength(1000);
        builder.Property(e => e.Amount).HasPrecision(18, 2);

        builder.HasOne(e => e.Budget)
            .WithMany(b => b.Lines)
            .HasForeignKey(e => e.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.BudgetId);
        builder.HasIndex(e => e.AccountId);
    }
}

/// <summary>
/// پیکربندی موجودیت اجرای بستن
/// Closing Run entity configuration
/// </summary>
public class ClosingRunConfiguration : IEntityTypeConfiguration<ClosingRun>
{
    public void Configure(EntityTypeBuilder<ClosingRun> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Status).HasMaxLength(50);

        builder.HasIndex(e => e.FiscalYearId);
        builder.HasIndex(e => e.RunDate);
    }
}

