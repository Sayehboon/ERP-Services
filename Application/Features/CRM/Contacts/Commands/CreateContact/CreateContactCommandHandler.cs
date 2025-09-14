using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Crm;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Commands.CreateContact;

/// <summary>
/// پردازشگر دستور ایجاد مخاطب
/// </summary>
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور ایجاد مخاطب
    /// </summary>
    /// <param name="request">درخواست ایجاد مخاطب</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه مخاطب ایجاد شده</returns>
    public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LastName = request.LastName,
            CompanyName = request.CompanyName,
            Position = request.Position,
            Phone = request.Phone,
            Mobile = request.Mobile,
            Email = request.Email,
            Address = request.Address,
            City = request.City,
            Province = request.Province,
            PostalCode = request.PostalCode,
            Country = request.Country,
            BirthDate = request.BirthDate,
            Description = request.Description,
            CreatedBy = request.CreatedBy,
            ContactType = request.ContactType,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}
