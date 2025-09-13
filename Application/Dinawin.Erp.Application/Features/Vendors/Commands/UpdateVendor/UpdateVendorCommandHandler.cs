using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Commands.UpdateVendor;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی تامین‌کننده
/// </summary>
public sealed class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی تامین‌کننده
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateVendorCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی تامین‌کننده
    /// </summary>
    public async Task<Guid> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors.FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);
        if (vendor == null)
        {
            throw new ArgumentException($"تامین‌کننده با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی شماره ملی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Vendors
                .AnyAsync(v => v.NationalId == request.NationalId && v.Id != request.Id, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"تامین‌کننده با شماره ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره اقتصادی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.EconomicCode))
        {
            var economicCodeExists = await _context.Vendors
                .AnyAsync(v => v.EconomicCode == request.EconomicCode && v.Id != request.Id, cancellationToken);
            if (economicCodeExists)
            {
                throw new ArgumentException($"تامین‌کننده با شماره اقتصادی {request.EconomicCode} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی ایمیل در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var emailExists = await _context.Vendors
                .AnyAsync(v => v.Email == request.Email && v.Id != request.Id, cancellationToken);
            if (emailExists)
            {
                throw new ArgumentException($"تامین‌کننده با ایمیل {request.Email} قبلاً وجود دارد");
            }
        }

        vendor.Name = request.Name ?? vendor.Name;
        vendor.LastName = request.LastName ?? vendor.LastName;
        vendor.CompanyName = request.CompanyName ?? vendor.CompanyName;
        vendor.VendorType = request.VendorType ?? vendor.VendorType;
        vendor.NationalId = request.NationalId ?? vendor.NationalId;
        vendor.EconomicCode = request.EconomicCode ?? vendor.EconomicCode;
        vendor.RegistrationNumber = request.RegistrationNumber ?? vendor.RegistrationNumber;
        vendor.Phone = request.Phone ?? vendor.Phone;
        vendor.Mobile = request.Mobile ?? vendor.Mobile;
        vendor.Email = request.Email ?? vendor.Email;
        vendor.Address = request.Address ?? vendor.Address;
        vendor.City = request.City ?? vendor.City;
        vendor.Province = request.Province ?? vendor.Province;
        vendor.PostalCode = request.PostalCode ?? vendor.PostalCode;
        vendor.Country = request.Country ?? vendor.Country;
        vendor.Website = request.Website ?? vendor.Website;
        vendor.BirthDate = request.BirthDate ?? vendor.BirthDate;
        vendor.Gender = request.Gender ?? vendor.Gender;
        vendor.JobTitle = request.JobTitle ?? vendor.JobTitle;
        vendor.CreditLimit = request.CreditLimit;
        vendor.AccountBalance = request.AccountBalance;
        vendor.PaymentTerms = request.PaymentTerms ?? vendor.PaymentTerms;
        vendor.PreferredCurrency = request.PreferredCurrency ?? vendor.PreferredCurrency;
        vendor.IsActive = request.IsActive;
        vendor.Description = request.Description ?? vendor.Description;
        vendor.UpdatedBy = request.UpdatedBy;
        vendor.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return vendor.Id;
    }
}
