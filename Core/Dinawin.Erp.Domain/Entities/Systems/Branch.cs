using Dinawin.Erp.Domain.Common;
using Dinawin.Erp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// شعبه
/// Branch
/// </summary>
public class Branch : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام شعبه
    /// Branch Name
    /// </summary>
    public string BranchName { get; set; } = string.Empty;

    /// <summary>
    /// کد شعبه
    /// Branch Code
    /// </summary>
    public string BranchCode { get; set; } = string.Empty;

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
    /// Postal Code
    /// </summary>
    public string? PostalCode { get; set; }

    /// <summary>
    /// شماره تلفن
    /// Phone Number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// ایمیل
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// مدیر شعبه
    /// Branch Manager
    /// </summary>
    public string? BranchManager { get; set; }

    /// <summary>
    /// شناسه کاربر مدیر
    /// Manager User ID
    /// </summary>
    public Guid? ManagerUserId { get; set; }

    /// <summary>
    /// آیا فعال است
    /// Is Active
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// نوع شعبه
    /// Branch Type
    /// </summary>
    public string? BranchType { get; set; }

    /// <summary>
    /// سطح شعبه
    /// Branch Level
    /// </summary>
    public int BranchLevel { get; set; } = 1;

    /// <summary>
    /// شناسه شعبه والد
    /// Parent Branch ID
    /// </summary>
    public Guid? ParentBranchId { get; set; }

    /// <summary>
    /// مسیر سلسله مراتبی
    /// Hierarchy Path
    /// </summary>
    public string? HierarchyPath { get; set; }

    /// <summary>
    /// ترتیب نمایش
    /// Display Order
    /// </summary>
    public int DisplayOrder { get; set; } = 0;

    // Navigation Properties
    /// <summary>
    /// کاربر مدیر
    /// Manager User
    /// </summary>
    public virtual User? ManagerUser { get; set; }

    /// <summary>
    /// شعبه والد
    /// Parent Branch
    /// </summary>
    public virtual Branch? ParentBranch { get; set; }

    /// <summary>
    /// شعبه های فرزند
    /// Child Branches
    /// </summary>
    public virtual ICollection<Branch> ChildBranches { get; set; } = new List<Branch>();
}

/// <summary>
/// پیکربندی موجودیت شعبه
/// Branch entity configuration
/// </summary>
public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.BranchName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.BranchCode)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Address)
            .HasMaxLength(500);

        builder.Property(e => e.City)
            .HasMaxLength(100);

        builder.Property(e => e.Province)
            .HasMaxLength(100);

        builder.Property(e => e.PostalCode)
            .HasMaxLength(20);

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(e => e.Email)
            .HasMaxLength(100);

        builder.Property(e => e.BranchManager)
            .HasMaxLength(150);

        builder.Property(e => e.BranchType)
            .HasMaxLength(100);

        builder.Property(e => e.HierarchyPath)
            .HasMaxLength(500);

        builder.HasOne(e => e.ManagerUser)
            .WithMany()
            .HasForeignKey(e => e.ManagerUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ParentBranch)
            .WithMany(e => e.ChildBranches)
            .HasForeignKey(e => e.ParentBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.BranchCode).IsUnique();
        builder.HasIndex(e => e.ManagerUserId);
        builder.HasIndex(e => e.ParentBranchId);
    }
}
