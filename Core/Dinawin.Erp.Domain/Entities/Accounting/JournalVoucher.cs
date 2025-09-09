namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت سند حسابداری
/// Journal voucher entity
/// </summary>
public class JournalVoucher : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره سند
    /// Voucher number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// شماره ترتیبی
    /// Sequence number
    /// </summary>
    public int? SeqNo { get; set; }

    /// <summary>
    /// تاریخ سند
    /// Voucher date
    /// </summary>
    public DateTime VoucherDate { get; set; }

    /// <summary>
    /// نوع سند
    /// Voucher type
    /// </summary>
    public string Type { get; set; } = "JV"; // JV, SYS, OPEN, CLOSE, ADJ

    /// <summary>
    /// شرح سند
    /// Voucher description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت سند
    /// Voucher status
    /// </summary>
    public string Status { get; set; } = "draft"; // draft, posted, void

    /// <summary>
    /// مرحله تایید
    /// Approval stage
    /// </summary>
    public int? ApprovalStage { get; set; }

    /// <summary>
    /// وضعیت تایید
    /// Approval status
    /// </summary>
    public string? ApprovalStatus { get; set; } // pending, approved, rejected, void

    /// <summary>
    /// شناسه سال مالی
    /// Fiscal year ID
    /// </summary>
    public Guid FiscalYearId { get; set; }

    /// <summary>
    /// شناسه دوره مالی
    /// Fiscal period ID
    /// </summary>
    public Guid FiscalPeriodId { get; set; }

    /// <summary>
    /// ردیف‌های سند
    /// Voucher lines
    /// </summary>
    public ICollection<JournalLine> Lines { get; set; } = new List<JournalLine>();

    /// <summary>
    /// سال مالی مرتبط
    /// Related fiscal year
    /// </summary>
    public FiscalYear? FiscalYear { get; set; }

    /// <summary>
    /// دوره مالی مرتبط
    /// Related fiscal period
    /// </summary>
    public FiscalPeriod? FiscalPeriod { get; set; }
}

/// <summary>
/// ردیف سند حسابداری
/// Journal line entity
/// </summary>
public class JournalLine : BaseEntity
{
    /// <summary>
    /// شناسه سند
    /// Voucher ID
    /// </summary>
    public Guid VoucherId { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account ID
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// شرح ردیف
    /// Line description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// مبلغ بدهکار
    /// Debit amount
    /// </summary>
    public decimal Debit { get; set; }

    /// <summary>
    /// مبلغ بستانکار
    /// Credit amount
    /// </summary>
    public decimal Credit { get; set; }

    /// <summary>
    /// سند مرتبط
    /// Related voucher
    /// </summary>
    public JournalVoucher? Voucher { get; set; }

    /// <summary>
    /// حساب مرتبط
    /// Related account
    /// </summary>
    public Account? Account { get; set; }
}
