using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.DeleteRole;

/// <summary>
/// مدیریت‌کننده دستور حذف نقش
/// </summary>
public sealed class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور حذف نقش
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public DeleteRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور حذف نقش
    /// </summary>
    public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        var role = await _context.Roles.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);
        if (role == null)
        {
            throw new ArgumentException($"نقش با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        var hasUsers = await _context.Users
            .AnyAsync(u => u.RoleId == request.Id, cancellationToken);
        
        if (hasUsers)
        {
            throw new InvalidOperationException("امکان حذف نقش به دلیل وجود کاربران وابسته وجود ندارد");
        }

        _context.Roles.Remove(role);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
