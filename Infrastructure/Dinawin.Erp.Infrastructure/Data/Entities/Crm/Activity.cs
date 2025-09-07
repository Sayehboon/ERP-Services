using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Crm;

/// <summary>
/// Entity for CRM Activities - تماس‌ها، ملاقات‌ها، ایمیل‌ها و وظایف
/// </summary>
[Table("crm_activities")]
public class Activity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(20)]
    public string Type { get; set; } = string.Empty; // تماس، ملاقات، ایمیل، وظیفه

    [Required]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? ContactName { get; set; }

    [MaxLength(100)]
    public string? AccountName { get; set; }

    public DateTime? DueDate { get; set; }

    [MaxLength(20)]
    public string Status { get; set; } = "برنامه‌ریزی شده"; // انجام شده، در حال انجام، برنامه‌ریزی شده، معوقه

    [MaxLength(20)]
    public string Priority { get; set; } = "متوسط"; // بالا، متوسط، پایین

    [MaxLength(100)]
    public string? AssignedTo { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}
