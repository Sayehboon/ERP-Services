using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dinawin.Erp.Domain.Entities.Users;

namespace Dinawin.Erp.Persistence.Configurations;

/// <summary>
/// پیکربندی موجودیت شرکت
/// Company entity configuration
/// </summary>
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    /// <summary>
    /// پیکربندی موجودیت شرکت
    /// Configure company entity
    /// </summary>
    /// <param name="builder">سازنده موجودیت</param>
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies", "Identity");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.TradeName)
            .HasMaxLength(200);

        builder.Property(c => c.NationalId)
            .HasMaxLength(20);

        builder.Property(c => c.RegistrationNumber)
            .HasMaxLength(50);

        builder.Property(c => c.EconomicCode)
            .HasMaxLength(50);

        builder.Property(c => c.Website)
            .HasMaxLength(500);

        builder.Property(c => c.Type)
            .IsRequired()
            .HasConversion<string>();

        // پیکربندی Value Objects
        builder.OwnsOne(c => c.Address, address =>
        {
            address.Property(a => a.Street)
                .HasColumnName("AddressStreet")
                .HasMaxLength(500);
            
            address.Property(a => a.City)
                .HasColumnName("AddressCity")
                .HasMaxLength(100);
            
            address.Property(a => a.State)
                .HasColumnName("AddressState")
                .HasMaxLength(100);
            
            address.Property(a => a.PostalCode)
                .HasColumnName("AddressPostalCode")
                .HasMaxLength(20);
            
            address.Property(a => a.Country)
                .HasColumnName("AddressCountry")
                .HasMaxLength(100);
        });

        builder.OwnsOne(c => c.PhoneNumber, phone =>
        {
            phone.Property(p => p.Value)
                .HasColumnName("PhoneNumber")
                .HasMaxLength(20);
            
            phone.Property(p => p.LocalNumber)
                .HasColumnName("PhoneLocalNumber")
                .HasMaxLength(15);
            
            phone.Property(p => p.CountryCode)
                .HasColumnName("PhoneCountryCode")
                .HasMaxLength(5);
        });

        builder.OwnsOne(c => c.Email, email =>
        {
            email.Property(e => e.Value)
                .HasColumnName("Email")
                .HasMaxLength(200);
        });

        // روابط - تعریف شده در UserConfiguration و DepartmentConfiguration
        // برای جلوگیری از تداخل cascade paths، روابط در طرف مقابل تعریف می‌شوند

        // ایندکس‌ها
        builder.HasIndex(c => c.Name)
            .HasDatabaseName("IX_Companies_Name");

        builder.HasIndex(c => c.NationalId)
            .IsUnique()
            .HasDatabaseName("IX_Companies_NationalId");

        builder.HasIndex(c => c.RegistrationNumber)
            .IsUnique()
            .HasDatabaseName("IX_Companies_RegistrationNumber");

        builder.HasIndex(c => c.EconomicCode)
            .IsUnique()
            .HasDatabaseName("IX_Companies_EconomicCode");
    }
}
