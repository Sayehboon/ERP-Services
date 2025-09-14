using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;

/// <summary>
/// مدیریت‌کننده پرس‌وجو دریافت کارمند بر اساس شناسه
/// </summary>
public sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده پرس‌وجو دریافت کارمند بر اساس شناسه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public GetEmployeeByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای پرس‌وجو دریافت کارمند بر اساس شناسه
    /// </summary>
    public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .Include(u => u.Department)
            .Include(u => u.Company)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
        {
            return null;
        }

        return new EmployeeDto
        {
            Id = user.Id,
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            RoleId = user.RoleId,
            RoleName = user.Role?.Name,
            DepartmentId = user.DepartmentId,
            DepartmentName = user.Department?.Name,
            CompanyId = user.CompanyId,
            CompanyName = user.Company?.Name,
            IsActive = user.IsActive,
            IsLocked = user.IsLocked,
            ExpiryDate = user.ExpiryDate,
            LastLoginDate = user.LastLoginDate,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt,
            CreatedBy = user.CreatedBy,
            UpdatedBy = user.UpdatedBy
        };
    }
}