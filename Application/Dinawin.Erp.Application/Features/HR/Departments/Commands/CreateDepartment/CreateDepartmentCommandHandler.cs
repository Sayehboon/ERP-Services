using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.HR;

namespace Dinawin.Erp.Application.Features.HR.Departments.Commands.CreateDepartment;

/// <summary>
/// مدیریت‌کننده دستور ایجاد بخش جدید
/// </summary>
public sealed class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد بخش جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateDepartmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد بخش جدید
    /// </summary>
    public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کد بخش
        var codeExists = await _context.Departments
            .AnyAsync(d => d.Code == request.Code, cancellationToken);
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

        var department = new Department
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            ParentDepartmentId = request.ParentDepartmentId,
            ManagerId = request.ManagerId,
            CompanyId = request.CompanyId,
            DepartmentType = request.DepartmentType,
            Level = request.Level,
            HierarchyPath = request.HierarchyPath,
            Budget = request.Budget,
            Address = request.Address,
            Phone = request.Phone,
            Email = request.Email,
            IsActive = request.IsActive,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Departments.Add(department);
        await _context.SaveChangesAsync(cancellationToken);
        return department.Id;
    }
}
