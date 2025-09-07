using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dinawin.Erp.Infrastructure.Data.Entities.Crm;

/// <summary>
/// Entity for CRM Tickets - تیکت‌های پشتیبانی
/// </summary>
[Table("crm_tickets")]
public class Ticket
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? CustomerName { get; set; }

    [MaxLength(100)]
    public string? ContactName { get; set; }

    [MaxLength(50)]
    public string Category { get; set; } = "عمومی"; // شکایت، سوال، درخواست، گزارش باگ

    [MaxLength(50)]
    public string Priority { get; set; } = "متوسط"; // بالا، متوسط، پایین

    [MaxLength(50)]
    public string Status { get; set; } = "باز"; // باز، در حال بررسی، حل شده، بسته

    [MaxLength(100)]
    public string? AssignedTo { get; set; } // مسئول رسیدگی

    [MaxLength(2000)]
    public string? Description { get; set; }

    public int ResponseCount { get; set; } = 0; // تعداد پاسخ‌ها

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public Guid? CreatedBy { get; set; }

    public Guid? UpdatedBy { get; set; }

    public bool IsActive { get; set; } = true;
}
