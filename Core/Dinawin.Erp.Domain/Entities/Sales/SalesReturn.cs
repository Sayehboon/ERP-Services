using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.Entities.Sales;

/// <summary>
/// برگشت فروش
/// Sales Return
/// </summary>
public class SalesReturn : BaseEntity, IAggregateRoot
{
    /// <summary>
    /// شناسه کسب‌وکار
    /// Business ID
    /// </summary>
    public Guid BusinessId { get; set; }

    /// <summary>
    /// شماره برگشت
    /// Return number
    /// </summary>
    public string ReturnNumber { get; set; } = string.Empty;

    /// <summary>
    /// تاریخ برگشت
    /// Return date
    /// </summary>
    public DateTime ReturnDate { get; set; }

    /// <summary>
    /// شناسه مشتری
    /// Customer ID
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// شناسه انبار
    /// Warehouse ID
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// شناسه فاکتور فروش
    /// Sales invoice ID
    /// </summary>
    public Guid? SalesInvoiceId { get; set; }

    /// <summary>
    /// وضعیت
    /// Status
    /// </summary>
    public string Status { get; set; } = "draft";

    /// <summary>
    /// مبلغ کل
    /// Total amount
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;

    /// <summary>
    /// ارز
    /// Currency
    /// </summary>
    public string Currency { get; set; } = "IRR";

    /// <summary>
    /// نرخ ارز
    /// Exchange rate
    /// </summary>
    public decimal ExchangeRate { get; set; } = 1;

    /// <summary>
    /// دلیل برگشت
    /// Return reason
    /// </summary>
    public string? ReturnReason { get; set; }

    /// <summary>
    /// توضیحات
    /// Description
    /// </summary>
    public string? Description { get; set; }

    // Navigation Properties
    /// <summary>
    /// مشتری مرتبط
    /// Related customer
    /// </summary>
    public Accounting.ArCustomer Customer { get; set; } = null!;

    /// <summary>
    /// انبار مرتبط
    /// Related warehouse
    /// </summary>
    public Inventories.Warehouse Warehouse { get; set; } = null!;

    /// <summary>
    /// فاکتور فروش مرتبط
    /// Related sales invoice
    /// </summary>
    public Accounting.ArInvoice? SalesInvoice { get; set; }

    /// <summary>
    /// خطوط برگشت
    /// Return lines
    /// </summary>
    public ICollection<SalesReturnLine> Lines { get; set; } = new List<SalesReturnLine>();
}
