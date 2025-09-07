using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetAllRoles;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست نقش‌ها
/// </summary>
public sealed class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست نقش‌ها
    /// </summary>
    public GetAllRolesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست نقش‌ها
    /// </summary>
    public async Task<IEnumerable<RoleDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Roles.AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(r => 
                r.Name.ToLower().Contains(searchLower) ||
                (r.Description != null && r.Description.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس وضعیت فعال بودن
        if (request.IsActive.HasValue)
        {
            query = query.Where(r => r.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        query = query.OrderBy(r => r.Name);

        // صفحه‌بندی
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var roles = await query.ToListAsync(cancellationToken);
        
        return roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name,
            Description = r.Description,
            IsActive = r.IsActive,
            Permissions = string.IsNullOrEmpty(r.Permissions) 
                ? new List<string>() 
                : r.Permissions.Split(',').ToList(),
            UsersCount = _context.Users.Count(u => u.RoleId == r.Id),
            CreatedAt = r.CreatedAt,
            UpdatedAt = r.UpdatedAt,
            CreatedBy = r.CreatedBy,
            UpdatedBy = r.UpdatedBy
        });
    }
}
