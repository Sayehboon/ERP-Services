using MediatR;

namespace Dinawin.Erp.Application.Features.Accounting.JournalEntries.Queries.GetAllJournalEntries;

/// <summary>
/// پرس‌وجو لیست اسناد حسابداری
/// </summary>
public sealed class GetAllJournalEntriesQuery : IRequest<IEnumerable<JournalEntryDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه حساب برای فیلتر
    /// </summary>
    public Guid? AccountId { get; init; }

    /// <summary>
    /// نوع سند برای فیلتر
    /// </summary>
    public string? EntryType { get; init; }

    /// <summary>
    /// تاریخ شروع برای فیلتر
    /// </summary>
    public DateTime? FromDate { get; init; }

    /// <summary>
    /// تاریخ پایان برای فیلتر
    /// </summary>
    public DateTime? ToDate { get; init; }

    /// <summary>
    /// وضعیت تأیید برای فیلتر
    /// </summary>
    public bool? IsApproved { get; init; }

    /// <summary>
    /// نوع سند مرجع برای فیلتر
    /// </summary>
    public string? ReferenceType { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
