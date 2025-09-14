using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Commands.UpdateJournalEntry;

/// <summary>
/// دستور به‌روزرسانی سند حسابداری
/// </summary>
public sealed class UpdateJournalEntryCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه سند حسابداری
    /// </summary>
    [Required(ErrorMessage = "شناسه سند حسابداری الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شماره سند
    /// </summary>
    [Required(ErrorMessage = "شماره سند الزامی است")]
    [StringLength(50, ErrorMessage = "شماره سند نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string EntryNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ سند
    /// </summary>
    [Required(ErrorMessage = "تاریخ سند الزامی است")]
    public DateTime EntryDate { get; set; }

    /// <summary>
    /// نوع سند
    /// </summary>
    [Required(ErrorMessage = "نوع سند الزامی است")]
    [StringLength(50, ErrorMessage = "نوع سند نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string EntryType { get; set; } = string.Empty;

    /// <summary>
    /// شرح سند
    /// </summary>
    [Required(ErrorMessage = "شرح سند الزامی است")]
    [StringLength(500, ErrorMessage = "شرح سند نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// شناسه حساب
    /// </summary>
    [Required(ErrorMessage = "شناسه حساب الزامی است")]
    public Guid AccountId { get; set; }

    /// <summary>
    /// مبلغ بدهکار
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ بدهکار نمی‌تواند منفی باشد")]
    public decimal DebitAmount { get; set; }

    /// <summary>
    /// مبلغ بستانکار
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "مبلغ بستانکار نمی‌تواند منفی باشد")]
    public decimal CreditAmount { get; set; }

    /// <summary>
    /// ارز
    /// </summary>
    [StringLength(10, ErrorMessage = "کد ارز نمی‌تواند بیش از 10 کاراکتر باشد")]
    public string Currency { get; set; }

    /// <summary>
    /// نرخ ارز
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "نرخ ارز نمی‌تواند منفی باشد")]
    public decimal? ExchangeRate { get; set; }

    /// <summary>
    /// مرجع سند
    /// </summary>
    [StringLength(100, ErrorMessage = "مرجع سند نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Reference { get; set; }

    /// <summary>
    /// شناسه سند مرجع
    /// </summary>
    public Guid? ReferenceId { get; set; }

    /// <summary>
    /// نوع سند مرجع
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع سند مرجع نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string ReferenceType { get; set; }

    /// <summary>
    /// آیا سند تأیید شده است
    /// </summary>
    public bool IsApproved { get; set; } = false;

    /// <summary>
    /// تاریخ تأیید
    /// </summary>
    public DateTime? ApprovedAt { get; set; }

    /// <summary>
    /// شناسه کاربر تأیید کننده
    /// </summary>
    public Guid? ApprovedBy { get; set; }

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
