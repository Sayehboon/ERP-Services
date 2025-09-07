using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Vendors.Queries.SearchVendors;

/// <summary>
/// مدیریت‌کننده پرس‌وجو جستجوی تامین‌کنندگان
/// </summary>
public sealed class SearchVendorsQueryHandler : IRequestHandler<SearchVendorsQuery, IEnumerable<VendorSearchDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو جستجوی تامین‌کنندگان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public SearchVendorsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو جستجوی تامین‌کنندگان
    /// </summary>
    public async Task<IEnumerable<VendorSearchDto>> Handle(SearchVendorsQuery request, CancellationToken cancellationToken)
    {
        var searchTerm = request.SearchTerm.ToLower();
        
        var query = _context.Vendors.AsQueryable();

        // اعمال فیلترها
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

        // جستجو در فیلدهای مختلف
        var vendors = await query
            .Where(v => 
                v.Name.ToLower().Contains(searchTerm) ||
                v.Code.ToLower().Contains(searchTerm) ||
                (v.CompanyName != null && v.CompanyName.ToLower().Contains(searchTerm)) ||
                (v.ContactName != null && v.ContactName.ToLower().Contains(searchTerm)) ||
                (v.Phone != null && v.Phone.Contains(searchTerm)) ||
                (v.Email != null && v.Email.ToLower().Contains(searchTerm)) ||
                (v.NationalId != null && v.NationalId.Contains(searchTerm)) ||
                (v.EconomicCode != null && v.EconomicCode.Contains(searchTerm)))
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        // محاسبه امتیاز تطبیق و مرتب‌سازی
        var results = vendors.Select(v => new VendorSearchDto
        {
            Id = v.Id,
            Name = v.Name,
            Code = v.Code,
            VendorType = v.VendorType,
            CompanyName = v.CompanyName,
            ContactName = v.ContactName,
            Phone = v.Phone,
            Email = v.Email,
            City = v.City,
            Province = v.Province,
            Country = v.Country,
            IsActive = v.IsActive,
            MatchScore = CalculateMatchScore(v, searchTerm)
        })
        .OrderByDescending(v => v.MatchScore)
        .ThenBy(v => v.Name);

        return results;
    }

    /// <summary>
    /// محاسبه امتیاز تطبیق جستجو
    /// </summary>
    /// <param name="vendor">تامین‌کننده</param>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>امتیاز تطبیق</returns>
    private static int CalculateMatchScore(Dinawin.Erp.Infrastructure.Data.Entities.Vendors.Vendor vendor, string searchTerm)
    {
        int score = 0;

        // امتیاز برای تطبیق دقیق نام
        if (vendor.Name.ToLower() == searchTerm)
            score += 100;
        else if (vendor.Name.ToLower().StartsWith(searchTerm))
            score += 80;
        else if (vendor.Name.ToLower().Contains(searchTerm))
            score += 60;

        // امتیاز برای تطبیق کد
        if (vendor.Code.ToLower() == searchTerm)
            score += 90;
        else if (vendor.Code.ToLower().StartsWith(searchTerm))
            score += 70;
        else if (vendor.Code.ToLower().Contains(searchTerm))
            score += 50;

        // امتیاز برای تطبیق نام شرکت
        if (!string.IsNullOrWhiteSpace(vendor.CompanyName))
        {
            if (vendor.CompanyName.ToLower().Contains(searchTerm))
                score += 40;
        }

        // امتیاز برای تطبیق نام تماس
        if (!string.IsNullOrWhiteSpace(vendor.ContactName))
        {
            if (vendor.ContactName.ToLower().Contains(searchTerm))
                score += 30;
        }

        // امتیاز برای تطبیق شماره تلفن
        if (!string.IsNullOrWhiteSpace(vendor.Phone))
        {
            if (vendor.Phone.Contains(searchTerm))
                score += 20;
        }

        // امتیاز برای تطبیق ایمیل
        if (!string.IsNullOrWhiteSpace(vendor.Email))
        {
            if (vendor.Email.ToLower().Contains(searchTerm))
                score += 20;
        }

        return score;
    }
}
