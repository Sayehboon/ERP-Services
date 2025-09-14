using MediatR;

namespace Dinawin.Erp.Application.Features.Contacts.Commands.CreateContact;

/// <summary>
/// Command for creating a new contact
/// </summary>
public class CreateContactCommand : IRequest<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Company { get; set; }
    public string Position { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public string Notes { get; set; }
    public string Source { get; set; }
    public string Status { get; set; } = "فعال";
    public Guid? CreatedBy { get; set; }
    public string Description { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ContactType { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
}
