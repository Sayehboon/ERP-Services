using MediatR;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerOrders;

/// <summary>
/// پرس‌وجو دریافت سفارشات مشتری
/// </summary>
public sealed class GetCustomerOrdersQuery : IRequest<IEnumerable<CustomerOrderDto>>
{
    /// <summary>
    /// شناسه مشتری
    /// </summary>
    public required Guid CustomerId { get; init; }

    /// <summary>
    /// وضعیت سفارش (اختیاری)
    /// </summary>
    public string Status { get; init; }

    /// <summary>
    /// تاریخ شروع (اختیاری)
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان (اختیاری)
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// شماره سفارش (اختیاری)
    /// </summary>
    public string OrderNumber { get; init; }

    /// <summary>
    /// تعداد نتایج حداکثر
    /// </summary>
    public int MaxResults { get; init; } = 50;
}
