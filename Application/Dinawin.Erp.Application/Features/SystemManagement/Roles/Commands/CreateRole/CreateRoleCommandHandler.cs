using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.SystemManagement;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.CreateRole;

/// <summary>
/// مدیریت‌کننده دستور ایجاد نقش جدید
/// </summary>
public sealed class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد نقش جدید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateRoleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد نقش جدید
    /// </summary>
    public async Task<Guid> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی نام نقش
        var nameExists = await _context.Roles
            .AnyAsync(r => r.Name == request.Name, cancellationToken);
        if (nameExists)
        {
            throw new ArgumentException($"نقش با نام {request.Name} قبلاً وجود دارد");
        }

        // بررسی یکتایی کد نقش
        var codeExists = await _context.Roles
            .AnyAsync(r => r.Code == request.Code, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"نقش با کد {request.Code} قبلاً وجود دارد");
        }

        var role = new Role
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description,
            IsActive = request.IsActive,
            IsSystem = request.IsSystem,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Roles.Add(role);
        await _context.SaveChangesAsync(cancellationToken);
        return role.Id;
    }
}
