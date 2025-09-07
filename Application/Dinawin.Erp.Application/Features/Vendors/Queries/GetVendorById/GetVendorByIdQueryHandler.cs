using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت تامین‌کننده بر اساس شناسه
/// </summary>
public sealed class GetVendorByIdQueryHandler : IRequestHandler<GetVendorByIdQuery, VendorDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت تامین‌کننده بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetVendorByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت تامین‌کننده بر اساس شناسه
    /// </summary>
    public async Task<VendorDto?> Handle(GetVendorByIdQuery request, CancellationToken cancellationToken)
    {
        var vendor = await _context.Vendors
            .FirstOrDefaultAsync(v => v.Id == request.Id, cancellationToken);

        if (vendor == null)
        {
            return null;
        }

        return new VendorDto
        {
            Id = vendor.Id,
            Name = vendor.Name,
            LastName = vendor.LastName,
            CompanyName = vendor.CompanyName,
            VendorType = vendor.VendorType,
            NationalId = vendor.NationalId,
            EconomicCode = vendor.EconomicCode,
            RegistrationNumber = vendor.RegistrationNumber,
            Phone = vendor.Phone,
            Mobile = vendor.Mobile,
            Email = vendor.Email,
            Address = vendor.Address,
            City = vendor.City,
            Province = vendor.Province,
            PostalCode = vendor.PostalCode,
            Country = vendor.Country,
            Website = vendor.Website,
            BirthDate = vendor.BirthDate,
            Gender = vendor.Gender,
            JobTitle = vendor.JobTitle,
            CreditLimit = vendor.CreditLimit,
            AccountBalance = vendor.AccountBalance,
            PaymentTerms = vendor.PaymentTerms,
            PreferredCurrency = vendor.PreferredCurrency,
            IsActive = vendor.IsActive,
            Description = vendor.Description,
            CreatedAt = vendor.CreatedAt,
            UpdatedAt = vendor.UpdatedAt,
            CreatedBy = vendor.CreatedBy,
            UpdatedBy = vendor.UpdatedBy
        };
    }
}
