using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetRolePermissions;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت مجوزهای نقش
/// </summary>
public sealed class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, IEnumerable<PermissionDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت مجوزهای نقش
    /// </summary>
    public GetRolePermissionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت مجوزهای نقش
    /// </summary>
    public async Task<IEnumerable<PermissionDto>> Handle(GetRolePermissionsQuery request, CancellationToken cancellationToken)
    {
        var permissions = await _context.RolePermissions
            .Include(rp => rp.Permission)
            .Where(rp => rp.RoleId == request.RoleId)
            .Select(rp => rp.Permission)
            .Where(p => p != null && p.IsActive)
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        return _mapper.Map<IEnumerable<PermissionDto>>(permissions);
    }
}
