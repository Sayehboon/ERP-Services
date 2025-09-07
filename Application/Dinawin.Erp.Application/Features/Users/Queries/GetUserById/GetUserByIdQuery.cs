using MediatR;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Users.Queries.GetUserById;

/// <summary>
/// کوئری دریافت کاربر با شناسه
/// Query for getting a user by ID
/// </summary>
public class GetUserByIdQuery : IRequest<UserProfileDto?>
{
    /// <summary>
    /// شناسه کاربر
    /// User ID
    /// </summary>
    public Guid Id { get; set; }
}
