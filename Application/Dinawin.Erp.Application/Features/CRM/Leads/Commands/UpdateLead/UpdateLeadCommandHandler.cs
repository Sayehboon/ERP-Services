using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Commands.UpdateLead;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی لید
/// </summary>
public sealed class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی لید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateLeadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی لید
    /// </summary>
    public async Task<Guid> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FirstOrDefaultAsync(l => l.Id == request.Id, cancellationToken);
        if (lead == null)
        {
            throw new ArgumentException($"لید با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن ایمیل
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var duplicateEmail = await _context.Leads
                .AnyAsync(l => l.Email == request.Email && l.Id != request.Id, cancellationToken);
            if (duplicateEmail)
            {
                throw new InvalidOperationException($"لیدی با ایمیل {request.Email} قبلاً وجود دارد");
            }
        }

        // بررسی وجود کاربر مسئول
        if (request.AssignedToId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToId.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.AssignedToId} یافت نشد");
            }
        }

        lead.Name = request.Name;
        lead.CompanyName = request.CompanyName;
        lead.Email = request.Email;
        lead.Phone = request.Phone;
        lead.Mobile = request.Mobile;
        lead.Address = request.Address;
        lead.City = request.City;
        lead.Province = request.Province;
        lead.PostalCode = request.PostalCode;
        lead.LeadSource = request.LeadSource;
        lead.Status = request.Status;
        lead.Priority = request.Priority;
        lead.EstimatedValue = request.EstimatedValue;
        lead.ExpectedCloseDate = request.ExpectedCloseDate;
        lead.AssignedToId = request.AssignedToId;
        lead.Notes = request.Notes;
        lead.UpdatedBy = request.UpdatedBy;
        lead.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return lead.Id;
    }
}
