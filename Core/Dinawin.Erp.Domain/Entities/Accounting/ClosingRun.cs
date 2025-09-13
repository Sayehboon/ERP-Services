using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Accounting;

/// <summary>
/// اجرای بستن دوره
/// Closing Run
/// </summary>
public class ClosingRun : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام اجرا
    /// Run Name
    /// </summary>
    public string RunName { get; set; } = string.Empty;

    /// <summary>
    /// کد اجرا
    /// Run Code
    /// </summary>
    public string RunCode { get; set; } = string.Empty;

    /// <summary>
    /// نوع اجرا
    /// Run Type
    /// </summary>
    public string RunType { get; set; } = string.Empty;

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal Period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// تاریخ اجرا
    /// Run Date
    /// </summary>
    public DateTime RunDate { get; set; }

    /// <summary>
    /// وضعیت اجرا
    /// Run Status
    /// </summary>
    public string RunStatus { get; set; } = "pending";

    /// <summary>
    /// تاریخ شروع
    /// Start Date
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// تاریخ پایان
    /// End Date
    /// </summary>
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// مدت زمان اجرا (دقیقه)
    /// Execution Duration (minutes)
    /// </summary>
    public int? ExecutionDurationMinutes { get; set; }

    /// <summary>
    /// شناسه کاربر اجرا کننده
    /// Executed By User ID
    /// </summary>
    public Guid ExecutedByUserId { get; set; }

    /// <summary>
    /// شناسه کاربر تایید کننده
    /// Approved By User ID
    /// </summary>
    public Guid? ApprovedByUserId { get; set; }

    /// <summary>
    /// تاریخ تایید
    /// Approval Date
    /// </summary>
    public DateTime? ApprovalDate { get; set; }

    /// <summary>
    /// آیا تایید شده است
    /// Is Approved
    /// </summary>
    public bool IsApproved { get; set; } = false;

    /// <summary>
    /// آیا قابل برگشت است
    /// Is Reversible
    /// </summary>
    public bool IsReversible { get; set; } = true;

    /// <summary>
    /// تاریخ برگشت
    /// Reversal Date
    /// </summary>
    public DateTime? ReversalDate { get; set; }

    /// <summary>
    /// شناسه کاربر برگشت کننده
    /// Reversed By User ID
    /// </summary>
    public Guid? ReversedByUserId { get; set; }

    /// <summary>
    /// دلیل برگشت
    /// Reversal Reason
    /// </summary>
    public string? ReversalReason { get; set; }

    /// <summary>
    /// تعداد سندهای پردازش شده
    /// Processed Documents Count
    /// </summary>
    public int ProcessedDocumentsCount { get; set; } = 0;

    /// <summary>
    /// تعداد خطاها
    /// Error Count
    /// </summary>
    public int ErrorCount { get; set; } = 0;

    /// <summary>
    /// تعداد هشدارها
    /// Warning Count
    /// </summary>
    public int WarningCount { get; set; } = 0;

    /// <summary>
    /// گزارش اجرا
    /// Execution Report
    /// </summary>
    public string? ExecutionReport { get; set; }

    /// <summary>
    /// گزارش خطاها
    /// Error Report
    /// </summary>
    public string? ErrorReport { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// پارامترهای اجرا
    /// Execution Parameters
    /// </summary>
    public string? ExecutionParameters { get; set; }

    /// <summary>
    /// نتایج اجرا
    /// Execution Results
    /// </summary>
    public string? ExecutionResults { get; set; }

    // Navigation Properties
    /// <summary>
    /// دوره مالی
    /// Fiscal Period
    /// </summary>
    public virtual AccFiscalPeriod? FiscalPeriod { get; set; }

    /// <summary>
    /// کاربر اجرا کننده
    /// Executed By User
    /// </summary>
    public virtual User? ExecutedByUser { get; set; }

    /// <summary>
    /// کاربر تایید کننده
    /// Approved By User
    /// </summary>
    public virtual User? ApprovedByUser { get; set; }

    /// <summary>
    /// کاربر برگشت کننده
    /// Reversed By User
    /// </summary>
    public virtual User? ReversedByUser { get; set; }
}

/// <summary>
/// پیکربندی موجودیت اجرای بستن دوره
/// Closing Run entity configuration
/// </summary>
public class ClosingRunConfiguration : IEntityTypeConfiguration<ClosingRun>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<ClosingRun> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.RunName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.RunCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.RunType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.RunStatus)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.ReversalReason)
            .HasMaxLength(1000);

        builder.Property(e => e.ExecutionReport)
            .HasMaxLength(4000);

        builder.Property(e => e.ErrorReport)
            .HasMaxLength(4000);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.ExecutionParameters)
            .HasMaxLength(2000);

        builder.Property(e => e.ExecutionResults)
            .HasMaxLength(2000);

        builder.HasOne(e => e.FiscalPeriod)
            .WithMany()
            .HasForeignKey(e => e.FiscalPeriodId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ExecutedByUser)
            .WithMany()
            .HasForeignKey(e => e.ExecutedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.ApprovedByUser)
            .WithMany()
            .HasForeignKey(e => e.ApprovedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(e => e.ReversedByUser)
            .WithMany()
            .HasForeignKey(e => e.ReversedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.RunCode)
            .IsUnique();

        builder.HasIndex(e => e.FiscalPeriodId);
        builder.HasIndex(e => e.RunDate);
        builder.HasIndex(e => e.RunStatus);
    }
}
