using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;

/// <summary>
/// پرس‌وجو دریافت کارمند بر اساس شناسه
/// </summary>
public sealed class GetEmployeeByIdQuery : IRequest<EmployeeDto?>
{
    /// <summary>
    /// شناسه کارمند
    /// </summary>
    [Required(ErrorMessage = "شناسه کارمند الزامی است")]
    public Guid Id { get; set; }
}