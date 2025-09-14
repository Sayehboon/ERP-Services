using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Departments.Queries.GetDepartmentById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت بخش بر اساس شناسه
/// </summary>
public sealed class GetDepartmentByIdQueryHandler : IRequestHandler<GetDepartmentByIdQuery, DepartmentDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت بخش بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetDepartmentByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت بخش بر اساس شناسه
    /// </summary>
    public async Task<DepartmentDto> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
        var department = await _context.Departments
            .Include(d => d.ParentDepartment)
            .Include(d => d.Manager)
            .Include(d => d.Company)
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (department == null)
        {
            return null;
        }

        // محاسبه تعداد کارمندان و زیربخش‌ها
        var employeeCount = await _context.Users
            .CountAsync(u => u.DepartmentId == request.Id, cancellationToken);

        var subDepartmentCount = await _context.Departments
            .CountAsync(d => d.ParentDepartmentId == request.Id, cancellationToken);

        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            Code = department.Code,
            Description = department.Description,
            ParentDepartmentId = department.ParentDepartmentId,
            ParentDepartmentName = department.ParentDepartment?.Name,
            ManagerId = department.ManagerId,
            ManagerName = department.Manager != null ? $"{department.Manager.FirstName} {department.Manager.LastName}" : null,
            CompanyId = department.CompanyId,
            CompanyName = department.Company?.Name,
            Level = department.Level,
            HierarchyPath = department.Path,
            IsActive = department.IsActive,
            EmployeeCount = employeeCount,
            SubDepartmentCount = subDepartmentCount,
            CreatedAt = department.CreatedAt,
            UpdatedAt = department.UpdatedAt,
            CreatedBy = department.CreatedBy,
            UpdatedBy = department.UpdatedBy
        };
    }
}
