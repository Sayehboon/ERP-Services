using MediatR;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;
using Dinawin.Erp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Users.Queries.GetUserById;

/// <summary>
/// پردازشگر کوئری دریافت کاربر با شناسه
/// Handler for getting a user by ID
/// </summary>
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserProfileDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر کوئری دریافت کاربر با شناسه
    /// Constructor for get user by ID query handler
    /// </summary>
    /// <param name="context">زمینه پایگاه داده</param>
    public GetUserByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش کوئری دریافت کاربر با شناسه
    /// Handles the get user by ID query
    /// </summary>
    /// <param name="request">درخواست دریافت کاربر</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>اطلاعات کاربر</returns>
    public async Task<UserProfileDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Company)
            .Include(u => u.Department)
            .Include(u => u.Business)
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            return null;

        return new UserProfileDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            InternalPhone = user.InternalPhone,
            NationalId = user.NationalId,
            BirthDate = user.BirthDate,
            AvatarUrl = user.AvatarUrl,
            IsActive = user.IsActive,
            CompanyName = user.Company?.Name,
            DepartmentName = user.Department?.Name,
            BusinessName = user.Business?.Name,
            RoleNames = user.UserRoles.Select(ur => ur.Role?.Name).Where(name => !string.IsNullOrEmpty(name)).ToList(),
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}
