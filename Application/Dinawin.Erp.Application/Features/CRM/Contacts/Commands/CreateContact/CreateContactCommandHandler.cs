using MediatR;
using Dinawin.Erp.Infrastructure.Data;
using Dinawin.Erp.Infrastructure.Data.Entities.Crm;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Commands.CreateContact;

/// <summary>
/// پردازشگر دستور ایجاد مخاطب
/// </summary>
public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
{
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateContactCommandHandler(ApplicationDbContext context)
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
            FirstName = request.FirstName,
            LastName = request.LastName,
            CompanyName = request.CompanyName,
            JobTitle = request.JobTitle,
            PhoneNumber = request.PhoneNumber,
            MobileNumber = request.MobileNumber,
            Email = request.Email,
            Address = request.Address,
            City = request.City,
            State = request.State,
            PostalCode = request.PostalCode,
            Country = request.Country,
            BirthDate = request.BirthDate,
            Notes = request.Notes,
            CreatedByUserId = request.CreatedByUserId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}
