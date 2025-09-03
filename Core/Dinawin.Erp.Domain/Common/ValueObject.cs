namespace Dinawin.Erp.Domain.Common;

/// <summary>
/// کلاس پایه برای اشیاء ارزش
/// Base class for value objects
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    /// <returns>مولفه‌های برابری</returns>
    protected abstract IEnumerable<object?> GetEqualityComponents();

    /// <summary>
    /// بررسی برابری
    /// Check equality
    /// </summary>
    /// <param name="other">شیء دیگر</param>
    /// <returns>نتیجه برابری</returns>
    public bool Equals(ValueObject? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;

        return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
    }

    /// <summary>
    /// بررسی برابری عمومی
    /// General equality check
    /// </summary>
    /// <param name="obj">شیء مقایسه</param>
    /// <returns>نتیجه برابری</returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    /// <summary>
    /// دریافت کد هش
    /// Get hash code
    /// </summary>
    /// <returns>کد هش</returns>
    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 23 + (obj?.GetHashCode() ?? 0);
                }
            });
    }

    /// <summary>
    /// عملگر برابری
    /// Equality operator
    /// </summary>
    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    /// <summary>
    /// عملگر عدم برابری
    /// Inequality operator
    /// </summary>
    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }
}
