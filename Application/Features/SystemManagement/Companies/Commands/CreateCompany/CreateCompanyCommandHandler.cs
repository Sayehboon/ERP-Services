using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Users;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.CreateCompany;

/// <summary>
/// مدیریت‌کننده دستور ایجاد شرکت جدید
/// </summary>
public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد شرکت جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد شرکت جدید
    /// </summary>
    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی نام شرکت
        var nameExists = await _context.Companies
            .AnyAsync(c => c.Name == request.Name, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"شرکت با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی یکتایی شماره ملی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Companies
                .AnyAsync(c => c.NationalId == request.NationalId, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"شرکت با شماره ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی شماره اقتصادی در صورت ارسال
        if (!string.IsNullOrWhiteSpace(request.EconomicCode))
        {
            var economicCodeExists = await _context.Companies
                .AnyAsync(c => c.EconomicCode == request.EconomicCode, cancellationToken);
            if (economicCodeExists)
            {
                throw new ArgumentException($"شرکت با شماره اقتصادی {request.EconomicCode} قبلاً وجود دارد");
            }
        }

        var company = new Company
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            TradeName = request.TradeName,
            Type = Enum.TryParse<CompanyType>(request.CompanyType, out var companyType) ? companyType : CompanyType.Private,
            Address = !string.IsNullOrEmpty(request.Address) ? new Address(
                request.Address, 
                request.City ?? "نامشخص", 
                request.Province ?? "نامشخص", 
                request.PostalCode ?? "0000000000", 
                request.Country ?? "Iran") : null,
            PhoneNumber = !string.IsNullOrEmpty(request.Phone) ? new PhoneNumber(request.Phone) : null,
            Email = !string.IsNullOrEmpty(request.Email) ? new Email(request.Email) : null,
            NationalId = request.NationalId,
            EconomicCode = request.EconomicCode,
            RegistrationNumber = request.RegistrationNumber,
            Website = request.Website,
            IsActive = request.IsActive,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync(cancellationToken);
        return company.Id;
    }
}
