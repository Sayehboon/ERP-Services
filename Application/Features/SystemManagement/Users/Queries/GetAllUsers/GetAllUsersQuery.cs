using MediatR;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Queries.GetAllUsers;

/// <summary>
/// پرس‌وجو لیست کاربران
/// </summary>
public sealed class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه نقش برای فیلتر
    /// </summary>
    public Guid? RoleId { get; init; }

    /// <summary>
    /// شناسه شرکت برای فیلتر
    /// </summary>
    public Guid? CompanyId { get; init; }

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
