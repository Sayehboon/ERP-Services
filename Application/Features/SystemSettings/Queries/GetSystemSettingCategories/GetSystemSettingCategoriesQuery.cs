using MediatR;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingCategories;

/// <summary>
/// پرس‌وجو دریافت دسته‌بندی‌های تنظیمات سیستم
/// </summary>
public sealed class GetSystemSettingCategoriesQuery : IRequest<IEnumerable<SystemSettingCategoryDto>>
{
}
