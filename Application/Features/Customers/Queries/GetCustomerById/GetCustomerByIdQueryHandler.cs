using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت مشتری بر اساس شناسه
/// </summary>
public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت مشتری بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetCustomerByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت مشتری بر اساس شناسه
    /// </summary>
    public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (customer == null)
        {
            return null;
        }

        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name,
            LastName = customer.LastName,
            CompanyName = customer.CompanyName,
            CustomerType = customer.CustomerType,
            NationalId = customer.NationalId,
            EconomicCode = customer.EconomicCode,
            RegistrationNumber = customer.RegistrationNumber,
            Phone = customer.Phone,
            Mobile = customer.Mobile,
            Email = customer.Email,
            Address = customer.Address,
            City = customer.City,
            Province = customer.Province,
            PostalCode = customer.PostalCode,
            Country = customer.Country,
            Website = customer.Website,
            BirthDate = customer.BirthDate,
            Gender = customer.Gender,
            JobTitle = customer.JobTitle,
            CreditLimit = customer.CreditLimit,
            AccountBalance = customer.AccountBalance,
            IsActive = customer.IsActive,
            Description = customer.Description,
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt,
            CreatedBy = customer.CreatedBy,
            UpdatedBy = customer.UpdatedBy
        };
    }
}
