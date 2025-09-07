using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.CRM.Leads.Commands.CreateLead;

/// <summary>
/// مدیریت‌کننده دستور ایجاد لید
/// </summary>
public sealed class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد لید
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateLeadCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد لید
    /// </summary>
    public async Task<Guid> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن ایمیل
        if (!string.IsNullOrWhiteSpace(request.Email))
        {
            var duplicateEmail = await _context.Leads
                .AnyAsync(l => l.Email == request.Email, cancellationToken);
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

        var lead = new Lead
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            CompanyName = request.CompanyName,
            Email = request.Email,
            Phone = request.Phone,
            Mobile = request.Mobile,
            Address = request.Address,
            City = request.City,
            Province = request.Province,
            PostalCode = request.PostalCode,
            LeadSource = request.LeadSource,
            Status = request.Status,
            Priority = request.Priority,
            EstimatedValue = request.EstimatedValue,
            ExpectedCloseDate = request.ExpectedCloseDate,
            AssignedToId = request.AssignedToId,
            Notes = request.Notes,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync(cancellationToken);
        return lead.Id;
    }
}
