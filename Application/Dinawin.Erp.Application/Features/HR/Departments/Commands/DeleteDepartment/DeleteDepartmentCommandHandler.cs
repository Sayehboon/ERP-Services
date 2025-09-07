using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Departments.Commands.DeleteDepartment;

/// <summary>
/// مدیریت‌کننده دستور حذف بخش
/// </summary>
public sealed class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف بخش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف بخش
    /// </summary>
    public async Task<bool> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
        if (department == null)
        {
            throw new ArgumentException($"بخش با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasSubDepartments = await _context.Departments
            .AnyAsync(d => d.ParentDepartmentId == request.Id, cancellationToken);
        
        if (hasSubDepartments)
        {
            throw new InvalidOperationException("امکان حذف بخش به دلیل وجود زیربخش‌های وابسته وجود ندارد");
        }

        var hasEmployees = await _context.Users
            .AnyAsync(u => u.DepartmentId == request.Id, cancellationToken);
        
        if (hasEmployees)
        {
            throw new InvalidOperationException("امکان حذف بخش به دلیل وجود کارمندان وابسته وجود ندارد");
        }

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
