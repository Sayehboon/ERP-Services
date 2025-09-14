using MediatR;

namespace Dinawin.Erp.Application.Features.HR.Departments.Queries.GetAllDepartments;

/// <summary>
/// پرس‌وجو لیست بخش‌ها
/// </summary>
public sealed class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
{
    /// <summary>
    /// عبارت جستجو
    /// </summary>
    public string SearchTerm { get; init; }

    /// <summary>
    /// شناسه بخش والد برای فیلتر
    /// </summary>
    public Guid? ParentDepartmentId { get; init; }

    /// <summary>
    /// شناسه مدیر برای فیلتر
    /// </summary>
    public Guid? ManagerId { get; init; }

    /// <summary>
    /// شناسه شرکت برای فیلتر
    /// </summary>
    public Guid? CompanyId { get; init; }

    /// <summary>
    /// نوع بخش برای فیلتر
    /// </summary>
    public string DepartmentType { get; init; }

    /// <summary>
    /// سطح بخش برای فیلتر
    /// </summary>
    public int? Level { get; init; }

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
