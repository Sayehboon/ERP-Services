using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.SystemManagement;

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

        // بررسی یکتایی کد شرکت
        var codeExists = await _context.Companies
            .AnyAsync(c => c.Code == request.Code, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"شرکت با کد {request.Code} قبلاً وجود دارد");
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
            Code = request.Code,
            CompanyType = request.CompanyType,
            Address = request.Address,
            City = request.City,
            Province = request.Province,
            Country = request.Country,
            PostalCode = request.PostalCode,
            Phone = request.Phone,
            Email = request.Email,
            NationalId = request.NationalId,
            EconomicCode = request.EconomicCode,
            RegistrationNumber = request.RegistrationNumber,
            Website = request.Website,
            IsActive = request.IsActive,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Companies.Add(company);
        await _context.SaveChangesAsync(cancellationToken);
        return company.Id;
    }
}
