using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Contacts.Commands.UpdateContact;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی مخاطب
/// </summary>
public sealed class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی مخاطب
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateContactCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی مخاطب
    /// </summary>
    public async Task<Guid> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        if (contact == null)
        {
            throw new ArgumentException($"مخاطب با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی ایمیل (اگر مشخص شده باشد)
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var emailExists = await _context.Contacts
                .AnyAsync(c => c.Email == request.Email && c.Id != request.Id, cancellationToken);
            if (emailExists)
            {
                throw new ArgumentException($"ایمیل {request.Email} قبلاً استفاده شده است");
            }
        }

        // به‌روزرسانی اطلاعات مخاطب
        contact.Name = request.Name;
        contact.LastName = request.LastName;
        contact.CompanyName = request.CompanyName;
        contact.Position = request.Position;
        contact.Phone = request.Phone;
        contact.Mobile = request.Mobile;
        contact.Email = request.Email;
        contact.Address = request.Address;
        contact.City = request.City;
        contact.Province = request.Province;
        contact.PostalCode = request.PostalCode;
        contact.Country = request.Country;
        contact.BirthDate = request.BirthDate;
        contact.Description = request.Description;
        contact.ContactType = request.ContactType;
        contact.IsActive = request.IsActive;
        contact.UpdatedBy = request.UpdatedBy;
        contact.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return contact.Id;
    }
}
