namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت ردیف دفتر کل (General Ledger)
/// General ledger entry row entity
/// </summary>
public class GeneralLedgerEntry : BaseEntity
{
    /// <summary>
    /// شناسه سند (Voucher/Journal)
    /// Voucher id
    /// </summary>
    public Guid VoucherId { get; set; }

    /// <summary>
    /// تاریخ سند
    /// Voucher date
    /// </summary>
    public DateTime VoucherDate { get; set; }

    /// <summary>
    /// شماره سند
    /// Voucher number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// شماره ردیف
    /// Line number
    /// </summary>
    public int? LineNo { get; set; }

    /// <summary>
    /// شناسه حساب
    /// Account id
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// کد حساب
    /// Account code
    /// </summary>
    public string AccountCode { get; set; } = string.Empty;

    /// <summary>
    /// نام حساب
    /// Account name
    /// </summary>
    public string AccountName { get; set; } = string.Empty;

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
    /// وضعیت سند
    /// Voucher status
    /// </summary>
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// نوع سند
    /// Voucher type
    /// </summary>
    public string Type { get; set; } = string.Empty;
    public DateTime TransactionDate { get; set; }
    public int DebitAmount { get; set; }
    public int CreditAmount { get; set; }

    /// <summary>
    /// حساب مرتبط با ردیف دفتر کل
    /// Related account
    /// </summary>
    public Account? Account { get; set; }

    /// <summary>
    /// سند/ثبت مرتبط با ردیف دفتر کل
    /// Related journal voucher
    /// </summary>
    public JournalVoucher? Voucher { get; set; }
}


