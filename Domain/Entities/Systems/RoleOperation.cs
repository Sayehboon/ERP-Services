using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// ارتباط نقش و عملیات
/// Role to Operation mapping
/// </summary>
public class RoleOperation : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه نقش
    /// Role Id
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// شناسه عملیات
    /// Operation Id
    /// </summary>
    public Guid OperationId { get; set; }

    /// <summary>
    /// اثر
    /// Effect (allow/deny)
    /// </summary>
    public string Effect { get; set; } = "allow";

    /// <summary>
    /// محدودیت‌ها به صورت JSON
    /// Constraints JSON
    /// </summary>
    public string ConstraintsJson { get; set; } = "{}";

    /// <summary>
    /// ارث‌بری از نقش‌های والد
    /// Inherit from parent roles
    /// </summary>
    public bool Inherit { get; set; } = true;

    /// <summary>
    /// نقش
    /// Role
    /// </summary>
    public virtual Users.Role? Role { get; set; }

    /// <summary>
    /// عملیات
    /// Operation
    /// </summary>
    public virtual Operation? Operation { get; set; }
}

/// <summary>
/// پیکربندی موجودیت ارتباط نقش-عملیات
/// RoleOperation entity configuration
/// </summary>
public class RoleOperationConfiguration : IEntityTypeConfiguration<RoleOperation>
{
    /// <summary>
    /// پیکربندی موجودیت
    /// Configure entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<RoleOperation> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Effect)
            .IsRequired()
            .HasMaxLength(10);

        builder.Property(e => e.ConstraintsJson)
            .IsRequired();

        builder.HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Operation)
            .WithMany()
            .HasForeignKey(e => e.OperationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.RoleId, e.OperationId })
            .IsUnique();

        builder.HasIndex(e => e.RoleId);
        builder.HasIndex(e => e.OperationId);
    }
}
