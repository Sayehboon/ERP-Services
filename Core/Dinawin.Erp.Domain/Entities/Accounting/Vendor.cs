namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

/// <summary>
/// موجودیت تامین‌کننده
/// Vendor entity
/// </summary>
public class Vendor : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// کد تامین‌کننده
    /// Vendor code
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// نام تامین‌کننده
    /// Vendor name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// فعال است؟
    /// Is active?
    /// </summary>
    public bool IsActive { get; set; } = true;
    public string LastName { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string VendorType { get; set; } = string.Empty;
    public string NationalId { get; set; } = string.Empty;
    public string EconomicCode { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public string Gender { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal AccountBalance { get; set; }
    public string PaymentTerms { get; set; } = string.Empty;
    public string PreferredCurrency { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? ContactName { get; set; }
    public decimal DiscountRate { get; set; }
    public string? Notes { get; set; }

    /// <summary>
    /// صورتحساب‌های خرید تامین‌کننده
    /// Vendor purchase bills
    /// </summary>
    public ICollection<PurchaseBill> PurchaseBills { get; set; } = new List<PurchaseBill>();
}

/// <summary>
/// پیکربندی موجودیت تامین‌کننده
/// Vendor entity configuration
/// </summary>
public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
{
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).HasMaxLength(50);
        builder.Property(e => e.Name).HasMaxLength(200);
        builder.Property(e => e.LastName).HasMaxLength(100);
        builder.Property(e => e.CompanyName).HasMaxLength(200);
        builder.Property(e => e.VendorType).HasMaxLength(50);
        builder.Property(e => e.NationalId).HasMaxLength(50);
        builder.Property(e => e.EconomicCode).HasMaxLength(50);
        builder.Property(e => e.RegistrationNumber).HasMaxLength(50);
        builder.Property(e => e.Phone).HasMaxLength(20);
        builder.Property(e => e.Mobile).HasMaxLength(20);
        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Address).HasMaxLength(500);
        builder.Property(e => e.City).HasMaxLength(100);
        builder.Property(e => e.Province).HasMaxLength(100);
        builder.Property(e => e.PostalCode).HasMaxLength(20);
        builder.Property(e => e.Country).HasMaxLength(100);
        builder.Property(e => e.Website).HasMaxLength(200);
        builder.Property(e => e.Gender).HasMaxLength(20);
        builder.Property(e => e.JobTitle).HasMaxLength(100);
        builder.Property(e => e.PaymentTerms).HasMaxLength(100);
        builder.Property(e => e.PreferredCurrency).HasMaxLength(10);
        builder.Property(e => e.Description).HasMaxLength(1000);
        builder.Property(e => e.ContactName).HasMaxLength(200);
        builder.Property(e => e.Notes).HasMaxLength(2000);

        builder.Property(e => e.CreditLimit).HasColumnType("decimal(18,2)");
        builder.Property(e => e.AccountBalance).HasColumnType("decimal(18,2)");
        builder.Property(e => e.DiscountRate).HasColumnType("decimal(5,2)");

        builder.HasIndex(e => e.Code).IsUnique(false);
        builder.HasIndex(e => e.Name);
        builder.HasIndex(e => e.Email);
    }
}

