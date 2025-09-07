using MediatR;
using Dinawin.Erp.Application.Features.Contacts.DTOs;

namespace Dinawin.Erp.Application.Features.Contacts.Queries.GetAllContacts;

/// <summary>
/// Query for getting all contacts with optional filtering
/// </summary>
public class GetAllContactsQuery : IRequest<List<ContactDto>>
{
    public string? SearchTerm { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public string? Source { get; set; }
    public bool? IsActive { get; set; } = true;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
