using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.Customers;

namespace Dinawin.Erp.Application.Features.Customers.Commands.CreateCustomer;

/// <summary>
/// مدیریت‌کننده دستور ایجاد مشتری جدید
/// </summary>
public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد مشتری جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateCustomerCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد مشتری جدید
    /// </summary>
    public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کد مشتری
        var codeExists = await _context.Customers
            .AnyAsync(c => c.Code == request.Code, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"مشتری با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی یکتایی شماره ملی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Customers
                .AnyAsync(c => c.NationalId == request.NationalId, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"مشتری با شماره ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره اقتصادی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.EconomicCode))
        {
            var economicCodeExists = await _context.Customers
                .AnyAsync(c => c.EconomicCode == request.EconomicCode, cancellationToken);
            if (economicCodeExists)
            {
                throw new ArgumentException($"مشتری با شماره اقتصادی {request.EconomicCode} قبلاً وجود دارد");
            }
        }

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            CustomerType = request.CustomerType,
            CompanyName = request.CompanyName,
            ContactName = request.ContactName,
            Phone = request.Phone,
            Email = request.Email,
            Address = request.Address,
            City = request.City,
            Province = request.Province,
            Country = request.Country,
            PostalCode = request.PostalCode,
            NationalId = request.NationalId,
            EconomicCode = request.EconomicCode,
            CreditLimit = request.CreditLimit,
            PreferredCurrency = request.PreferredCurrency,
            PaymentTerms = request.PaymentTerms,
            DiscountRate = request.DiscountRate,
            IsActive = request.IsActive,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync(cancellationToken);
        return customer.Id;
    }
}
