using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت حقوق کارمند
/// Employee Salary entity
/// </summary>
public class EmployeeSalary : BaseEntity
{
    /// <summary>
    /// شناسه کارمند
    /// Employee ID
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// حقوق پایه
    /// Base salary
    /// </summary>
    public decimal BaseSalary { get; set; }

    /// <summary>
    /// اضافه کار
    /// Overtime pay
    /// </summary>
    public decimal OvertimePay { get; set; }

    /// <summary>
    /// پاداش
    /// Bonus
    /// </summary>
    public decimal Bonus { get; set; }

    /// <summary>
    /// کسر
    /// Deductions
    /// </summary>
    public decimal Deductions { get; set; }

    /// <summary>
    /// حقوق نهایی
    /// Final salary
    /// </summary>
    public decimal FinalSalary { get; set; }

    /// <summary>
    /// ارز حقوق
    /// Salary currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// دوره حقوق
    /// Salary period
    /// </summary>
    public string Period { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ شروع دوره
    /// Period start date
    /// </summary>
    public DateTime PeriodStartDate { get; set; }

    /// <summary>
    /// تاریخ پایان دوره
    /// Period end date
    /// </summary>
    public DateTime PeriodEndDate { get; set; }

    /// <summary>
    /// وضعیت پرداخت
    /// Payment status
    /// </summary>
    public string PaymentStatus { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ پرداخت
    /// Payment date
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// توضیحات حقوق
    /// Salary description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// یادداشت‌های حقوق
    /// Salary notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// کارمند مرتبط
    /// Related employee
    /// </summary>
    public Employee Employee { get; set; } = null!;

    /// <summary>
    /// کاربر ایجادکننده
    /// Created by user
    /// </summary>
    public User? CreatedByUser { get; set; }

    /// <summary>
    /// شناسه حقوق کارمند (alias for Id)
    /// Employee salary ID alias
    /// </summary>
    public Guid EmployeeSalaryId => Id;
}

/// <summary>
/// پیکربندی موجودیت حقوق کارمند
/// Employee Salary entity configuration
/// </summary>
public class EmployeeSalaryConfiguration : IEntityTypeConfiguration<EmployeeSalary>
{
    public void Configure(EntityTypeBuilder<EmployeeSalary> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Currency).HasMaxLength(10);
        builder.Property(e => e.Period).IsRequired().HasMaxLength(50);
        builder.Property(e => e.PaymentStatus).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.Property(e => e.BaseSalary).HasPrecision(18, 2);
        builder.Property(e => e.OvertimePay).HasPrecision(18, 2);
        builder.Property(e => e.Bonus).HasPrecision(18, 2);
        builder.Property(e => e.Deductions).HasPrecision(18, 2);
        builder.Property(e => e.FinalSalary).HasPrecision(18, 2);

        builder.HasOne(e => e.Employee)
            .WithMany(emp => emp.Salaries)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.CreatedByUser)
            .WithMany()
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.EmployeeId);
        builder.HasIndex(e => e.PeriodStartDate);
        builder.HasIndex(e => e.PaymentStatus);
    }
}
