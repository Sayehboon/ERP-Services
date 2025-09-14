using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Domain.Entities.Systems;

/// <summary>
/// عملیات/منو/اکشن مطابق Supabase public.operations
/// Operation/menu/action entity aligned with Supabase
/// </summary>
public class Operation : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// نام عملیات
    /// Operation name
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// کد عملیات
    /// Operation code
    /// </summary>
    public required string Code { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// نوع عملیات: action | menu | api
    /// Operation type
    /// </summary>
    public required string Type { get; set; }

    /// <summary>
    /// مسیر (برای menu/api)
    /// Path
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// متد HTTP (برای api)
    /// HTTP method
    /// </summary>
    public string Method { get; set; }

    /// <summary>
    /// شناسه کنسول والد
    /// Console ID
    /// </summary>
    public Guid? ConsoleId { get; set; }

    /// <summary>
    /// کنسول والد
    /// Console
    /// </summary>
    public Console? Console { get; set; }

    /// <summary>
    /// عملیات والد
    /// Parent operation
    /// </summary>
    public Guid? ParentOperationId { get; set; }

    /// <summary>
    /// ناوبری عملیات والد
    /// Parent operation navigation
    /// </summary>
    public Operation? ParentOperation { get; set; }

    /// <summary>
    /// فرزندان
    /// Children
    /// </summary>
    public ICollection<Operation> Children { get; set; } = new List<Operation>();

    /// <summary>
    /// ترتیب نمایش
    /// Display order
    /// </summary>
    public int DisplayOrder { get; set; }
}

/// <summary>
/// پیکربندی موجودیت عملیات
/// Operation entity configuration
/// </summary>
public class OperationConfiguration : IEntityTypeConfiguration<Operation>
{
    public void Configure(EntityTypeBuilder<Operation> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Name).IsRequired().HasMaxLength(200);
        builder.Property(e => e.Code).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.Type).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Path).HasMaxLength(500);
        builder.Property(e => e.Method).HasMaxLength(20);

        builder.HasOne(e => e.Console)
            .WithMany(c => c.Operations)
            .HasForeignKey(e => e.ConsoleId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(e => e.ParentOperation)
            .WithMany(p => p.Children)
            .HasForeignKey(e => e.ParentOperationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.ConsoleId);
        builder.HasIndex(e => e.ParentOperationId);
    }
}


