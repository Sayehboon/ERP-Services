using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.DeleteCompany;

/// <summary>
/// مدیریت‌کننده دستور حذف شرکت
/// </summary>
public sealed class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف شرکت
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف شرکت
    /// </summary>
    public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (company == null)
        {
            throw new ArgumentException($"شرکت با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasUsers = await _context.Users
            .AnyAsync(u => u.CompanyId == request.Id, cancellationToken);
        
        if (hasUsers)
        {
            throw new InvalidOperationException("امکان حذف شرکت به دلیل وجود کاربران وابسته وجود ندارد");
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
