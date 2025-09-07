using MediatR;
using Dinawin.Erp.Domain.Entities;
using Dinawin.Erp.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Users.Commands.CreateUser;

/// <summary>
/// پردازشگر دستور ایجاد کاربر جدید
/// Handler for creating a new user
/// </summary>
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر دستور ایجاد کاربر
    /// Constructor for create user command handler
    /// </summary>
    /// <param name="context">زمینه پایگاه داده</param>
    public CreateUserCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد کاربر جدید
    /// Handles the create user command
    /// </summary>
    /// <param name="request">درخواست ایجاد کاربر</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه کاربر ایجاد شده</returns>
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // ایجاد کاربر جدید
        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            InternalPhone = request.InternalPhone,
            NationalId = request.NationalId,
            BirthDate = request.BirthDate,
            AvatarUrl = request.AvatarUrl,
            IsActive = request.IsActive,
            CompanyId = request.CompanyId,
            DepartmentId = request.DepartmentId,
            BusinessId = request.BusinessId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);

        // اختصاص نقش‌ها به کاربر
        if (request.RoleIds.Any())
        {
            var userRoles = request.RoleIds.Select(roleId => new UserRole
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                RoleId = roleId,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            _context.UserRoles.AddRange(userRoles);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
