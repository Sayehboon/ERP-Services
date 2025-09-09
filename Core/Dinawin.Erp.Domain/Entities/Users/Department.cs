using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Users;

/// <summary>
/// موجودیت بخش
/// Department entity
/// </summary>
public class Department : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام بخش
    /// Department name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد بخش
    /// Department code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// توضیحات بخش
    /// Department description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// Company ID
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// شرکت
    /// Company
    /// </summary>
    public Company Company { get; set; } = null!;

    /// <summary>
    /// شناسه بخش والد
    /// Parent department ID
    /// </summary>
    public Guid? ParentDepartmentId { get; set; }

    /// <summary>
    /// بخش والد
    /// Parent department
    /// </summary>
    public Department? ParentDepartment { get; set; }

    /// <summary>
    /// زیربخش‌ها
    /// Sub-departments
    /// </summary>
    public ICollection<Department> SubDepartments { get; set; } = new List<Department>();

    /// <summary>
    /// شناسه مدیر بخش
    /// Department manager ID
    /// </summary>
    public Guid? ManagerId { get; set; }

    /// <summary>
    /// مدیر بخش
    /// Department manager
    /// </summary>
    public User? Manager { get; set; }

    /// <summary>
    /// وضعیت فعال/غیرفعال
    /// Active status
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int SortOrder { get; set; }

    /// <summary>
    /// مسیر کامل بخش
    /// Full department path
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// سطح بخش
    /// Department level
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// کاربران این بخش
    /// Department users
    /// </summary>
    public ICollection<User> Users { get; set; } = new List<User>();
    public string? Phone { get; set; }
    public string? HierarchyPath { get; set; }
    public string? DepartmentType { get; set; }
    public decimal? Budget { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
}

/// <summary>
/// پیکربندی موجودیت بخش
/// Department entity configuration
/// </summary>
public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Path).HasMaxLength(500);
        builder.Property(e => e.HierarchyPath).HasMaxLength(500);
        builder.Property(e => e.DepartmentType).HasMaxLength(100);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.Email).HasMaxLength(100);

        builder.Property(e => e.Budget).HasColumnType("decimal(18,2)");

        builder.HasOne(e => e.Company)
            .WithMany(c => c.Departments)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.ParentDepartment)
            .WithMany(d => d.SubDepartments)
            .HasForeignKey(e => e.ParentDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Manager)
            .WithMany()
            .HasForeignKey(e => e.ManagerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.ParentDepartmentId);
    }
}
