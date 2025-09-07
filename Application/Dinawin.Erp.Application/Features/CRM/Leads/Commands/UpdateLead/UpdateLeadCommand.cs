using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Commands.UpdateLead;

/// <summary>
/// دستور به‌روزرسانی لید
/// </summary>
public sealed class UpdateLeadCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه لید
    /// </summary>
    [Required(ErrorMessage = "شناسه لید الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام لید
    /// </summary>
    [Required(ErrorMessage = "نام لید الزامی است")]
    [StringLength(200, ErrorMessage = "نام لید نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// نام شرکت
    /// </summary>
    [StringLength(200, ErrorMessage = "نام شرکت نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? CompanyName { get; set; }

    /// <summary>
    /// آدرس ایمیل
    /// </summary>
    [EmailAddress(ErrorMessage = "فرمت آدرس ایمیل نامعتبر است")]
    [StringLength(200, ErrorMessage = "آدرس ایمیل نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string? Email { get; set; }

    /// <summary>
    /// شماره تلفن
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره تلفن نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Phone { get; set; }

    /// <summary>
    /// شماره موبایل
    /// </summary>
    [StringLength(20, ErrorMessage = "شماره موبایل نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Mobile { get; set; }

    /// <summary>
    /// آدرس
    /// </summary>
    [StringLength(500, ErrorMessage = "آدرس نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Address { get; set; }

    /// <summary>
    /// شهر
    /// </summary>
    [StringLength(100, ErrorMessage = "نام شهر نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? City { get; set; }

    /// <summary>
    /// استان
    /// </summary>
    [StringLength(100, ErrorMessage = "نام استان نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Province { get; set; }

    /// <summary>
    /// کد پستی
    /// </summary>
    [StringLength(10, ErrorMessage = "کد پستی نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string? PostalCode { get; set; }

    /// <summary>
    /// منبع لید
    /// </summary>
    [StringLength(100, ErrorMessage = "منبع لید نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? LeadSource { get; set; }

    /// <summary>
    /// وضعیت لید
    /// </summary>
    [StringLength(50, ErrorMessage = "وضعیت لید نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Status { get; set; } = "New";

    /// <summary>
    /// اولویت
    /// </summary>
    [StringLength(20, ErrorMessage = "اولویت نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string? Priority { get; set; }

    /// <summary>
    /// ارزش احتمالی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "ارزش احتمالی باید مثبت باشد")]
    public decimal? EstimatedValue { get; set; }

    /// <summary>
    /// تاریخ احتمالی بسته شدن
    /// </summary>
    public DateTime? ExpectedCloseDate { get; set; }

    /// <summary>
    /// شناسه کاربر مسئول
    /// </summary>
    public Guid? AssignedToId { get; set; }

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
