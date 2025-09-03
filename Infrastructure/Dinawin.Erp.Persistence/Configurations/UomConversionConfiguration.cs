using Dinawin.Erp.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی تبدیل واحد
/// UOM conversion configuration
/// </summary>
public class UomConversionConfiguration : IEntityTypeConfiguration<UomConversion>
{
    public void Configure(EntityTypeBuilder<UomConversion> builder)
    {
        builder.ToTable("UomConversions", "Product");

        builder.Property(p => p.Factor)
            .HasColumnType("decimal(18,6)")
            .IsRequired();

        builder.HasOne(p => p.FromUom)
            .WithMany()
            .HasForeignKey(p => p.FromUomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.ToUom)
            .WithMany()
            .HasForeignKey(p => p.ToUomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => new { p.FromUomId, p.ToUomId })
            .IsUnique()
            .HasDatabaseName("IX_UomConversions_From_To");
    }
}


