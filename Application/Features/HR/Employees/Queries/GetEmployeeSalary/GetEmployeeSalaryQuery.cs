using MediatR;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeSalary;

/// <summary>
/// پرس‌وجو دریافت حقوق کارمند
/// </summary>
public sealed class GetEmployeeSalaryQuery : IRequest<EmployeeSalaryDto>
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    public required Guid EmployeeId { get; init; }

    /// <summary>
    /// سال
    /// </summary>
    public int? Year { get; init; }

    /// <summary>
    /// ماه
    /// </summary>
    public int? Month { get; init; }

    /// <summary>
    /// آیا شامل جزئیات باشد
    /// </summary>
    public bool IncludeDetails { get; init; } = true;
}
