namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

/// <summary>
/// موجودیت مشتری
/// Customer entity
/// </summary>
public class Customer : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد مشتری
    /// Customer code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام مشتری
    /// Customer name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام خانوادگی
    /// Last name
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// نام شرکت
    /// Company name
    /// </summary>
    public string? CompanyName { get; set; }

    /// <summary>
    /// نوع مشتری
    /// Customer type
    /// </summary>
    public string CustomerType { get; set; } = string.Empty;

    /// <summary>
    /// شماره/شناسه ملی
    /// National ID
    /// </summary>
    public string? NationalId { get; set; }

    /// <summary>
    /// شماره اقتصادی
    /// Economic code
    /// </summary>
    public string? EconomicCode { get; set; }

    /// <summary>
    /// شماره ثبت
    /// Registration number
    /// </summary>
    public string? RegistrationNumber { get; set; }

    /// <summary>
    /// تلفن
    /// Phone
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// موبایل
    /// Mobile
    /// </summary>
    public string? Mobile { get; set; }

    /// <summary>
    /// ایمیل
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// آدرس
    /// Address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// City
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// Province
    /// </summary>
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی
    /// Postal code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// کشور
    /// Country
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// وب‌سایت
    /// Website
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// تاریخ تولد
    /// Birth date
    /// </summary>
    public DateTime? BirthDate { get; set; }

    /// <summary>
    /// جنسیت
    /// Gender
    /// </summary>
    public string? Gender { get; set; }

    /// <summary>
    /// عنوان شغلی
    /// Job title
    /// </summary>
    public string? JobTitle { get; set; }

    /// <summary>
    /// سقف اعتبار
    /// Credit limit
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// مانده حساب
    /// Account balance
    /// </summary>
    public decimal? AccountBalance { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// سفارش‌های فروش مشتری
    /// Customer sales orders
    /// </summary>
    public ICollection<Dinawin.Erp.Domain.Entities.Sales.SalesOrder> SalesOrders { get; set; } = new List<Dinawin.Erp.Domain.Entities.Sales.SalesOrder>();
    public string? ContactName { get; set; }
    public string? PreferredCurrency { get; set; }
    public string? PaymentTerms { get; set; }
    public decimal DiscountRate { get; set; }
    public string? Notes { get; set; }
}

/// <summary>
/// پیکربندی موجودیت مشتری
/// Customer entity configuration
/// </summary>
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.CompanyName).HasMaxLength(200);
        builder.Property(e => e.CustomerType).HasMaxLength(50);
        builder.Property(e => e.NationalId).HasMaxLength(50);
        builder.Property(e => e.EconomicCode).HasMaxLength(50);
        builder.Property(e => e.RegistrationNumber).HasMaxLength(50);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Province).HasMaxLength(100);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.Website).HasMaxLength(200);
        builder.Property(e => e.Gender).HasMaxLength(20);
        builder.Property(e => e.JobTitle).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ContactName).HasMaxLength(200);
        builder.Property(e => e.PreferredCurrency).HasMaxLength(10);
        builder.Property(e => e.PaymentTerms).HasMaxLength(100);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.Property(e => e.CreditLimit).HasColumnType("decimal(18,2)");
        builder.Property(e => e.AccountBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.DiscountRate).HasColumnType("decimal(5,2)");

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Email);
    }
}

