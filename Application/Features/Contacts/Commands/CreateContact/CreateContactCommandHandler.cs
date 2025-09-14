using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Crm;

namespace Dinawin.Erp.Application.Features.Contacts.Commands.CreateContact;

/// <summary>
/// Handler for creating a new contact
/// </summary>
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Mobile = request.Mobile,
            CompanyName = request.CompanyName,
            Position = request.Position,
            Address = request.Address,
            City = request.City,
            PostalCode = request.PostalCode,
            Country = request.Country,
            Description = request.Description,
            ContactType = request.ContactType,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow,
            IsActive = request.IsActive
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}
