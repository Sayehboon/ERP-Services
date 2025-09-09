using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Users;
using BCrypt.Net;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.CreateUser;

/// <summary>
/// مدیریت‌کننده دستور ایجاد کاربر جدید
/// </summary>
public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد کاربر جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateUserCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد کاربر جدید
    /// </summary>
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی نام کاربری
        var usernameExists = await _context.Users
            .AnyAsync(u => u.Username == request.Username, cancellationToken);
        if (usernameExists)
        {
            throw new ArgumentException($"کاربر با نام کاربری {request.Username} قبلاً وجود دارد");
        }

        // بررسی یکتایی ایمیل
        var emailExists = await _context.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);
        if (emailExists)
        {
            throw new ArgumentException($"کاربر با ایمیل {request.Email} قبلاً وجود دارد");
        }

        // بررسی وجود نقش در صورت ارسال
        if (request.RoleId.HasValue)
        {
            var roleExists = await _context.Roles
                .AnyAsync(r => r.Id == request.RoleId.Value, cancellationToken);
            if (!roleExists)
            {
                throw new ArgumentException($"نقش با شناسه {request.RoleId} یافت نشد");
            }
        }

        // بررسی وجود بخش در صورت ارسال
        if (request.DepartmentId.HasValue)
        {
            var departmentExists = await _context.Departments
                .AnyAsync(d => d.Id == request.DepartmentId.Value, cancellationToken);
            if (!departmentExists)
            {
                throw new ArgumentException($"بخش با شناسه {request.DepartmentId} یافت نشد");
            }
        }

        // بررسی وجود شرکت در صورت ارسال
        if (request.CompanyId.HasValue)
        {
            var companyExists = await _context.Companies
                .AnyAsync(c => c.Id == request.CompanyId.Value, cancellationToken);
            if (!companyExists)
            {
                throw new ArgumentException($"شرکت با شناسه {request.CompanyId} یافت نشد");
            }
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = request.Username,
            PasswordHash = HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            RoleId = request.RoleId,
            DepartmentId = request.DepartmentId,
            CompanyId = request.CompanyId,
            IsActive = request.IsActive,
            IsLocked = request.IsLocked,
            ExpiryDate = request.ExpiryDate,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);
        return user.Id;
    }

    /// <summary>
    /// هش کردن رمز عبور با استفاده از BCrypt
    /// </summary>
    /// <param name="password">رمز عبور</param>
    /// <returns>رمز عبور هش شده</returns>
    private static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt(12));
    }
}