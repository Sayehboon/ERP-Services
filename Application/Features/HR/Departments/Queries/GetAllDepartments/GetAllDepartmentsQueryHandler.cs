using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Departments.Queries.GetAllDepartments;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست بخش‌ها
/// </summary>
public sealed class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست بخش‌ها
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllDepartmentsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست بخش‌ها
    /// </summary>
    public async Task<IEnumerable<DepartmentDto>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Departments
            .Include(d => d.ParentDepartment)
            .Include(d => d.Manager)
            .Include(d => d.Company)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(d => 
                d.Name.ToLower().Contains(searchTerm) ||
                d.Code.ToLower().Contains(searchTerm) ||
                (d.Description != null && d.Description.ToLower().Contains(searchTerm)) ||
                (d.DepartmentType != null && d.DepartmentType.ToLower().Contains(searchTerm)));
        }

        if (request.ParentDepartmentId.HasValue)
        {
            query = query.Where(d => d.ParentDepartmentId == request.ParentDepartmentId.Value);
        }

        if (request.ManagerId.HasValue)
        {
            query = query.Where(d => d.ManagerId == request.ManagerId.Value);
        }

        if (request.CompanyId.HasValue)
        {
            query = query.Where(d => d.CompanyId == request.CompanyId.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.DepartmentType))
        {
            query = query.Where(d => d.DepartmentType == request.DepartmentType);
        }

        if (request.Level.HasValue)
        {
            query = query.Where(d => d.Level == request.Level.Value);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(d => d.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(d => d.Level)
                    .ThenBy(d => d.Name);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var departments = await query.ToListAsync(cancellationToken);

        // محاسبه تعداد کارمندان و زیربخش‌ها برای هر بخش
        var departmentIds = departments.Select(d => d.Id).ToList();
        
        var employeeCounts = await _context.Users
            .Where(u => departmentIds.Contains(u.DepartmentId ?? Guid.Empty))
            .GroupBy(u => u.DepartmentId)
            .Select(g => new { DepartmentId = g.Key, Count = g.Count() })
            .ToListAsync(cancellationToken);

        var subDepartmentCounts = await _context.Departments
            .Where(d => departmentIds.Contains(d.ParentDepartmentId ?? Guid.Empty))
            .GroupBy(d => d.ParentDepartmentId)
            .Select(g => new { ParentDepartmentId = g.Key, Count = g.Count() })
            .ToListAsync(cancellationToken);

        return departments.Select(d => new DepartmentDto
        {
            Id = d.Id,
            Name = d.Name,
            Code = d.Code,
            Description = d.Description,
            ParentDepartmentId = d.ParentDepartmentId,
            ParentDepartmentName = d.ParentDepartment?.Name,
            ManagerId = d.ManagerId,
            ManagerName = d.Manager != null ? $"{d.Manager.FirstName} {d.Manager.LastName}" : null,
            CompanyId = d.CompanyId,
            CompanyName = d.Company?.Name,
            DepartmentType = d.DepartmentType,
            Level = d.Level,
            HierarchyPath = d.HierarchyPath,
            Budget = d.Budget,
            Address = d.Address,
            Phone = d.Phone,
            Email = d.Email,
            IsActive = d.IsActive,
            EmployeeCount = employeeCounts.FirstOrDefault(ec => ec.DepartmentId == d.Id)?.Count ?? 0,
            SubDepartmentCount = subDepartmentCounts.FirstOrDefault(sdc => sdc.ParentDepartmentId == d.Id)?.Count ?? 0,
            CreatedAt = d.CreatedAt,
            UpdatedAt = d.UpdatedAt,
            CreatedBy = d.CreatedBy,
            UpdatedBy = d.UpdatedBy
        });
    }
}
