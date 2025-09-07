using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Crm;

/// <summary>
/// Entity for CRM Accounts - حساب‌ها و شرکت‌ها
/// </summary>
[Table("crm_accounts")]
public class Account
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(50)]
    public string? Code { get; set; }

    [MaxLength(200)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(20)]
    public string? Fax { get; set; }

    [MaxLength(500)]
    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(20)]
    public string? PostalCode { get; set; }

    [MaxLength(100)]
    public string? Country { get; set; }

    [MaxLength(100)]
    public string? Website { get; set; }

    [MaxLength(50)]
    public string? Industry { get; set; } // صنعت

    [MaxLength(50)]
    public string? Type { get; set; } = "مشتری"; // مشتری، تامین‌کننده، شریک

    [MaxLength(50)]
    public string? Status { get; set; } = "فعال"; // فعال، غیرفعال، مشتری بالقوه

    [MaxLength(1000)]
    public string? Description { get; set; }

    public decimal? AnnualRevenue { get; set; }

    public int? EmployeeCount { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}
