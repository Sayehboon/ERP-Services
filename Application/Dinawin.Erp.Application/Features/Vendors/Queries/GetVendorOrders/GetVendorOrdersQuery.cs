using MediatR;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorOrders;

/// <summary>
/// پرس‌وجو دریافت سفارشات تامین‌کننده
/// </summary>
public sealed class GetVendorOrdersQuery : IRequest<IEnumerable<VendorOrderDto>>
{
    /// <summary>
    /// شناسه تامین‌کننده
    /// </summary>
    public required Guid VendorId { get; init; }

    /// <summary>
    /// وضعیت سفارش (اختیاری)
    /// </summary>
    public string? Status { get; init; }

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
    public string? OrderNumber { get; init; }

    /// <summary>
    /// تعداد نتایج حداکثر
    /// </summary>
    public int MaxResults { get; init; } = 50;
}
