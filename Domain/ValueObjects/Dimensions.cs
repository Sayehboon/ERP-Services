using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش ابعاد
/// Dimensions value object
/// </summary>
public class Dimensions : ValueObject
{
    /// <summary>
    /// طول
    /// Length
    /// </summary>
    public decimal Length { get; private init; }

    /// <summary>
    /// عرض
    /// Width
    /// </summary>
    public decimal Width { get; private init; }

    /// <summary>
    /// ارتفاع
    /// Height
    /// </summary>
    public decimal Height { get; private init; }

    /// <summary>
    /// واحد اندازه‌گیری
    /// Unit of measurement
    /// </summary>
    public DimensionUnit Unit { get; private init; }

    /// <summary>
    /// سازنده ابعاد
    /// Dimensions constructor
    /// </summary>
    /// <param name="length">طول</param>
    /// <param name="width">عرض</param>
    /// <param name="height">ارتفاع</param>
    /// <param name="unit">واحد اندازه‌گیری</param>
    public Dimensions(decimal length, decimal width, decimal height, DimensionUnit unit)
    {
        if (length < 0)
            throw new ArgumentException("Length cannot be negative", nameof(length));
        
        if (width < 0)
            throw new ArgumentException("Width cannot be negative", nameof(width));
        
        if (height < 0)
            throw new ArgumentException("Height cannot be negative", nameof(height));

        Length = length;
        Width = width;
        Height = height;
        Unit = unit;
    }

    /// <summary>
    /// ایجاد ابعاد به سانتی‌متر
    /// Create dimensions in centimeters
    /// </summary>
    public static Dimensions Centimeters(decimal length, decimal width, decimal height) 
        => new(length, width, height, DimensionUnit.Centimeter);

    /// <summary>
    /// ایجاد ابعاد به متر
    /// Create dimensions in meters
    /// </summary>
    public static Dimensions Meters(decimal length, decimal width, decimal height) 
        => new(length, width, height, DimensionUnit.Meter);

    /// <summary>
    /// ایجاد ابعاد به میلی‌متر
    /// Create dimensions in millimeters
    /// </summary>
    public static Dimensions Millimeters(decimal length, decimal width, decimal height) 
        => new(length, width, height, DimensionUnit.Millimeter);

    /// <summary>
    /// حجم (طول × عرض × ارتفاع)
    /// Volume (Length × Width × Height)
    /// </summary>
    public decimal Volume => Length * Width * Height;

    /// <summary>
    /// مساحت پایه (طول × عرض)
    /// Base area (Length × Width)
    /// </summary>
    public decimal BaseArea => Length * Width;

    /// <summary>
    /// تبدیل به سانتی‌متر
    /// Convert to centimeters
    /// </summary>
    public Dimensions ToCentimeters()
    {
        var factor = Unit switch
        {
            DimensionUnit.Millimeter => 0.1m,
            DimensionUnit.Centimeter => 1m,
            DimensionUnit.Meter => 100m,
            _ => throw new InvalidOperationException($"Unknown dimension unit: {Unit}")
        };

        return new Dimensions(
            Length * factor,
            Width * factor,
            Height * factor,
            DimensionUnit.Centimeter);
    }

    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        var normalized = ToCentimeters();
        yield return normalized.Length;
        yield return normalized.Width;
        yield return normalized.Height;
    }

    /// <summary>
    /// نمایش رشته‌ای
    /// String representation
    /// </summary>
    public override string ToString()
    {
        var unitSymbol = Unit switch
        {
            DimensionUnit.Millimeter => "mm",
            DimensionUnit.Centimeter => "cm",
            DimensionUnit.Meter => "m",
            _ => Unit.ToString()
        };

        return $"{Length:N2} × {Width:N2} × {Height:N2} {unitSymbol}";
    }
}

/// <summary>
/// واحدهای ابعاد
/// Dimension units
/// </summary>
public enum DimensionUnit
{
    /// <summary>
    /// میلی‌متر
    /// Millimeter
    /// </summary>
    Millimeter = 1,

    /// <summary>
    /// سانتی‌متر
    /// Centimeter
    /// </summary>
    Centimeter = 2,

    /// <summary>
    /// متر
    /// Meter
    /// </summary>
    Meter = 3
}
