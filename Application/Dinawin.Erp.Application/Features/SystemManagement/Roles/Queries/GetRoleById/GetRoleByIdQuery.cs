using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRoleById;

/// <summary>
/// پرس‌وجو دریافت نقش بر اساس شناسه
/// </summary>
public sealed class GetRoleByIdQuery : IRequest<RoleDto?>
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    [Required(ErrorMessage = "شناسه نقش الزامی است")]
    public Guid Id { get; set; }
}
