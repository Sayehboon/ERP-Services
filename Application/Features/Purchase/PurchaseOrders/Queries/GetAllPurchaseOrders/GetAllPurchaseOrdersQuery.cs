using MediatR;

namespace Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Queries.GetAllPurchaseOrders;

/// <summary>
/// پرس‌وجو لیست سفارش‌های خرید
/// </summary>
public sealed class GetAllPurchaseOrdersQuery : IRequest<IEnumerable<PurchaseOrderDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// وضعیت سفارش برای فیلتر
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// نوع سفارش برای فیلتر
    /// </summary>
    public string OrderType { get; init; }

    /// <summary>
    /// شناسه تامین‌کننده برای فیلتر
    /// </summary>
    public Guid? VendorId { get; init; }

    /// <summary>
    /// شناسه انبار برای فیلتر
    /// </summary>
    public Guid? WarehouseId { get; init; }

    /// <summary>
    /// شناسه کاربر مسئول برای فیلتر
    /// </summary>
    public Guid? AssignedToId { get; init; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده برای فیلتر
    /// </summary>
    public Guid? CreatedById { get; init; }

    /// <summary>
    /// روش پرداخت برای فیلتر
    /// </summary>
    public string PaymentMethod { get; init; }

    /// <summary>
    /// ارز برای فیلتر
    /// </summary>
    public string Currency { get; init; }

    /// <summary>
    /// مبلغ حداقل
    /// </summary>
    public decimal? MinAmount { get; init; }

    /// <summary>
    /// مبلغ حداکثر
    /// </summary>
    public decimal? MaxAmount { get; init; }

    /// <summary>
    /// تاریخ شروع سفارش
    /// </summary>
    public DateTime? OrderDateFrom { get; init; }

    /// <summary>
    /// تاریخ پایان سفارش
    /// </summary>
    public DateTime? OrderDateTo { get; init; }

    /// <summary>
    /// تاریخ شروع تحویل مورد انتظار
    /// </summary>
    public DateTime? ExpectedDeliveryFrom { get; init; }

    /// <summary>
    /// تاریخ پایان تحویل مورد انتظار
    /// </summary>
    public DateTime? ExpectedDeliveryTo { get; init; }

    /// <summary>
    /// تاریخ شروع تحویل واقعی
    /// </summary>
    public DateTime? ActualDeliveryFrom { get; init; }

    /// <summary>
    /// تاریخ پایان تحویل واقعی
    /// </summary>
    public DateTime? ActualDeliveryTo { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}