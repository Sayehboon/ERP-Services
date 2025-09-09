using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت شرکت
/// Company entity
/// </summary>
public class Company : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام شرکت
    /// Company name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// نام تجاری
    /// Trade name
    /// </summary>
    public string? TradeName { get; set; }

    /// <summary>
    /// شناسه ملی شرکت
    /// National ID
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره ثبت
    /// Registration number
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// کد اقتصادی
    /// Economic code
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// آدرس شرکت
    /// Company address
    /// </summary>
    public Address? Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// Phone number
    /// </summary>
    public PhoneNumber? PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل شرکت
    /// Company email
    /// </summary>
    public Email? Email { get; set; }

    /// <summary>
    /// وب‌سایت شرکت
    /// Company website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// نوع شرکت
    /// Company type
    /// </summary>
    public CompanyType Type { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// کاربران این شرکت
    /// Company users
    /// </summary>
    public ICollection<User> Users { get; set; } = new List<User>();

    /// <summary>
    /// بخش‌های این شرکت
    /// Company departments
    /// </summary>
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}

/// <summary>
/// انواع شرکت
/// Company types
/// </summary>
public enum CompanyType
{
    /// <summary>
    /// شرکت خصوصی
    /// Private company
    /// </summary>
    Private = 1,

    /// <summary>
    /// شرکت دولتی
    /// Government company
    /// </summary>
    Government = 2,

    /// <summary>
    /// شرکت سهامی عام
    /// Public company
    /// </summary>
    Public = 3,

    /// <summary>
    /// شرکت با مسئولیت محدود
    /// Limited liability company
    /// </summary>
    Limited = 4
}

/// <summary>
/// پیکربندی موجودیت شرکت
/// Company entity configuration
/// </summary>
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.TradeName).HasMaxLength(200);
        builder.Property(e => e.NationalId).HasMaxLength(50);
        builder.Property(e => e.RegistrationNumber).HasMaxLength(50);
        builder.Property(e => e.EconomicCode).HasMaxLength(50);
        builder.Property(e => e.Website).HasMaxLength(200);

        builder.HasIndex(e => e.NationalId).IsUnique(false);
        builder.HasIndex(e => e.RegistrationNumber).IsUnique(false);
        builder.HasIndex(e => e.Name);
    }
}
