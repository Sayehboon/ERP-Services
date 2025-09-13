using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Users.Queries.GetAllUsers;

/// <summary>
/// پردازش‌کننده پرس‌وجو لیست کاربران
/// Get all users query handler
/// </summary>
public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserProfileDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو لیست کاربران
    /// Get all users query handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    /// <param name="mapper">نگاشت‌کننده</param>
    public GetAllUsersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو لیست کاربران
    /// Handle get all users query
    /// </summary>
    /// <param name="request">درخواست لیست کاربران</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست کاربران</returns>
    public async Task<IEnumerable<UserProfileDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Users
            .Include(u => u.Company)
            .Include(u => u.Department)
            .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
            .AsQueryable();

        // فیلتر بر اساس عبارت جستجو
        // Filter by search term
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchLower = request.SearchTerm.ToLower();
            query = query.Where(u => 
                u.FirstName.ToLower().Contains(searchLower) ||
                u.LastName.ToLower().Contains(searchLower) ||
                u.Username.ToLower().Contains(searchLower) ||
                (u.Email != null && u.Email.ToLower().Contains(searchLower)));
        }

        // فیلتر بر اساس شرکت
        // Filter by company
        if (request.CompanyId.HasValue)
        {
            query = query.Where(u => u.CompanyId == request.CompanyId.Value);
        }

        // فیلتر بر اساس بخش
        // Filter by department
        if (request.DepartmentId.HasValue)
        {
            query = query.Where(u => u.DepartmentId == request.DepartmentId.Value);
        }

        // فیلتر بر اساس نقش
        // Filter by role
        if (request.RoleId.HasValue)
        {
            query = query.Where(u => u.UserRoles.Any(ur => ur.RoleId == request.RoleId.Value && ur.IsActive && !ur.IsExpired));
        }

        // فیلتر بر اساس وضعیت فعال/غیرفعال
        // Filter by active status
        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
        }

        // مرتب‌سازی
        // Ordering
        query = query.OrderBy(u => u.FirstName).ThenBy(u => u.LastName);

        // صفحه‌بندی
        // Pagination
        if (request.Page > 1)
        {
            query = query.Skip((request.Page - 1) * request.PageSize);
        }
        
        query = query.Take(request.PageSize);

        var users = await query.ToListAsync(cancellationToken);
        
        return _mapper.Map<IEnumerable<UserProfileDto>>(users);
    }
}
