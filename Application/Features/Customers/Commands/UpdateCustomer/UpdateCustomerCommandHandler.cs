using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Customers.Commands.UpdateCustomer;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی مشتری
/// </summary>
public sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی مشتری
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی مشتری
    /// </summary>
    public async Task<Guid> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (customer == null)
        {
            throw new ArgumentException($"مشتری با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی شماره ملی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Customers
                .AnyAsync(c => c.NationalId == request.NationalId && c.Id != request.Id, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"مشتری با شماره ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره اقتصادی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.EconomicCode))
        {
            var economicCodeExists = await _context.Customers
                .AnyAsync(c => c.EconomicCode == request.EconomicCode && c.Id != request.Id, cancellationToken);
            if (economicCodeExists)
            {
                throw new ArgumentException($"مشتری با شماره اقتصادی {request.EconomicCode} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی ایمیل در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var emailExists = await _context.Customers
                .AnyAsync(c => c.Email == request.Email && c.Id != request.Id, cancellationToken);
            if (emailExists)
            {
                throw new ArgumentException($"مشتری با ایمیل {request.Email} قبلاً وجود دارد");
            }
        }

        customer.Name = request.Name;
        customer.LastName = request.LastName;
        customer.CompanyName = request.CompanyName;
        customer.CustomerType = request.CustomerType;
        customer.NationalId = request.NationalId;
        customer.EconomicCode = request.EconomicCode;
        customer.RegistrationNumber = request.RegistrationNumber;
        customer.Phone = request.Phone;
        customer.Mobile = request.Mobile;
        customer.Email = request.Email;
        customer.Address = request.Address;
        customer.City = request.City;
        customer.Province = request.Province;
        customer.PostalCode = request.PostalCode;
        customer.Country = request.Country;
        customer.Website = request.Website;
        customer.BirthDate = request.BirthDate;
        customer.Gender = request.Gender;
        customer.JobTitle = request.JobTitle;
        customer.CreditLimit = request.CreditLimit;
        customer.AccountBalance = request.AccountBalance;
        customer.IsActive = request.IsActive;
        customer.Description = request.Description;
        customer.UpdatedBy = request.UpdatedBy;
        customer.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return customer.Id;
    }
}
