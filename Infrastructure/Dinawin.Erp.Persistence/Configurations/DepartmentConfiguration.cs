using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Users;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت بخش
/// Department entity configuration
/// </summary>
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    /// <summary>
    /// پیکربندی موجودیت بخش
    /// Configure department entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments", "Identity");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Code)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(d => d.Description)
            .HasMaxLength(1000);

        builder.Property(d => d.Path)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(d => d.Level)
            .IsRequired();

        builder.Property(d => d.SortOrder)
            .HasDefaultValue(0);

        // روابط
        builder.HasOne(d => d.Company)
            .WithMany(c => c.Departments)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(d => d.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(d => d.ParentDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Company)
            .WithMany(c => c.Departments)
            .HasForeignKey(d => d.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Manager)
            .WithMany()
            .HasForeignKey(d => d.ManagerId)
            .OnDelete(DeleteBehavior.Restrict);

        // رابطه با Users در UserConfiguration تعریف شده است

        // ایندکس‌ها
        builder.HasIndex(d => new { d.CompanyId, d.Code })
            .IsUnique()
            .HasDatabaseName("IX_Departments_CompanyId_Code");

        builder.HasIndex(d => new { d.CompanyId, d.Name })
            .HasDatabaseName("IX_Departments_CompanyId_Name");

        builder.HasIndex(d => d.ParentDepartmentId)
            .HasDatabaseName("IX_Departments_ParentDepartmentId");

        builder.HasIndex(d => d.ManagerId)
            .HasDatabaseName("IX_Departments_ManagerId");

        builder.HasIndex(d => new { d.CompanyId, d.Level, d.SortOrder })
            .HasDatabaseName("IX_Departments_Company_Level_Sort");
    }
}
