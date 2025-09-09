using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetAllEmployees;

/// <summary>
/// مدیریت‌کننده پرس‌وجو لیست کارمندان
/// </summary>
public sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو لیست کارمندان
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetAllEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو لیست کارمندان
    /// </summary>
    public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Users
            .Include(u => u.UserRoles)
            .Include(u => u.Department)
            .Include(u => u.Company)
            .AsQueryable();

        // اعمال فیلترها
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(u => 
                u.Username.ToLower().Contains(searchTerm) ||
                u.FirstName.ToLower().Contains(searchTerm) ||
                u.LastName.ToLower().Contains(searchTerm) ||
                u.Email.ToLower().Contains(searchTerm) ||
                (u.PhoneNumber != null && u.PhoneNumber.Contains(searchTerm)));
        }

        if (request.DepartmentId.HasValue)
        {
            query = query.Where(u => u.DepartmentId == request.DepartmentId.Value);
        }

        if (request.RoleId.HasValue)
        {
            //query = query.Where(u => u.RoleId == request.RoleId.Value);
        }

        if (request.CompanyId.HasValue)
        {
            query = query.Where(u => u.CompanyId == request.CompanyId.Value);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
        }

        if (request.IsLocked.HasValue)
        {
            query = query.Where(u => u.IsLocked == request.IsLocked.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(u => u.FirstName)
                    .ThenBy(u => u.LastName);

        // صفحه‌بندی
        if (request.Page > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.Page - 1) * request.PageSize)
                        .Take(request.PageSize);
        }

        var users = await query.ToListAsync(cancellationToken);

        return users.Select(u => new EmployeeDto
        {
            Id = u.Id,
            Username = u.Username,
            FirstName = u.FirstName,
            LastName = u.LastName,
            Email = u.Email,
            Phone = u.Phone,
            RoleId = u.RoleId,
            RoleName = u.Role?.Name,
            DepartmentId = u.DepartmentId,
            DepartmentName = u.Department?.Name,
            CompanyId = u.CompanyId,
            CompanyName = u.Company?.Name,
            IsActive = u.IsActive,
            IsLocked = u.IsLocked,
            ExpiryDate = u.ExpiryDate,
            LastLoginDate = u.LastLoginDate,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt,
            CreatedBy = u.CreatedBy,
            UpdatedBy = u.UpdatedBy
        });
    }
}