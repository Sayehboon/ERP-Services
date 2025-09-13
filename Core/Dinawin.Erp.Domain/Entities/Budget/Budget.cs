using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Accounting;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Budget;

/// <summary>
/// بودجه
/// Budget
/// </summary>
public class Budget : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام بودجه
    /// Budget Name
    /// </summary>
    public string BudgetName { get; set; } = string.Empty;

    /// <summary>
    /// کد بودجه
    /// Budget Code
    /// </summary>
    public string BudgetCode { get; set; } = string.Empty;

    /// <summary>
    /// نوع بودجه
    /// Budget Type
    /// </summary>
    public string BudgetType { get; set; } = string.Empty;

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal Year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal Period ID
    /// </summary>
    public Guid? FiscalPeriodId { get; set; }

    /// <summary>
    /// تاریخ شروع
    /// Start Date
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End Date
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// وضعیت بودجه
    /// Budget Status
    /// </summary>
    public string BudgetStatus { get; set; } = "draft";

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا تایید شده است
    /// Is Approved
    /// </summary>
    public bool IsApproved { get; set; } = false;

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approved By User ID
    /// </summary>
    public Guid? ApprovedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// Created By User ID
    /// </summary>
    public Guid CreatedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر آخرین ویرایش
    /// Last Modified By User ID
    /// </summary>
    public Guid? LastModifiedByUserId { get; set; }

    /// <summary>
    /// مجموع بودجه
    /// Budget Total
    /// </summary>
    public decimal BudgetTotal { get; set; } = 0;

    /// <summary>
    /// مجموع هزینه شده
    /// Spent Total
    /// </summary>
    public decimal SpentTotal { get; set; } = 0;

    /// <summary>
    /// مجموع باقی مانده
    /// Remaining Total
    /// </summary>
    public decimal RemainingTotal { get; set; } = 0;

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
    /// مجموع بودجه به ارز اصلی
    /// Budget Total in Base Currency
    /// </summary>
    public decimal BudgetTotalBase { get; set; } = 0;

    /// <summary>
    /// مجموع هزینه شده به ارز اصلی
    /// Spent Total in Base Currency
    /// </summary>
    public decimal SpentTotalBase { get; set; } = 0;

    /// <summary>
    /// مجموع باقی مانده به ارز اصلی
    /// Remaining Total in Base Currency
    /// </summary>
    public decimal RemainingTotalBase { get; set; } = 0;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

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

    // Navigation Properties
    /// <summary>
    /// سال مالی
    /// Fiscal Year
    /// </summary>
    public virtual AccFiscalYear? FiscalYear { get; set; }

    /// <summary>
    /// دوره مالی
    /// Fiscal Period
    /// </summary>
    public virtual AccFiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }

    /// <summary>
    /// کاربر ایجاد کننده
    /// Created By User
    /// </summary>
    public virtual User? CreatedByUser { get; set; }

    /// <summary>
    /// کاربر آخرین ویرایش
    /// Last Modified By User
    /// </summary>
    public virtual User? LastModifiedByUser { get; set; }

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

    /// <summary>
    /// سطرهای بودجه
    /// Budget Lines
    /// </summary>
    public virtual ICollection<BudgetLine> BudgetLines { get; set; } = new List<BudgetLine>();
}

/// <summary>
/// پیکربندی موجودیت بودجه
/// Budget entity configuration
/// </summary>
public class BudgetConfiguration : IEntityTypeConfiguration<Budget>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Budget> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.BudgetName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.BudgetCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.BudgetType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.BudgetStatus)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.Currency)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.ExchangeRate)
            .HasPrecision(18, 6);

        builder.Property(e => e.BudgetTotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.SpentTotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.RemainingTotal)
            .HasPrecision(18, 2);

        builder.Property(e => e.BudgetTotalBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.SpentTotalBase)
            .HasPrecision(18, 2);

        builder.Property(e => e.RemainingTotalBase)
            .HasPrecision(18, 2);

        builder.HasOne(e => e.FiscalYear)
            .WithMany()
            .HasForeignKey(e => e.FiscalYearId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.LastModifiedByUser)
            .WithMany()
            .HasForeignKey(e => e.LastModifiedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.Project)
            .WithMany()
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(e => e.BudgetLines)
            .WithOne(e => e.Budget)
            .HasForeignKey(e => e.BudgetId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.BudgetCode)
            .IsUnique();

        builder.HasIndex(e => e.FiscalYearId);
        builder.HasIndex(e => e.FiscalPeriodId);
        //builder.HasIndex(e => e.Status);
    }
}
