using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Accounting;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.CreateVendor;

/// <summary>
/// مدیریت‌کننده دستور ایجاد تامین‌کننده جدید
/// </summary>
public sealed class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد تامین‌کننده جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateVendorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد تامین‌کننده جدید
    /// </summary>
    public async Task<Guid> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کد تامین‌کننده
        var codeExists = await _context.Vendors
            .AnyAsync(v => v.Code == request.Code, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"تامین‌کننده با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی یکتایی شماره ملی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Vendors
                .AnyAsync(v => v.NationalId == request.NationalId, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"تامین‌کننده با شماره ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره اقتصادی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.EconomicCode))
        {
            var economicCodeExists = await _context.Vendors
                .AnyAsync(v => v.EconomicCode == request.EconomicCode, cancellationToken);
            if (economicCodeExists)
            {
                throw new ArgumentException($"تامین‌کننده با شماره اقتصادی {request.EconomicCode} قبلاً وجود دارد");
            }
        }

        var vendor = new Vendor
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            VendorType = request.VendorType,
            CompanyName = request.CompanyName ?? string.Empty,
            ContactName = request.ContactName,
            Phone = request.Phone ?? string.Empty,
            Email = request.Email ?? string.Empty,
            Address = request.Address ?? string.Empty,
            City = request.City ?? string.Empty,
            Province = request.Province ?? string.Empty,
            Country = request.Country ?? string.Empty,
            PostalCode = request.PostalCode ?? string.Empty,
            NationalId = request.NationalId ?? string.Empty,
            EconomicCode = request.EconomicCode ?? string.Empty,
            CreditLimit = request.CreditLimit,
            PreferredCurrency = request.PreferredCurrency ?? string.Empty,
            PaymentTerms = request.PaymentTerms ?? string.Empty,
            DiscountRate = request.DiscountRate,
            IsActive = request.IsActive,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Vendors.Add(vendor);
        await _context.SaveChangesAsync(cancellationToken);
        return vendor.Id;
    }
}
