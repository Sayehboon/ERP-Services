using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemSettings.Queries.GetSystemSettingCategories;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت دسته‌بندی‌های تنظیمات سیستم
/// </summary>
public sealed class GetSystemSettingCategoriesQueryHandler : IRequestHandler<GetSystemSettingCategoriesQuery, IEnumerable<SystemSettingCategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت دسته‌بندی‌های تنظیمات سیستم
    /// </summary>
    public GetSystemSettingCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت دسته‌بندی‌های تنظیمات سیستم
    /// </summary>
    public async Task<IEnumerable<SystemSettingCategoryDto>> Handle(GetSystemSettingCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _context.SystemSettings
            .GroupBy(ss => ss.Category)
            .Select(g => new SystemSettingCategoryDto
            {
                Name = g.Key,
                DisplayName = GetCategoryDisplayName(g.Key),
                Description = GetCategoryDescription(g.Key),
                SettingsCount = g.Count()
            })
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

        return categories;
    }

    /// <summary>
    /// دریافت نام نمایشی دسته‌بندی
    /// </summary>
    private static string GetCategoryDisplayName(string category)
    {
        return category switch
        {
            "General" => "عمومی",
            "Financial" => "مالی",
            "Security" => "امنیت",
            "Notification" => "اعلان‌ها",
            "System" => "سیستم",
            "UI" => "رابط کاربری",
            "Integration" => "یکپارچه‌سازی",
            "Backup" => "پشتیبان‌گیری",
            _ => category
        };
    }

    /// <summary>
    /// دریافت توضیحات دسته‌بندی
    /// </summary>
    private static string? GetCategoryDescription(string category)
    {
        return category switch
        {
            "General" => "تنظیمات عمومی سیستم",
            "Financial" => "تنظیمات مالی و حسابداری",
            "Security" => "تنظیمات امنیتی",
            "Notification" => "تنظیمات اعلان‌ها و اطلاع‌رسانی",
            "System" => "تنظیمات سیستم و عملکرد",
            "UI" => "تنظیمات رابط کاربری",
            "Integration" => "تنظیمات یکپارچه‌سازی با سیستم‌های خارجی",
            "Backup" => "تنظیمات پشتیبان‌گیری و بازیابی",
            _ => null
        };
    }
}
