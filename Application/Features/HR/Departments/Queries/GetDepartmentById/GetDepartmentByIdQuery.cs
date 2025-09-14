using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.HR.Departments.Queries.GetDepartmentById;

/// <summary>
/// پرس‌وجو دریافت بخش بر اساس شناسه
/// </summary>
public sealed class GetDepartmentByIdQuery : IRequest<DepartmentDto>
{
    /// <summary>
    /// شناسه بخش
    /// </summary>
    [Required(ErrorMessage = "شناسه بخش الزامی است")]
    public Guid Id { get; set; }
}
