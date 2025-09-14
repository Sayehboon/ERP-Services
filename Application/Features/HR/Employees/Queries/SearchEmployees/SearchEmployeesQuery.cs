using MediatR;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.SearchEmployees;

/// <summary>
/// درخواست جستجوی کارمندان
/// </summary>
public class SearchEmployeesQuery : IRequest<IEnumerable<EmployeeSearchDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; set; } = string.Empty;

    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid? DepartmentId { get; set; }

    /// <summary>
    /// شناسه شرکت
    /// </summary>
    public Guid? CompanyId { get; set; }

    /// <summary>
    /// آیا فقط کارمندان فعال را برگرداند
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// حداکثر تعداد نتایج
    /// </summary>
    public int MaxResults { get; set; } = 20;
}
