using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.UpdateRole;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی نقش
/// </summary>
public sealed class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی نقش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی نقش
    /// </summary>
    public async Task<Guid> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        if (role == null)
        {
            throw new ArgumentException($"نقش با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی نام نقش
        var nameExists = await _context.Roles
            .AnyAsync(r => r.Name == request.Name && r.Id != request.Id, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"نقش با نام {request.Name} قبلاً وجود دارد");
        }

        role.Name = request.Name;
        role.Description = request.Description;
        role.IsActive = request.IsActive;
        // Note: Permissions are managed through RolePermissions collection, not directly assignable
        role.UpdatedBy = request.UpdatedBy;
        role.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return role.Id;
    }
}
