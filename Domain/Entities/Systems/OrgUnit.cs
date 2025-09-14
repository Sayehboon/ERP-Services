using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// واحد سازمانی
/// Organizational Unit
/// </summary>
public class OrgUnit : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام واحد
    /// Unit Name
    /// </summary>
    public string UnitName { get; set; } = string.Empty;

    /// <summary>
    /// کد واحد
    /// Unit Code
    /// </summary>
    public string UnitCode { get; set; } = string.Empty;

    /// <summary>
    /// نوع واحد
    /// Unit Type
    /// </summary>
    public string UnitType { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// شناسه واحد والد
    /// Parent Unit ID
    /// </summary>
    public Guid? ParentUnitId { get; set; }

    /// <summary>
    /// سطح واحد
    /// Unit Level
    /// </summary>
    public int UnitLevel { get; set; } = 1;

    /// <summary>
    /// مسیر سلسله مراتبی
    /// Hierarchy Path
    /// </summary>
    public string HierarchyPath { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Display Order
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    /// <summary>
    /// شناسه شعبه
    /// Branch ID
    /// </summary>
    public Guid? BranchId { get; set; }

    /// <summary>
    /// شناسه مدیر واحد
    /// Manager User ID
    /// </summary>
    public Guid? ManagerUserId { get; set; }

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
    /// آدرس
    /// Address
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// شماره تلفن
    /// Phone Number
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل
    /// Email
    /// </summary>
    public string Email { get; set; }

    // Navigation Properties
    /// <summary>
    /// واحد والد
    /// Parent Unit
    /// </summary>
    public virtual OrgUnit? ParentUnit { get; set; }

    /// <summary>
    /// واحدهای فرزند
    /// Child Units
    /// </summary>
    public virtual ICollection<OrgUnit> ChildUnits { get; set; } = new List<OrgUnit>();

    /// <summary>
    /// شعبه
    /// Branch
    /// </summary>
    public virtual Branch? Branch { get; set; }

    /// <summary>
    /// کاربر مدیر
    /// Manager User
    /// </summary>
    public virtual User? ManagerUser { get; set; }

    /// <summary>
    /// کاربران واحد
    /// Unit Users
    /// </summary>
    public virtual ICollection<UserOrgUnit> UnitUsers { get; set; } = new List<UserOrgUnit>();
}

/// <summary>
/// پیکربندی موجودیت واحد سازمانی
/// Organizational Unit entity configuration
/// </summary>
public class OrgUnitConfiguration : IEntityTypeConfiguration<OrgUnit>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<OrgUnit> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.UnitName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.UnitCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.UnitType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.Property(e => e.Address)
            .HasMaxLength(500);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.HasOne(e => e.ParentUnit)
            .WithMany(e => e.ChildUnits)
            .HasForeignKey(e => e.ParentUnitId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Branch)
            .WithMany()
            .HasForeignKey(e => e.BranchId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ManagerUser)
            .WithMany()
            .HasForeignKey(e => e.ManagerUserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasIndex(e => e.UnitCode).IsUnique();
        builder.HasIndex(e => e.ParentUnitId);
        builder.HasIndex(e => e.BranchId);
        builder.HasIndex(e => e.ManagerUserId);
    }
}
