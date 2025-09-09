using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.AssignPermission;

/// <summary>
/// پردازش‌کننده دستور تخصیص مجوز به نقش
/// </summary>
public sealed class AssignPermissionCommandHandler : IRequestHandler<AssignPermissionCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده دستور تخصیص مجوز به نقش
    /// </summary>
    public AssignPermissionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور تخصیص مجوز به نقش
    /// </summary>
    public async Task<bool> Handle(AssignPermissionCommand request, CancellationToken cancellationToken)
    {
        // بررسی وجود نقش
        var roleExists = await _context.Roles
            .AnyAsync(r => r.Id == request.RoleId, cancellationToken);

        if (!roleExists)
        {
            throw new ArgumentException($"نقش با شناسه {request.RoleId} یافت نشد");
        }

        // بررسی وجود مجوز
        var permissionExists = await _context.Permissions
            .AnyAsync(p => p.Id == request.PermissionId, cancellationToken);

        if (!permissionExists)
        {
            throw new ArgumentException($"مجوز با شناسه {request.PermissionId} یافت نشد");
        }

        // بررسی اینکه آیا مجوز قبلاً به نقش تخصیص داده شده است
        var existingAssignment = await _context.RolePermissions
            .AnyAsync(rp => rp.RoleId == request.RoleId && rp.PermissionId == request.PermissionId, cancellationToken);

        if (existingAssignment)
        {
            throw new ArgumentException("این مجوز قبلاً به نقش تخصیص داده شده است");
        }

        // ایجاد تخصیص مجوز
        var rolePermission = new RolePermission
        {
            Id = Guid.NewGuid(),
            RoleId = request.RoleId,
            PermissionId = request.PermissionId,
            CreatedAt = DateTime.UtcNow
        };

        _context.RolePermissions.Add(rolePermission);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
