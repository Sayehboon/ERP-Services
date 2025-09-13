using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت کارمند
/// Employee entity
/// </summary>
public class Employee : BaseEntity
{
    /// <summary>
    /// نام کارمند
    /// Employee name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی کارمند
    /// Employee last name
    /// </summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>
    /// کد ملی کارمند
    /// Employee national code
    /// </summary>
    public string? NationalCode { get; set; }

    /// <summary>
    /// شماره پرسنلی کارمند
    /// Employee personnel number
    /// </summary>
    public string? PersonnelNumber { get; set; }

    /// <summary>
    /// تاریخ استخدام
    /// Employment date
    /// </summary>
    public DateTime? EmploymentDate { get; set; }

    /// <summary>
    /// تاریخ ترک کار
    /// Termination date
    /// </summary>
    public DateTime? TerminationDate { get; set; }

    /// <summary>
    /// شناسه بخش
    /// Department ID
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// سمت کارمند
    /// Employee position
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// وضعیت کارمند
    /// Employee status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// شماره تلفن کارمند
    /// Employee phone number
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// ایمیل کارمند
    /// Employee email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس کارمند
    /// Employee address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// وضعیت فعال بودن کارمند
    /// Employee active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// کد کارمند (alias for PersonnelNumber)
    /// Employee code alias
    /// </summary>
    public string? EmployeeCode => PersonnelNumber;

    /// <summary>
    /// نام (alias for Name)
    /// First name alias
    /// </summary>
    public string? FirstName => Name;

    /// <summary>
    /// تاریخ استخدام (alias for EmploymentDate)
    /// Hire date alias
    /// </summary>
    public DateTime? HireDate => EmploymentDate;

    /// <summary>
    /// حقوق
    /// Salary
    /// </summary>
    public decimal Salary { get; set; } = 0;

    /// <summary>
    /// آیا قفل شده است
    /// Is locked
    /// </summary>
    public bool IsLocked { get; set; } = false;

    // Navigation properties
    /// <summary>
    /// بخش
    /// Department
    /// </summary>
    public Department? Department { get; set; }

    /// <summary>
    /// شرکت
    /// Company
    /// </summary>
    public Company? Company { get; set; }

    /// <summary>
    /// حقوق‌ها
    /// Salaries
    /// </summary>
    public ICollection<EmployeeSalary> Salaries { get; set; } = new List<EmployeeSalary>();

    /// <summary>
    /// حضور و غیاب‌ها
    /// Attendances
    /// </summary>
    public ICollection<EmployeeAttendance> Attendances { get; set; } = new List<EmployeeAttendance>();

    /// <summary>
    /// مرخصی‌ها
    /// Leaves
    /// </summary>
    public ICollection<Leave> Leaves { get; set; } = new List<Leave>();
}

/// <summary>
/// پیکربندی موجودیت کارمند
/// Employee entity configuration
/// </summary>
public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.NationalCode).HasMaxLength(20);
        builder.Property(e => e.PersonnelNumber).HasMaxLength(50);
        builder.Property(e => e.Position).HasMaxLength(100);
        builder.Property(e => e.Status).HasMaxLength(50);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.Salary).HasPrecision(18, 2);

        builder.HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.PersonnelNumber).IsUnique(false);
        builder.HasIndex(e => e.NationalCode).IsUnique(false);
        builder.HasIndex(e => e.Status);
    }
}
