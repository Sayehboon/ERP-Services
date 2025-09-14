using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetAllCustomers;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست مشتریان
/// </summary>
public sealed class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست مشتریان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllCustomersQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست مشتریان
    /// </summary>
    public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Customers.AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(c => 
                c.Name.ToLower().Contains(searchTerm) ||
                (c.LastName != null && c.LastName.ToLower().Contains(searchTerm)) ||
                (c.CompanyName != null && c.CompanyName.ToLower().Contains(searchTerm)) ||
                (c.NationalId != null && c.NationalId.ToLower().Contains(searchTerm)) ||
                (c.EconomicCode != null && c.EconomicCode.ToLower().Contains(searchTerm)) ||
                (c.Phone != null && c.Phone.ToLower().Contains(searchTerm)) ||
                (c.Mobile != null && c.Mobile.ToLower().Contains(searchTerm)) ||
                (c.Email != null && c.Email.ToLower().Contains(searchTerm)) ||
                (c.Description != null && c.Description.ToLower().Contains(searchTerm)));
        }

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

        if (request.MinCreditLimit.HasValue)
        {
            query = query.Where(c => c.CreditLimit >= request.MinCreditLimit.Value);
        }

        if (request.MaxCreditLimit.HasValue)
        {
            query = query.Where(c => c.CreditLimit <= request.MaxCreditLimit.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(c => c.Name)
                    .ThenBy(c => c.LastName);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var customers = await query.ToListAsync(cancellationToken);

        return customers.Select(c => new CustomerDto
        {
            Id = c.Id,
            Name = c.Name,
            LastName = c.LastName,
            CompanyName = c.CompanyName,
            CustomerType = c.CustomerType,
            NationalId = c.NationalId,
            EconomicCode = c.EconomicCode,
            RegistrationNumber = c.RegistrationNumber,
            Phone = c.Phone,
            Mobile = c.Mobile,
            Email = c.Email,
            Address = c.Address,
            City = c.City,
            Province = c.Province,
            PostalCode = c.PostalCode,
            Country = c.Country,
            Website = c.Website,
            BirthDate = c.BirthDate,
            Gender = c.Gender,
            JobTitle = c.JobTitle,
            CreditLimit = c.CreditLimit,
            AccountBalance = c.AccountBalance,
            IsActive = c.IsActive,
            Description = c.Description,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt,
            CreatedBy = c.CreatedBy,
            UpdatedBy = c.UpdatedBy
        });
    }
}
