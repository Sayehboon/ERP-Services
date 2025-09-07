using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Crm;

/// <summary>
/// Entity for CRM Opportunities - فرصت‌های فروش
/// </summary>
[Table("crm_opportunities")]
public class Opportunity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? AccountName { get; set; }

    [MaxLength(100)]
    public string? ContactName { get; set; }

    [MaxLength(50)]
    public string Stage { get; set; } = "مقدماتی"; // مقدماتی، مذاکره، پیشنهاد، بسته شده، از دست رفته

    public int Probability { get; set; } = 0; // درصد احتمال موفقیت

    public decimal Value { get; set; } = 0; // ارزش فرصت

    public DateTime? CloseDate { get; set; } // تاریخ بسته شدن

    [MaxLength(50)]
    public string? Source { get; set; } // منبع فرصت

    [MaxLength(100)]
    public string? Owner { get; set; } // مالک فرصت

    [MaxLength(1000)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}
