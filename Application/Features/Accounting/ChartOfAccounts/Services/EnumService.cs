using System.ComponentModel;
using System.Reflection;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.DTOs;
using Dinawin.Erp.Domain.Enums;

namespace Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Services;

/// <summary>
/// سرویس مدیریت شمارشی‌ها
/// </summary>
public static class EnumService
{
    /// <summary>
    /// دریافت آیتم‌های شمارشی AccountTypeEnum
    /// </summary>
    /// <returns>لیست آیتم‌های شمارشی</returns>
    public static IEnumerable<EnumItemDto> GetAccountTypeEnumItems()
    {
        return GetEnumItems<AccountTypeEnum>();
    }

    /// <summary>
    /// دریافت آیتم‌های شمارشی NormalBalanceEnum
    /// </summary>
    /// <returns>لیست آیتم‌های شمارشی</returns>
    public static IEnumerable<EnumItemDto> GetNormalBalanceEnumItems()
    {
        return GetEnumItems<NormalBalanceEnum>();
    }

    /// <summary>
    /// دریافت آیتم‌های شمارشی به صورت عمومی
    /// </summary>
    /// <typeparam name="T">نوع شمارشی</typeparam>
    /// <returns>لیست آیتم‌های شمارشی</returns>
    private static IEnumerable<EnumItemDto> GetEnumItems<T>() where T : Enum
    {
        var enumType = typeof(T);
        var enumValues = Enum.GetValues(enumType);

        foreach (T enumValue in enumValues)
        {
            var fieldInfo = enumType.GetField(enumValue.ToString()!);
            var descriptionAttribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();

            yield return new EnumItemDto
            {
                Value = Convert.ToInt32(enumValue),
                Name = enumValue.ToString()!,
                PersianName = descriptionAttribute?.Description ?? enumValue.ToString()!
            };
        }
    }
}
