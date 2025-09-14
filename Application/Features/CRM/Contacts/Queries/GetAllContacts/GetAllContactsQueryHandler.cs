using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.CRM.Contacts.DTOs;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Queries.GetAllContacts;

/// <summary>
/// پردازشگر کوئری دریافت تمام مخاطبین
/// Handler for getting all contacts
/// </summary>
public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر کوئری دریافت تمام مخاطبین
    /// Constructor for get all contacts query handler
    /// </summary>
    /// <param name="context">زمینه پایگاه داده</param>
    public GetAllContactsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش کوئری دریافت تمام مخاطبین
    /// Handles the get all contacts query
    /// </summary>
    /// <param name="request">درخواست دریافت مخاطبین</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست مخاطبین</returns>
    public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Contacts.AsQueryable();

        // اعمال فیلترها
        // Apply filters
        if (!string.IsNullOrEmpty(request.ContactType))
        {
            query = query.Where(c => c.ContactType == request.ContactType);
        }

        if (request.IsActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.IsActive.Value);
        }

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(c => 
                c.Name.ToLower().Contains(searchTerm) ||
                c.LastName.ToLower().Contains(searchTerm) ||
                (c.Email != null && c.Email.ToLower().Contains(searchTerm)) ||
                (c.CompanyName != null && c.CompanyName.ToLower().Contains(searchTerm)));
        }

        // مرتب‌سازی
        // Ordering
        query = query.OrderBy(c => c.Name).ThenBy(c => c.LastName);

        // صفحه‌بندی
        // Pagination
        if (request.PageNumber > 0 && request.PageSize > 0)
        {
            query = query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
        }

        var contacts = await query.Select(c => new ContactDto
        {
            Id = c.Id,
            Name = c.Name,
            LastName = c.LastName,
            Email = c.Email,
            Phone = c.Phone,
            Mobile = c.Mobile,
            Address = c.Address,
            City = c.City,
            Province = c.Province,
            PostalCode = c.PostalCode,
            Country = c.Country,
            CompanyName = c.CompanyName,
            Position = c.Position,
            ContactType = c.ContactType,
            IsActive = c.IsActive,
            Description = c.Description,
            CreatedAt = c.CreatedAt,
            UpdatedAt = c.UpdatedAt
        }).ToListAsync(cancellationToken);

        return contacts;
    }
}
