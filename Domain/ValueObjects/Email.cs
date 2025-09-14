using Dinawin.Erp.Domain.Common;
using System.Text.RegularExpressions;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش ایمیل
/// Email value object
/// </summary>
public class Email : ValueObject
{
    private static readonly Regex EmailRegex = new(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    /// <summary>
    /// آدرس ایمیل
    /// Email address
    /// </summary>
    public string Value { get; private init; }

    /// <summary>
    /// بخش محلی ایمیل (قبل از @)
    /// Local part of email (before @)
    /// </summary>
    public string LocalPart => Value.Split('@')[0];

    /// <summary>
    /// دامنه ایمیل (بعد از @)
    /// Domain part of email (after @)
    /// </summary>
    public string Domain => Value.Split('@')[1];

    /// <summary>
    /// سازنده ایمیل
    /// Email constructor
    /// </summary>
    /// <param name="value">آدرس ایمیل</param>
    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be null or empty", nameof(value));

        value = value.Trim().ToLowerInvariant();

        if (!EmailRegex.IsMatch(value))
            throw new ArgumentException("Invalid email format", nameof(value));

        Value = value;
    }

    /// <summary>
    /// تبدیل ضمنی از رشته به ایمیل
    /// Implicit conversion from string to email
    /// </summary>
    public static implicit operator Email(string value) => new(value);

    /// <summary>
    /// تبدیل ضمنی از ایمیل به رشته
    /// Implicit conversion from email to string
    /// </summary>
    public static implicit operator string(Email email) => email.Value;

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
    public override string ToString() => Value;
}
