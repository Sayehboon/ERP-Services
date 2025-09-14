using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Dashboard.Queries.GetSalesStats;

/// <summary>
/// پرس‌وجو دریافت آمار فروش
/// </summary>
public sealed class GetSalesStatsQuery : IRequest<SalesStatsDto>
{
    /// <summary>
    /// دوره زمانی (daily, weekly, monthly, yearly)
    /// </summary>
    [Required(ErrorMessage = "دوره زمانی الزامی است")]
    [StringLength(20, ErrorMessage = "دوره زمانی نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Period { get; set; } = "monthly";

    /// <summary>
    /// تاریخ شروع برای فیلتر
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان برای فیلتر
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// شناسه کاربر برای فیلتر
    /// </summary>
    public Guid? UserId { get; init; }

    /// <summary>
    /// شناسه مشتری برای فیلتر
    /// </summary>
    public Guid? CustomerId { get; init; }
}
