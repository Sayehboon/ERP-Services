using MediatR;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetAllSystemSettings;

/// <summary>
/// پرس‌وجو لیست تنظیمات سیستم
/// </summary>
public sealed class GetAllSystemSettingsQuery : IRequest<IEnumerable<SystemSettingDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// دسته‌بندی تنظیمات برای فیلتر
    /// </summary>
    public string? Category { get; init; }

    /// <summary>
    /// نوع داده برای فیلتر
    /// </summary>
    public string? DataType { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// وضعیت قابل ویرایش بودن برای فیلتر
    /// </summary>
    public bool? IsEditable { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
