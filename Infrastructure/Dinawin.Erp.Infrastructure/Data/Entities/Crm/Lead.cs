using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Crm;

/// <summary>
/// Entity for CRM Leads - لیدها و مشتریان بالقوه
/// </summary>
[Table("crm_leads")]
public class Lead
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Email { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(200)]
    public string? Company { get; set; }

    [MaxLength(50)]
    public string? Source { get; set; } // منبع معرفی

    [MaxLength(50)]
    public string Status { get; set; } = "جدید"; // جدید، مقدماتی، کالیفای شده، رد شده

    public int Score { get; set; } = 0; // امتیاز لید

    public decimal? Value { get; set; } // ارزش احتمالی

    [MaxLength(1000)]
    public string? Notes { get; set; }

    public DateTime? LastContactDate { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}
