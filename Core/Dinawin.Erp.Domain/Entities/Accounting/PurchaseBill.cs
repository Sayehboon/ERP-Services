namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت صورتحساب خرید
/// Purchase bill entity
/// </summary>
public class PurchaseBill : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره صورتحساب
    /// Bill number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// تاریخ صورتحساب
    /// Bill date
    /// </summary>
    public DateTime BillDate { get; set; }

    /// <summary>
    /// شناسه تامین‌کننده
    /// Vendor Id
    /// </summary>
    public Guid VendorId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// توضیحات
    /// Notes
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// اقلام صورتحساب
    /// Bill lines
    /// </summary>
    public ICollection<PurchaseBillLine> LineItems { get; set; } = new List<PurchaseBillLine>();

    /// <summary>
    /// تامین‌کننده مرتبط
    /// Related vendor
    /// </summary>
    public Vendor? Vendor { get; set; }
}

/// <summary>
/// ردیف صورتحساب خرید
/// Purchase bill line item
/// </summary>
public class PurchaseBillLine : BaseEntity
{
    public Guid PurchaseBillId { get; set; }
    public Guid AccountId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineDiscount { get; set; }
    public decimal TaxRate { get; set; }
    public decimal TaxAmount { get; set; }
    public string? Description { get; set; }
    public decimal LineTotal { get; set; }

    /// <summary>
    /// صورتحساب مرتبط
    /// Related bill
    /// </summary>
    public PurchaseBill? PurchaseBill { get; set; }

    /// <summary>
    /// حساب مرتبط
    /// Related account
    /// </summary>
    public Account? Account { get; set; }
}


