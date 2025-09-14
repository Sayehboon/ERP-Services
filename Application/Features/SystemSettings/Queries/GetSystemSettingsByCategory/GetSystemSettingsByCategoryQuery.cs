using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingsByCategory;

/// <summary>
/// پرس‌وجو دریافت تنظیمات سیستم بر اساس دسته‌بندی
/// </summary>
public sealed class GetSystemSettingsByCategoryQuery : IRequest<IEnumerable<SystemSettingDto>>
{
    /// <summary>
    /// دسته‌بندی تنظیمات
    /// </summary>
    [Required(ErrorMessage = "دسته‌بندی تنظیمات الزامی است")]
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
