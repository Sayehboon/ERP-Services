using MediatR;
using Dinawin.Erp.Application.Features.CRM.Contacts.DTOs;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Queries.GetAllContacts;

/// <summary>
/// کوئری دریافت تمام مخاطبین
/// Query to get all contacts
/// </summary>
public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
{
    /// <summary>
    /// فیلتر بر اساس نوع مخاطب
    /// Filter by contact type
    /// </summary>
    public string ContactType { get; set; }

    /// <summary>
    /// فیلتر بر اساس وضعیت فعال بودن
    /// Filter by active status
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// جستجو در نام یا ایمیل
    /// Search in name or email
    /// </summary>
    public string SearchTerm { get; set; }

    /// <summary>
    /// شماره صفحه
    /// Page number
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// تعداد آیتم در هر صفحه
    /// Items per page
    /// </summary>
    public int PageSize { get; set; } = 10;
}
