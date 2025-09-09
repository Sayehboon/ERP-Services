using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Treasury;

/// <summary>
/// سطر بودجه
/// Budget Line
/// </summary>
public class BudgetLine : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه بودجه
    /// Budget ID
    /// </summary>
    public Guid BudgetId { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// مبلغ بودجه
    /// Budget Amount
    /// </summary>
    public decimal BudgetAmount { get; set; }

    /// <summary>
    /// مبلغ هزینه شده
    /// Spent Amount
    /// </summary>
    public decimal SpentAmount { get; set; } = 0;

    /// <summary>
    /// مبلغ باقی مانده
    /// Remaining Amount
    /// </summary>
    public decimal RemainingAmount { get; set; }

    /// <summary>
    /// شرح سطر
    /// Line Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شماره سطر
    /// Line Number
    /// </summary>
    public int LineNumber { get; set; }

    /// <summary>
    /// شناسه بعد 1
    /// Dimension 1 ID
    /// </summary>
    public Guid? Dimension1Id { get; set; }

    /// <summary>
    /// شناسه بعد 2
    /// Dimension 2 ID
    /// </summary>
    public Guid? Dimension2Id { get; set; }

    /// <summary>
    /// شناسه بعد 3
    /// Dimension 3 ID
    /// </summary>
    public Guid? Dimension3Id { get; set; }

    /// <summary>
    /// شناسه بعد 4
    /// Dimension 4 ID
    /// </summary>
    public Guid? Dimension4Id { get; set; }

    /// <summary>
    /// شناسه بعد 5
    /// Dimension 5 ID
    /// </summary>
    public Guid? Dimension5Id { get; set; }

    /// <summary>
    /// مقدار بعد 1
    /// Dimension 1 Value ID
    /// </summary>
    public Guid? Dimension1ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 2
    /// Dimension 2 Value ID
    /// </summary>
    public Guid? Dimension2ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 3
    /// Dimension 3 Value ID
    /// </summary>
    public Guid? Dimension3ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 4
    /// Dimension 4 Value ID
    /// </summary>
    public Guid? Dimension4ValueId { get; set; }

    /// <summary>
    /// مقدار بعد 5
    /// Dimension 5 Value ID
    /// </summary>
    public Guid? Dimension5ValueId { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه پروژه
    /// Project ID
    /// </summary>
    public Guid? ProjectId { get; set; }

    /// <summary>
    /// شناسه مرکز هزینه
    /// Cost Center ID
    /// </summary>
    public Guid? CostCenterId { get; set; }

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange Rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// مبلغ بودجه به ارز اصلی
    /// Budget Amount in Base Currency
    /// </summary>
    public decimal BudgetAmountBase { get; set; }

    /// <summary>
    /// مبلغ هزینه شده به ارز اصلی
    /// Spent Amount in Base Currency
    /// </summary>
    public decimal SpentAmountBase { get; set; } = 0;

    /// <summary>
    /// مبلغ باقی مانده به ارز اصلی
    /// Remaining Amount in Base Currency
    /// </summary>
    public decimal RemainingAmountBase { get; set; }

    /// <summary>
    /// توضیحات اضافی
    /// Additional Notes
    /// </summary>
    public string? AdditionalNotes { get; set; }

    // Navigation Properties
    /// <summary>
    /// بودجه
    /// Budget
    /// </summary>
    public virtual Budget? Budget { get; set; }

    /// <summary>
    /// حساب
    /// Account
    /// </summary>
    public virtual Account? Account { get; set; }

    /// <summary>
    /// بعد 1
    /// Dimension 1
    /// </summary>
    public virtual AccDimension? Dimension1 { get; set; }

    /// <summary>
    /// بعد 2
    /// Dimension 2
    /// </summary>
    public virtual AccDimension? Dimension2 { get; set; }

    /// <summary>
    /// بعد 3
    /// Dimension 3
    /// </summary>
    public virtual AccDimension? Dimension3 { get; set; }

    /// <summary>
    /// بعد 4
    /// Dimension 4
    /// </summary>
    public virtual AccDimension? Dimension4 { get; set; }

    /// <summary>
    /// بعد 5
    /// Dimension 5
    /// </summary>
    public virtual AccDimension? Dimension5 { get; set; }

    /// <summary>
    /// مقدار بعد 1
    /// Dimension 1 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension1Value { get; set; }

    /// <summary>
    /// مقدار بعد 2
    /// Dimension 2 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension2Value { get; set; }

    /// <summary>
    /// مقدار بعد 3
    /// Dimension 3 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension3Value { get; set; }

    /// <summary>
    /// مقدار بعد 4
    /// Dimension 4 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension4Value { get; set; }

    /// <summary>
    /// مقدار بعد 5
    /// Dimension 5 Value
    /// </summary>
    public virtual AccDimensionValue? Dimension5Value { get; set; }

    /// <summary>
    /// بخش
    /// Department
    /// </summary>
    public virtual Department? Department { get; set; }

    /// <summary>
    /// پروژه
    /// Project
    /// </summary>
    public virtual Project? Project { get; set; }
}

/// <summary>
/// پیکربندی موجودیت سطر بودجه
/// Budget Line entity configuration
/// </summary>
public class BudgetLineConfiguration : IEntityTypeConfiguration<BudgetLine>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<BudgetLine> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.BudgetAmount)
            .HasPrecision(18, 2);

        builder.Property(e => e.SpentAmount)
            .HasPrecision(18, 2);

        builder.Property(e => e.RemainingAmount)
            .HasPrecision(18, 2);

        builder.Property(e => e.Currency)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.ExchangeRate)
            .HasPrecision(18, 6);

        builder.Property(e => e.BudgetAmountBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.SpentAmountBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.RemainingAmountBase)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.Budget)
            .WithMany(e => e.BudgetLines)
            .HasForeignKey(e => e.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Account)
            .WithMany()
            .HasForeignKey(e => e.AccountId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Dimension1)
            .WithMany()
            .HasForeignKey(e => e.Dimension1Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension2)
            .WithMany()
            .HasForeignKey(e => e.Dimension2Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension3)
            .WithMany()
            .HasForeignKey(e => e.Dimension3Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension4)
            .WithMany()
            .HasForeignKey(e => e.Dimension4Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension5)
            .WithMany()
            .HasForeignKey(e => e.Dimension5Id)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension1Value)
            .WithMany()
            .HasForeignKey(e => e.Dimension1ValueId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension2Value)
            .WithMany()
            .HasForeignKey(e => e.Dimension2ValueId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension3Value)
            .WithMany()
            .HasForeignKey(e => e.Dimension3ValueId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension4Value)
            .WithMany()
            .HasForeignKey(e => e.Dimension4ValueId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Dimension5Value)
            .WithMany()
            .HasForeignKey(e => e.Dimension5ValueId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Project)
            .WithMany()
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.BudgetId);
        builder.HasIndex(e => e.AccountId);
        builder.HasIndex(e => e.LineNumber);
    }
}
