using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// کسب‌وکار (مطابق جدول public.businesses در Supabase)
/// Business entity aligned with Supabase public.businesses
/// </summary>
public class Business : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// شرکت
    /// Company
    /// </summary>
    public Company? Company { get; set; }

    /// <summary>
    /// نام کسب‌وکار
    /// Business name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد کسب‌وکار
    /// Business code
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع کسب‌وکار
    /// Business type
    /// </summary>
    public string? BusinessType { get; set; }

    /// <summary>
    /// بخش‌ها
    /// Departments
    /// </summary>
    public ICollection<Department> Departments { get; set; } = new List<Department>();
}

/// <summary>
/// پیکربندی موجودیت کسب‌وکار
/// Business entity configuration
/// </summary>
public class BusinessConfiguration : IEntityTypeConfiguration<Business>
{
    public void Configure(EntityTypeBuilder<Business> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.BusinessType).HasMaxLength(100);

        builder.HasOne(e => e.Company)
            .WithMany()
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
    }
}


