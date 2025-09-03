namespace Dinawin.Erp.Domain.Entities.Accounting;

using Dinawin.Erp.Domain.Common;

/// <summary>
/// موجودیت فاکتور فروش
/// Sales invoice entity
/// </summary>
public class SalesInvoice : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شماره فاکتور
    /// Invoice number
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// تاریخ فاکتور
    /// Invoice date
    /// </summary>
    public DateTime InvoiceDate { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer Id
    /// </summary>
    public Guid CustomerId { get; set; }

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
    /// ردیف‌های فاکتور
    /// Invoice line items
    /// </summary>
    public ICollection<SalesInvoiceLine> LineItems { get; set; } = new List<SalesInvoiceLine>();
}

/// <summary>
/// ردیف فاکتور فروش
/// Sales invoice line item
/// </summary>
public class SalesInvoiceLine : BaseEntity
{
    /// <summary>
    /// شناسه فاکتور
    /// Invoice Id
    /// </summary>
    public Guid SalesInvoiceId { get; set; }

    /// <summary>
    /// شناسه حساب درآمد/فروش
    /// Revenue account Id
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    /// تعداد
    /// Quantity
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// قیمت واحد
    /// Unit price
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// تخفیف خط
    /// Line discount
    /// </summary>
    public decimal LineDiscount { get; set; }

    /// <summary>
    /// نرخ مالیات
    /// Tax rate (%)
    /// </summary>
    public decimal TaxRate { get; set; }

    /// <summary>
    /// مبلغ مالیات
    /// Tax amount
    /// </summary>
    public decimal TaxAmount { get; set; }

    /// <summary>
    /// شرح سطر
    /// Line description
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// جمع خط
    /// Line total
    /// </summary>
    public decimal LineTotal { get; set; }
}


