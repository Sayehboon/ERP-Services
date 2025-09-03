using Dinawin.Erp.Domain.Common;

namespace Dinawin.Erp.Domain.ValueObjects;

/// <summary>
/// شیء ارزش آدرس
/// Address value object
/// </summary>
public class Address : ValueObject
{
    /// <summary>
    /// خیابان و شماره
    /// Street and number
    /// </summary>
    public string Street { get; private init; }

    /// <summary>
    /// شهر
    /// City
    /// </summary>
    public string City { get; private init; }

    /// <summary>
    /// استان
    /// State/Province
    /// </summary>
    public string State { get; private init; }

    /// <summary>
    /// کد پستی
    /// Postal code
    /// </summary>
    public string PostalCode { get; private init; }

    /// <summary>
    /// کشور
    /// Country
    /// </summary>
    public string Country { get; private init; }

    /// <summary>
    /// طول جغرافیایی
    /// Longitude
    /// </summary>
    public decimal? Longitude { get; private init; }

    /// <summary>
    /// عرض جغرافیایی
    /// Latitude
    /// </summary>
    public decimal? Latitude { get; private init; }

    /// <summary>
    /// سازنده آدرس
    /// Address constructor
    /// </summary>
    public Address(
        string street,
        string city,
        string state,
        string postalCode,
        string country = "Iran",
        decimal? longitude = null,
        decimal? latitude = null)
    {
        if (string.IsNullOrWhiteSpace(street))
            throw new ArgumentException("Street cannot be null or empty", nameof(street));
        
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City cannot be null or empty", nameof(city));
        
        if (string.IsNullOrWhiteSpace(state))
            throw new ArgumentException("State cannot be null or empty", nameof(state));
        
        if (string.IsNullOrWhiteSpace(postalCode))
            throw new ArgumentException("Postal code cannot be null or empty", nameof(postalCode));
        
        if (string.IsNullOrWhiteSpace(country))
            throw new ArgumentException("Country cannot be null or empty", nameof(country));

        Street = street.Trim();
        City = city.Trim();
        State = state.Trim();
        PostalCode = postalCode.Trim();
        Country = country.Trim();
        Longitude = longitude;
        Latitude = latitude;
    }

    /// <summary>
    /// آدرس کامل
    /// Full address
    /// </summary>
    public string FullAddress => $"{Street}, {City}, {State}, {PostalCode}, {Country}";

    /// <summary>
    /// آیا موقعیت جغرافیایی دارد
    /// Has geographic coordinates
    /// </summary>
    public bool HasCoordinates => Longitude.HasValue && Latitude.HasValue;

    /// <summary>
    /// دریافت اجزای برابری
    /// Get equality components
    /// </summary>
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
        yield return Longitude;
        yield return Latitude;
    }

    /// <summary>
    /// نمایش رشته‌ای
    /// String representation
    /// </summary>
    public override string ToString() => FullAddress;
}
