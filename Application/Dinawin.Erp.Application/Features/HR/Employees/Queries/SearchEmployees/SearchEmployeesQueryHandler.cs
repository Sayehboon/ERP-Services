using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.SearchEmployees;

/// <summary>
/// پردازشگر درخواست جستجوی کارمندان
/// </summary>
public class SearchEmployeesQueryHandler : IRequestHandler<SearchEmployeesQuery, IEnumerable<EmployeeSearchDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public SearchEmployeesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست کارمندان مطابق جستجو</returns>
    public async Task<IEnumerable<EmployeeSearchDto>> Handle(SearchEmployeesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Employees.AsQueryable();

        // جستجو در نام، نام خانوادگی، کد کارمند، ایمیل
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(e => 
                e.FirstName.ToLower().Contains(searchTerm) ||
                e.LastName.ToLower().Contains(searchTerm) ||
                e.EmployeeCode.ToLower().Contains(searchTerm) ||
                (e.Email != null && e.Email.ToLower().Contains(searchTerm)));
        }

        if (request.DepartmentId.HasValue)
        {
            query = query.Where(e => e.DepartmentId == request.DepartmentId.Value);
        }

        if (request.CompanyId.HasValue)
        {
            query = query.Where(e => e.CompanyId == request.CompanyId.Value);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(e => e.IsActive == request.IsActive.Value);
        }

        var employees = await query
            .Select(e => new EmployeeSearchDto
            {
                Id = e.Id,
                EmployeeCode = e.EmployeeCode,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                DepartmentId = e.DepartmentId,
                DepartmentName = e.Department != null ? e.Department.Name : null,
                Position = e.Position,
                IsActive = e.IsActive
            })
            .Take(request.MaxResults)
            .ToListAsync(cancellationToken);

        return employees;
    }
}
