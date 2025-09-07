using MediatR;

namespace Dinawin.Erp.Application.Features.CRM.Tickets.Queries.GetAllTickets;

/// <summary>
/// پرس‌وجو لیست تیکت‌ها
/// </summary>
public sealed class GetAllTicketsQuery : IRequest<IEnumerable<TicketDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// نوع تیکت برای فیلتر
    /// </summary>
    public string? TicketType { get; init; }

    /// <summary>
    /// وضعیت تیکت برای فیلتر
    /// </summary>
    public string? Status { get; init; }

    /// <summary>
    /// اولویت تیکت برای فیلتر
    /// </summary>
    public string? Priority { get; init; }

    /// <summary>
    /// شناسه مشتری برای فیلتر
    /// </summary>
    public Guid? CustomerId { get; init; }

    /// <summary>
    /// شناسه کاربر مسئول برای فیلتر
    /// </summary>
    public Guid? AssignedToId { get; init; }

    /// <summary>
    /// شناسه کاربر ایجاد کننده برای فیلتر
    /// </summary>
    public Guid? CreatedById { get; init; }

    /// <summary>
    /// شناسه محصول برای فیلتر
    /// </summary>
    public Guid? ProductId { get; init; }

    /// <summary>
    /// شناسه سفارش فروش برای فیلتر
    /// </summary>
    public Guid? SalesOrderId { get; init; }

    /// <summary>
    /// شناسه فرصت برای فیلتر
    /// </summary>
    public Guid? OpportunityId { get; init; }

    /// <summary>
    /// تاریخ شروع مهلت
    /// </summary>
    public DateTime? DueDateFrom { get; init; }

    /// <summary>
    /// تاریخ پایان مهلت
    /// </summary>
    public DateTime? DueDateTo { get; init; }

    /// <summary>
    /// تاریخ شروع ایجاد
    /// </summary>
    public DateTime? CreatedFrom { get; init; }

    /// <summary>
    /// تاریخ پایان ایجاد
    /// </summary>
    public DateTime? CreatedTo { get; init; }

    /// <summary>
    /// تگ‌ها برای فیلتر
    /// </summary>
    public string? Tags { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
