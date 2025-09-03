using MediatR;
using Dinawin.Erp.Application.Features.Users.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Users.Queries.GetAllUsers;

/// <summary>
/// پرس‌وجو لیست کاربران
/// Query for getting all users
/// </summary>
public record GetAllUsersQuery : IRequest<IEnumerable<UserProfileDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// Search term
    /// </summary>
    public string? SearchTerm { get; init; }

    /// <summary>
    /// شناسه شرکت
    /// Company ID filter
    /// </summary>
    public Guid? CompanyId { get; init; }

    /// <summary>
    /// شناسه بخش
    /// Department ID filter
    /// </summary>
    public Guid? DepartmentId { get; init; }

    /// <summary>
    /// شناسه نقش
    /// Role ID filter
    /// </summary>
    public Guid? RoleId { get; init; }

    /// <summary>
    /// فقط کاربران فعال
    /// Only active users
    /// </summary>
    public bool? IsActive { get; init; }

    /// <summary>
    /// شماره صفحه
    /// Page number
    /// </summary>
    public int Page { get; init; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// Items per page
    /// </summary>
    public int PageSize { get; init; } = 25;
}
