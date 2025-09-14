using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Commands.CreateTicket;

/// <summary>
/// دستور ایجاد تیکت
/// </summary>
public sealed class CreateTicketCommand : IRequest<Guid>
{
    /// <summary>
    /// عنوان تیکت
    /// </summary>
    [Required(ErrorMessage = "عنوان تیکت الزامی است")]
    [StringLength(200, ErrorMessage = "عنوان تیکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تیکت
    /// </summary>
    [Required(ErrorMessage = "توضیحات تیکت الزامی است")]
    [StringLength(2000, ErrorMessage = "توضیحات تیکت نمی‌تواند بیش از 2000 کاراکتر باشد")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// نوع تیکت
    /// </summary>
    [Required(ErrorMessage = "نوع تیکت الزامی است")]
    [StringLength(50, ErrorMessage = "نوع تیکت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string TicketType { get; set; } = "Support";

    /// <summary>
    /// اولویت تیکت
    /// </summary>
    [Required(ErrorMessage = "اولویت تیکت الزامی است")]
    [StringLength(20, ErrorMessage = "اولویت تیکت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Priority { get; set; } = "Medium";

    /// <summary>
    /// وضعیت تیکت
    /// </summary>
    [Required(ErrorMessage = "وضعیت تیکت الزامی است")]
    [StringLength(30, ErrorMessage = "وضعیت تیکت نمی‌تواند بیش از 30 کاراکتر باشد")]
    public string Status { get; set; } = "Open";

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedById { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// شناسه محصول مرتبط
    /// </summary>
    public Guid? ProductId { get; set; }

    /// <summary>
    /// شناسه سفارش فروش مرتبط
    /// </summary>
    public Guid? SalesOrderId { get; set; }

    /// <summary>
    /// شناسه فرصت مرتبط
    /// </summary>
    public Guid? OpportunityId { get; set; }

    /// <summary>
    /// تاریخ مهلت
    /// </summary>
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// تاریخ بسته شدن
    /// </summary>
    public DateTime? ClosedDate { get; set; }

    /// <summary>
    /// دلیل بسته شدن
    /// </summary>
    [StringLength(500, ErrorMessage = "دلیل بسته شدن نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string CloseReason { get; set; }

    /// <summary>
    /// تگ‌ها
    /// </summary>
    [StringLength(500, ErrorMessage = "تگ‌ها نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Tags { get; set; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
