using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetAllEmployees;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeesByDepartment;

/// <summary>
/// پردازشگر درخواست دریافت کارمندان یک بخش
/// </summary>
public class GetEmployeesByDepartmentQueryHandler : IRequestHandler<GetEmployeesByDepartmentQuery, IEnumerable<EmployeeDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetEmployeesByDepartmentQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست کارمندان بخش</returns>
    public async Task<IEnumerable<EmployeeDto>> Handle(GetEmployeesByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Employees
            .Where(e => e.DepartmentId == request.DepartmentId);

        if (request.IsActive.HasValue)
        {
            query = query.Where(e => e.IsActive == request.IsActive.Value);
        }

        if (request.MaxResults.HasValue)
        {
            query = query.Take(request.MaxResults.Value);
        }

        var employees = await query
            .Select(e => new EmployeeDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department != null ? e.Department.Name : string.Empty,
                Position = e.Position,
                HireDate = e.HireDate,
                Salary = e.Salary,
                IsActive = e.IsActive,
                IsLocked = e.IsLocked,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            })
            .ToListAsync(cancellationToken);

        return employees;
    }
}
