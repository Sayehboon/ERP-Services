using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.GetAllVendors;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست تامین‌کنندگان
/// </summary>
public sealed class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, IEnumerable<VendorDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست تامین‌کنندگان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllVendorsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست تامین‌کنندگان
    /// </summary>
    public async Task<IEnumerable<VendorDto>> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Vendors.AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(v => 
                v.Name.ToLower().Contains(searchTerm) ||
                (v.LastName != null && v.LastName.ToLower().Contains(searchTerm)) ||
                (v.CompanyName != null && v.CompanyName.ToLower().Contains(searchTerm)) ||
                (v.NationalId != null && v.NationalId.ToLower().Contains(searchTerm)) ||
                (v.EconomicCode != null && v.EconomicCode.ToLower().Contains(searchTerm)) ||
                (v.Phone != null && v.Phone.ToLower().Contains(searchTerm)) ||
                (v.Mobile != null && v.Mobile.ToLower().Contains(searchTerm)) ||
                (v.Email != null && v.Email.ToLower().Contains(searchTerm)) ||
                (v.Description != null && v.Description.ToLower().Contains(searchTerm)));
        }

        if (!string.IsNullOrWhiteSpace(request.VendorType))
        {
            query = query.Where(v => v.VendorType == request.VendorType);
        }

        if (!string.IsNullOrWhiteSpace(request.City))
        {
            query = query.Where(v => v.City == request.City);
        }

        if (!string.IsNullOrWhiteSpace(request.Province))
        {
            query = query.Where(v => v.Province == request.Province);
        }

        if (!string.IsNullOrWhiteSpace(request.Country))
        {
            query = query.Where(v => v.Country == request.Country);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(v => v.IsActive == request.IsActive.Value);
        }

        if (request.MinCreditLimit.HasValue)
        {
            query = query.Where(v => v.CreditLimit >= request.MinCreditLimit.Value);
        }

        if (request.MaxCreditLimit.HasValue)
        {
            query = query.Where(v => v.CreditLimit <= request.MaxCreditLimit.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.PreferredCurrency))
        {
            query = query.Where(v => v.PreferredCurrency == request.PreferredCurrency);
        }

        // مرتب‌سازی
        query = query.OrderBy(v => v.Name)
                    .ThenBy(v => v.LastName);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var vendors = await query.ToListAsync(cancellationToken);

        return vendors.Select(v => new VendorDto
        {
            Id = v.Id,
            Name = v.Name,
            LastName = v.LastName,
            CompanyName = v.CompanyName,
            VendorType = v.VendorType,
            NationalId = v.NationalId,
            EconomicCode = v.EconomicCode,
            RegistrationNumber = v.RegistrationNumber,
            Phone = v.Phone,
            Mobile = v.Mobile,
            Email = v.Email,
            Address = v.Address,
            City = v.City,
            Province = v.Province,
            PostalCode = v.PostalCode,
            Country = v.Country,
            Website = v.Website,
            BirthDate = v.BirthDate,
            Gender = v.Gender,
            JobTitle = v.JobTitle,
            CreditLimit = v.CreditLimit,
            AccountBalance = v.AccountBalance,
            PaymentTerms = v.PaymentTerms,
            PreferredCurrency = v.PreferredCurrency,
            IsActive = v.IsActive,
            Description = v.Description,
            CreatedAt = v.CreatedAt,
            UpdatedAt = v.UpdatedAt,
            CreatedBy = v.CreatedBy,
            UpdatedBy = v.UpdatedBy
        });
    }
}
