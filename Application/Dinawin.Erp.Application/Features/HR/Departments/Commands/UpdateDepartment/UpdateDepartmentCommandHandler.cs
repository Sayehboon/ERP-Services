using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Departments.Commands.UpdateDepartment;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی بخش
/// </summary>
public sealed class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی بخش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی بخش
    /// </summary>
    public async Task<Guid> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
        if (department == null)
        {
            throw new ArgumentException($"بخش با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی کد بخش
        var codeExists = await _context.Departments
            .AnyAsync(d => d.Code == request.Code && d.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"بخش با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی وجود بخش والد در صورت ارسال
        if (request.ParentDepartmentId.HasValue)
        {
            var parentExists = await _context.Departments
                .AnyAsync(d => d.Id == request.ParentDepartmentId.Value, cancellationToken);
            if (!parentExists)
            {
                throw new ArgumentException($"بخش والد با شناسه {request.ParentDepartmentId} یافت نشد");
            }

            // بررسی چرخه در سلسله مراتب
            if (request.ParentDepartmentId.Value == request.Id)
            {
                throw new ArgumentException("بخش نمی‌تواند والد خود باشد");
            }
        }

        // بررسی وجود مدیر در صورت ارسال
        if (request.ManagerId.HasValue)
        {
            var managerExists = await _context.Users
                .AnyAsync(u => u.Id == request.ManagerId.Value, cancellationToken);
            if (!managerExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.ManagerId} یافت نشد");
            }
        }

        // بررسی وجود شرکت در صورت ارسال
        if (request.CompanyId.HasValue)
        {
            var companyExists = await _context.Companies
                .AnyAsync(c => c.Id == request.CompanyId.Value, cancellationToken);
            if (!companyExists)
            {
                throw new ArgumentException($"شرکت با شناسه {request.CompanyId} یافت نشد");
            }
        }

        department.Name = request.Name;
        department.Code = request.Code;
        department.Description = request.Description;
        department.ParentDepartmentId = request.ParentDepartmentId;
        department.ManagerId = request.ManagerId;
        department.CompanyId = request.CompanyId;
        department.DepartmentType = request.DepartmentType;
        department.Level = request.Level;
        department.HierarchyPath = request.HierarchyPath;
        department.Budget = request.Budget;
        department.Address = request.Address;
        department.Phone = request.Phone;
        department.Email = request.Email;
        department.IsActive = request.IsActive;
        department.UpdatedBy = request.UpdatedBy;
        department.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return department.Id;
    }
}
