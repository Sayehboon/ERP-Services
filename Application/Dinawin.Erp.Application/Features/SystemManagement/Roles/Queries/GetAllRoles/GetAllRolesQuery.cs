using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Queries.GetAllRoles;

/// <summary>
/// پرس‌وجو لیست نقش‌ها
/// </summary>
public sealed class GetAllRolesQuery : IRequest<IEnumerable<RoleDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// وضعیت فعال بودن برای فیلتر
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// شماره صفحه
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// </summary>
    public int PageSize { get; init; } = 25;
}
