using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش وزن
/// Weight value object
/// </summary>
public class Weight : ValueObject
{
    /// <summary>
    /// مقدار وزن
    /// Weight value
    /// </summary>
    public decimal Value { get; private init; }

    /// <summary>
    /// واحد وزن
    /// Weight unit
    /// </summary>
    public WeightUnit Unit { get; private init; }

    /// <summary>
    /// سازنده وزن
    /// Weight constructor
    /// </summary>
    /// <param name="value">مقدار وزن</param>
    /// <param name="unit">واحد وزن</param>
    public Weight(decimal value, WeightUnit unit)
    {
        if (value < 0)
            throw new ArgumentException("Weight cannot be negative", nameof(value));

        Value = value;
        Unit = unit;
    }

    /// <summary>
    /// ایجاد وزن به کیلوگرم
    /// Create weight in kilograms
    /// </summary>
    public static Weight Kilograms(decimal value) => new(value, WeightUnit.Kilogram);

    /// <summary>
    /// ایجاد وزن به گرم
    /// Create weight in grams
    /// </summary>
    public static Weight Grams(decimal value) => new(value, WeightUnit.Gram);

    /// <summary>
    /// ایجاد وزن به تن
    /// Create weight in tons
    /// </summary>
    public static Weight Tons(decimal value) => new(value, WeightUnit.Ton);

    /// <summary>
    /// تبدیل به کیلوگرم
    /// Convert to kilograms
    /// </summary>
    public decimal ToKilograms()
    {
        return Unit switch
        {
            WeightUnit.Gram => Value / 1000m,
            WeightUnit.Kilogram => Value,
            WeightUnit.Ton => Value * 1000m,
            _ => throw new InvalidOperationException($"Unknown weight unit: {Unit}")
        };
    }

    /// <summary>
    /// تبدیل به گرم
    /// Convert to grams
    /// </summary>
    public decimal ToGrams()
    {
        return Unit switch
        {
            WeightUnit.Gram => Value,
            WeightUnit.Kilogram => Value * 1000m,
            WeightUnit.Ton => Value * 1000000m,
            _ => throw new InvalidOperationException($"Unknown weight unit: {Unit}")
        };
    }

    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ToKilograms(); // Normalize to kilograms for comparison
    }

    /// <summary>
    /// نمایش رشته‌ای
    /// String representation
    /// </summary>
    public override string ToString()
    {
        var unitSymbol = Unit switch
        {
            WeightUnit.Gram => "g",
            WeightUnit.Kilogram => "kg",
            WeightUnit.Ton => "t",
            _ => Unit.ToString()
        };

        return $"{Value:N2} {unitSymbol}";
    }
}

/// <summary>
/// واحدهای وزن
/// Weight units
/// </summary>
public enum WeightUnit
{
    /// <summary>
    /// گرم
    /// Gram
    /// </summary>
    Gram = 1,

    /// <summary>
    /// کیلوگرم
    /// Kilogram
    /// </summary>
    Kilogram = 2,

    /// <summary>
    /// تن
    /// Ton
    /// </summary>
    Ton = 3
}
