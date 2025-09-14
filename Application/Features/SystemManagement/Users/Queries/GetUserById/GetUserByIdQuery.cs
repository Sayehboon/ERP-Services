using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Queries.GetUserById;

/// <summary>
/// پرس‌وجو دریافت کاربر بر اساس شناسه
/// </summary>
public sealed class GetUserByIdQuery : IRequest<UserDto>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid Id { get; set; }
}
