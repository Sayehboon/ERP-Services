using Dinawin.Erp.Domain.Common;
using System.Text.RegularExpressions;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش شماره تلفن
/// Phone number value object
/// </summary>
public class PhoneNumber : ValueObject
{
    private static readonly Regex PhoneRegex = new(
        @"^(\+98|0)?9\d{9}$",
        RegexOptions.Compiled);

    /// <summary>
    /// شماره تلفن
    /// Phone number value
    /// </summary>
    public string Value { get; private init; }

    /// <summary>
    /// شماره تلفن بدون کد کشور
    /// Phone number without country code
    /// </summary>
    public string LocalNumber { get; private init; }

    /// <summary>
    /// کد کشور
    /// Country code
    /// </summary>
    public string CountryCode { get; private init; }

    /// <summary>
    /// سازنده شماره تلفن
    /// Phone number constructor
    /// </summary>
    /// <param name="value">شماره تلفن</param>
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be null or empty", nameof(value));

        // حذف فاصله و کاراکترهای اضافی
        // Remove spaces and extra characters
        value = Regex.Replace(value.Trim(), @"[\s\-\(\)]", "");

        if (!PhoneRegex.IsMatch(value))
            throw new ArgumentException("Invalid Iranian phone number format", nameof(value));

        // نرمال‌سازی شماره تلفن
        // Normalize phone number
        if (value.StartsWith("+98"))
        {
            CountryCode = "+98";
            LocalNumber = value[3..];
        }
        else if (value.StartsWith("0"))
        {
            CountryCode = "+98";
            LocalNumber = value[1..];
        }
        else if (value.StartsWith("9"))
        {
            CountryCode = "+98";
            LocalNumber = value;
        }
        else
        {
            throw new ArgumentException("Invalid phone number format", nameof(value));
        }

        Value = $"{CountryCode}{LocalNumber}";
    }

    /// <summary>
    /// تبدیل ضمنی از رشته به شماره تلفن
    /// Implicit conversion from string to phone number
    /// </summary>
    public static implicit operator PhoneNumber(string value) => new(value);

    /// <summary>
    /// تبدیل ضمنی از شماره تلفن به رشته
    /// Implicit conversion from phone number to string
    /// </summary>
    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;

    /// <summary>
    /// فرمت نمایش داخلی
    /// Domestic display format
    /// </summary>
    public string ToDomesticFormat()
    {
        return $"0{LocalNumber}";
    }

    /// <summary>
    /// فرمت نمایش بین‌المللی
    /// International display format
    /// </summary>
    public string ToInternationalFormat()
    {
        return Value;
    }

    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    /// <summary>
    /// نمایش رشته‌ای
    /// String representation
    /// </summary>
    public override string ToString() => ToDomesticFormat();
}
