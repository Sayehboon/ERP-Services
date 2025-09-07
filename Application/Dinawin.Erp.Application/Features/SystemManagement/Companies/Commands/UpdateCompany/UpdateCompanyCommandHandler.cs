using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.UpdateCompany;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی شرکت
/// </summary>
public sealed class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی شرکت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی شرکت
    /// </summary>
    public async Task<Guid> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (company == null)
        {
            throw new ArgumentException($"شرکت با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی نام شرکت
        var nameExists = await _context.Companies
            .AnyAsync(c => c.Name == request.Name && c.Id != request.Id, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"شرکت با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی یکتایی شماره ثبت (اگر مشخص شده باشد)
        if (!string.IsNullOrWhiteSpace(request.RegistrationNumber))
        {
            var registrationExists = await _context.Companies
                .AnyAsync(c => c.RegistrationNumber == request.RegistrationNumber && c.Id != request.Id, cancellationToken);
            if (registrationExists)
            {
                throw new ArgumentException($"شرکت با شماره ثبت {request.RegistrationNumber} قبلاً وجود دارد");
            }
        }

        // بررسی یکتایی کد ملی (اگر مشخص شده باشد)
        if (!string.IsNullOrWhiteSpace(request.NationalId))
        {
            var nationalIdExists = await _context.Companies
                .AnyAsync(c => c.NationalId == request.NationalId && c.Id != request.Id, cancellationToken);
            if (nationalIdExists)
            {
                throw new ArgumentException($"شرکت با کد ملی {request.NationalId} قبلاً وجود دارد");
            }
        }

        company.Name = request.Name;
        company.TradeName = request.TradeName;
        company.RegistrationNumber = request.RegistrationNumber;
        company.NationalId = request.NationalId;
        company.EconomicCode = request.EconomicCode;
        company.Address = request.Address;
        company.PhoneNumber = request.PhoneNumber;
        company.FaxNumber = request.FaxNumber;
        company.Email = request.Email;
        company.Website = request.Website;
        company.Description = request.Description;
        company.IsActive = request.IsActive;
        company.UpdatedBy = request.UpdatedBy;
        company.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return company.Id;
    }
}
