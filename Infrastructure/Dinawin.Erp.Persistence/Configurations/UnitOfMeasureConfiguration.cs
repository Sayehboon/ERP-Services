using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Products;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت واحد اندازه‌گیری
/// Unit of measure entity configuration
/// </summary>
public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
	/// <summary>
	/// پیکربندی موجودیت واحد اندازه‌گیری
	/// Configure unit of measure entity
	/// </summary>
	/// <param name="builder">سازنده موجودیت</param>
	public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
	{
		builder.ToTable("UnitsOfMeasure", "Product");

		builder.HasKey(u => u.Id);

		builder.Property(u => u.Code)
			.IsRequired()
			.HasMaxLength(30);

		builder.Property(u => u.Name)
			.IsRequired()
			.HasMaxLength(100);

		builder.Property(u => u.Symbol)
			.IsRequired()
			.HasMaxLength(10);

		builder.Property(u => u.Description)
			.HasMaxLength(500);

		builder.Property(u => u.Type)
			.IsRequired()
			.HasConversion<string>();

		builder.Property(u => u.ConversionFactor)
			.HasColumnType("decimal(18,6)")
			.HasDefaultValue(1);

		builder.Property(u => u.Precision)
			.HasDefaultValue(0);

		builder.Property(u => u.IsSystemDefault)
			.HasDefaultValue(false);

		// روابط
		builder.HasOne(u => u.BaseUnit)
			.WithMany()
			.HasForeignKey(u => u.BaseUnitId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasMany(u => u.Products)
			.WithOne(p => p.BaseUom)
			.HasForeignKey(p => p.BaseUomId)
			.OnDelete(DeleteBehavior.SetNull);

		// ایندکس‌ها
		builder.HasIndex(u => u.Code)
			.IsUnique()
			.HasDatabaseName("IX_UnitsOfMeasure_Code");

		builder.HasIndex(u => u.Name)
			.HasDatabaseName("IX_UnitsOfMeasure_Name");

		builder.HasIndex(u => u.Symbol)
			.IsUnique()
			.HasDatabaseName("IX_UnitsOfMeasure_Symbol");

		builder.HasIndex(u => u.Type)
			.HasDatabaseName("IX_UnitsOfMeasure_Type");

		builder.HasIndex(u => u.BaseUnitId)
			.HasDatabaseName("IX_UnitsOfMeasure_BaseUnitId");
	}
}
