using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.SearchCustomers;

/// <summary>
/// مدیریت‌کننده پرس‌وجو جستجوی مشتریان
/// </summary>
public sealed class SearchCustomersQueryHandler : IRequestHandler<SearchCustomersQuery, IEnumerable<CustomerSearchDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو جستجوی مشتریان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public SearchCustomersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو جستجوی مشتریان
    /// </summary>
    public async Task<IEnumerable<CustomerSearchDto>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
    {
        var searchTerm = request.SearchTerm.ToLower();
        
        var query = _context.Customers.AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.CustomerType))
        {
            query = query.Where(c => c.CustomerType == request.CustomerType);
        }

        if (!string.IsNullOrWhiteSpace(request.City))
        {
            query = query.Where(c => c.City == request.City);
        }

        if (!string.IsNullOrWhiteSpace(request.Province))
        {
            query = query.Where(c => c.Province == request.Province);
        }

        if (!string.IsNullOrWhiteSpace(request.Country))
        {
            query = query.Where(c => c.Country == request.Country);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.IsActive.Value);
        }

        // جستجو در فیلدهای مختلف
        var customers = await query
            .Where(c => 
                c.Name.ToLower().Contains(searchTerm) ||
                c.Code.ToLower().Contains(searchTerm) ||
                (c.CompanyName != null && c.CompanyName.ToLower().Contains(searchTerm)) ||
                (c.ContactName != null && c.ContactName.ToLower().Contains(searchTerm)) ||
                (c.Phone != null && c.Phone.Contains(searchTerm)) ||
                (c.Email != null && c.Email.ToLower().Contains(searchTerm)) ||
                (c.NationalId != null && c.NationalId.Contains(searchTerm)) ||
                (c.EconomicCode != null && c.EconomicCode.Contains(searchTerm)))
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        // محاسبه امتیاز تطبیق و مرتب‌سازی
        var results = customers.Select(c => new CustomerSearchDto
        {
            Id = c.Id,
            Name = c.Name,
            Code = c.Code,
            CustomerType = c.CustomerType,
            CompanyName = c.CompanyName,
            ContactName = c.ContactName,
            Phone = c.Phone,
            Email = c.Email,
            City = c.City,
            Province = c.Province,
            Country = c.Country,
            IsActive = c.IsActive,
            MatchScore = CalculateMatchScore(c, searchTerm)
        })
        .OrderByDescending(c => c.MatchScore)
        .ThenBy(c => c.Name);

        return results;
    }

    /// <summary>
    /// محاسبه امتیاز تطبیق جستجو
    /// </summary>
    /// <param name="customer">مشتری</param>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>امتیاز تطبیق</returns>
    private static int CalculateMatchScore(Dinawin.Erp.Domain.Entities.Accounting.Customer customer, string searchTerm)
    {
        int score = 0;

        // امتیاز برای تطبیق دقیق نام
        if (customer.Name.ToLower() == searchTerm)
            score += 100;
        else if (customer.Name.ToLower().StartsWith(searchTerm))
            score += 80;
        else if (customer.Name.ToLower().Contains(searchTerm))
            score += 60;

        // امتیاز برای تطبیق کد
        if (customer.Code.ToLower() == searchTerm)
            score += 90;
        else if (customer.Code.ToLower().StartsWith(searchTerm))
            score += 70;
        else if (customer.Code.ToLower().Contains(searchTerm))
            score += 50;

        // امتیاز برای تطبیق نام شرکت
        if (!string.IsNullOrWhiteSpace(customer.CompanyName))
        {
            if (customer.CompanyName.ToLower().Contains(searchTerm))
                score += 40;
        }

        // امتیاز برای تطبیق نام تماس
        if (!string.IsNullOrWhiteSpace(customer.ContactName))
        {
            if (customer.ContactName.ToLower().Contains(searchTerm))
                score += 30;
        }

        // امتیاز برای تطبیق شماره تلفن
        if (!string.IsNullOrWhiteSpace(customer.Phone))
        {
            if (customer.Phone.Contains(searchTerm))
                score += 20;
        }

        // امتیاز برای تطبیق ایمیل
        if (!string.IsNullOrWhiteSpace(customer.Email))
        {
            if (customer.Email.ToLower().Contains(searchTerm))
                score += 20;
        }

        return score;
    }
}
