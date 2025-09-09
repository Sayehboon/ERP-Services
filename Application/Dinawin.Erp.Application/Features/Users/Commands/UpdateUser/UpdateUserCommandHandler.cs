using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Users.Commands.UpdateUser;

/// <summary>
/// پردازشگر دستور ویرایش کاربر
/// Handler for updating a user
/// </summary>
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر دستور ویرایش کاربر
    /// Constructor for update user command handler
    /// </summary>
    /// <param name="context">زمینه پایگاه داده</param>
    public UpdateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ویرایش کاربر
    /// Handles the update user command
    /// </summary>
    /// <param name="request">درخواست ویرایش کاربر</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>نتیجه عملیات</returns>
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user == null)
            return false;

        // بروزرسانی اطلاعات کاربر
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        // Email is a value object; keep as is if not changing here
        user.AvatarUrl = request.AvatarUrl;
        user.AvatarUrl = request.AvatarUrl;
        user.IsActive = request.IsActive;
        user.CompanyId = request.CompanyId;
        user.DepartmentId = request.DepartmentId;
        user.UpdatedAt = DateTime.UtcNow;

        // بروزرسانی نقش‌های کاربر
        var existingUserRoles = await _context.UserRoles
            .Where(ur => ur.UserId == request.Id)
            .ToListAsync(cancellationToken);

        _context.UserRoles.RemoveRange(existingUserRoles);

        if (request.RoleIds.Any())
        {
            var newUserRoles = request.RoleIds.Select(roleId => new Dinawin.Erp.Domain.Entities.Users.UserRole
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                RoleId = roleId,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            _context.UserRoles.AddRange(newUserRoles);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
