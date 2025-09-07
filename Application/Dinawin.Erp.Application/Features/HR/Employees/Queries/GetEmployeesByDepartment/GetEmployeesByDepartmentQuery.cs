using MediatR;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeesByDepartment;

/// <summary>
/// درخواست دریافت کارمندان یک بخش
/// </summary>
public class GetEmployeesByDepartmentQuery : IRequest<IEnumerable<EmployeeDto>>
{
    /// <summary>
    /// شناسه بخش
    /// </summary>
    public Guid DepartmentId { get; set; }

    /// <summary>
    /// آیا فقط کارمندان فعال را برگرداند
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// تعداد نتایج
    /// </summary>
    public int? MaxResults { get; set; }
}
