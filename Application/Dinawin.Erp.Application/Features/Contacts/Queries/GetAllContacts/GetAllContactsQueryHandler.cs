using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Contacts.DTOs;

namespace Dinawin.Erp.Application.Features.Contacts.Queries.GetAllContacts;

/// <summary>
/// Handler for getting all contacts
/// </summary>
public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, List<ContactDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllContactsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Contacts.AsQueryable();

        // Apply filters
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(c => 
                c.FirstName.Contains(request.SearchTerm) ||
                c.LastName.Contains(request.SearchTerm) ||
                (c.Email != null && c.Email.Contains(request.SearchTerm)) ||
                (c.Company != null && c.Company.Contains(request.SearchTerm)));
        }

        if (!string.IsNullOrEmpty(request.Status))
            query = query.Where(c => c.Status == request.Status);

        if (!string.IsNullOrEmpty(request.Source))
            query = query.Where(c => c.Source == request.Source);

        if (request.IsActive.HasValue)
            query = query.Where(c => c.IsActive == request.IsActive.Value);

        // Apply pagination
        query = query
            .OrderByDescending(c => c.CreatedAt)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize);

        var contacts = await query
            .Select(c => new ContactDto
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Email = c.Email,
                Phone = c.Phone,
                Mobile = c.Mobile,
                Company = c.Company,
                Position = c.Position,
                Address = c.Address,
                City = c.City,
                PostalCode = c.PostalCode,
                Country = c.Country,
                Notes = c.Notes,
                Source = c.Source,
                Status = c.Status,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt,
                CreatedBy = c.CreatedBy,
                UpdatedBy = c.UpdatedBy,
                IsActive = c.IsActive
            })
            .ToListAsync(cancellationToken);

        return contacts;
    }
}
