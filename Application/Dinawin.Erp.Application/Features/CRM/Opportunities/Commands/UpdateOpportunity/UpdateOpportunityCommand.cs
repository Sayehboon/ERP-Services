using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Opportunities.Commands.UpdateOpportunity;

/// <summary>
/// دستور به‌روزرسانی فرصت
/// </summary>
public sealed class UpdateOpportunityCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه فرصت
    /// </summary>
    [Required(ErrorMessage = "شناسه فرصت الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام فرصت
    /// </summary>
    [Required(ErrorMessage = "نام فرصت الزامی است")]
    [StringLength(200, ErrorMessage = "نام فرصت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// شناسه لید
    /// </summary>
    public Guid? LeadId { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// شناسه حساب
    /// </summary>
    public Guid? AccountId { get; set; }

    /// <summary>
    /// مرحله فرصت
    /// </summary>
    [StringLength(50, ErrorMessage = "مرحله فرصت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Stage { get; set; } = "Prospecting";

    /// <summary>
    /// وضعیت فرصت
    /// </summary>
    [StringLength(50, ErrorMessage = "وضعیت فرصت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Status { get; set; } = "Open";

    /// <summary>
    /// احتمال موفقیت (درصد)
    /// </summary>
    [Range(0, 100, ErrorMessage = "احتمال موفقیت باید بین 0 تا 100 باشد")]
    public int Probability { get; set; } = 0;

    /// <summary>
    /// مبلغ فرصت
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ فرصت باید مثبت باشد")]
    public decimal Amount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    [StringLength(10, ErrorMessage = "کد ارز نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// تاریخ بسته شدن مورد انتظار
    /// </summary>
    public DateTime? ExpectedCloseDate { get; set; }

    /// <summary>
    /// تاریخ بسته شدن واقعی
    /// </summary>
    public DateTime? ActualCloseDate { get; set; }

    /// <summary>
    /// نوع فرصت
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع فرصت نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? OpportunityType { get; set; }

    /// <summary>
    /// منبع فرصت
    /// </summary>
    [StringLength(100, ErrorMessage = "منبع فرصت نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Source { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

    /// <summary>
    /// اولویت
    /// </summary>
    [StringLength(20, ErrorMessage = "اولویت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Priority { get; set; }

    /// <summary>
    /// توضیحات
    /// </summary>
    [StringLength(2000, ErrorMessage = "توضیحات نمی‌تواند بیش از 2000 کاراکتر باشد")]
    public string? Notes { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
