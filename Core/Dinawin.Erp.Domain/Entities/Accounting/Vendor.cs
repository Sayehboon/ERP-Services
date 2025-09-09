namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;
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


