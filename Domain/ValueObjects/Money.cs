using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش پول
/// Money value object
/// </summary>
public class Money : ValueObject
{
    /// <summary>
    /// مقدار
    /// Amount
    /// </summary>
    public decimal Amount { get; private init; }

    /// <summary>
    /// کد واحد پول
    /// Currency code
    /// </summary>
    public string Currency { get; private init; }

    /// <summary>
    /// سازنده پول
    /// Money constructor
    /// </summary>
    /// <param name="amount">مقدار</param>
    /// <param name="currency">واحد پول</param>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency))
            throw new ArgumentException("Currency cannot be null or empty", nameof(currency));

        Amount = amount;
        Currency = currency.ToUpperInvariant();
    }

    /// <summary>
    /// ایجاد پول با ریال ایران
    /// Create money with Iranian Rial
    /// </summary>
    /// <param name="amount">مقدار</param>
    /// <returns>شیء پول</returns>
    public static Money Rial(decimal amount) => new(amount, "IRR");

    /// <summary>
    /// ایجاد پول با دلار آمریکا
    /// Create money with US Dollar
    /// </summary>
    /// <param name="amount">مقدار</param>
    /// <returns>شیء پول</returns>
    public static Money Dollar(decimal amount) => new(amount, "USD");

    /// <summary>
    /// ایجاد پول با یورو
    /// Create money with Euro
    /// </summary>
    /// <param name="amount">مقدار</param>
    /// <returns>شیء پول</returns>
    public static Money Euro(decimal amount) => new(amount, "EUR");

    /// <summary>
    /// جمع دو پول
    /// Add two money values
    /// </summary>
    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException("Cannot add money with different currencies");

        return new Money(left.Amount + right.Amount, left.Currency);
    }

    /// <summary>
    /// تفریق دو پول
    /// Subtract two money values
    /// </summary>
    public static Money operator -(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException("Cannot subtract money with different currencies");

        return new Money(left.Amount - right.Amount, left.Currency);
    }

    /// <summary>
    /// ضرب پول در عدد
    /// Multiply money by number
    /// </summary>
    public static Money operator *(Money money, decimal multiplier)
    {
        return new Money(money.Amount * multiplier, money.Currency);
    }

    /// <summary>
    /// تقسیم پول بر عدد
    /// Divide money by number
    /// </summary>
    public static Money operator /(Money money, decimal divisor)
    {
        if (divisor == 0)
            throw new DivideByZeroException("Cannot divide money by zero");

        return new Money(money.Amount / divisor, money.Currency);
    }

    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }

    /// <summary>
    /// نمایش رشته‌ای
    /// String representation
    /// </summary>
    public override string ToString()
    {
        return $"{Amount:N2} {Currency}";
    }
}
