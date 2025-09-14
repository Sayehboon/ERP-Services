using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Treasury;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Commands.CreateCashBox;

/// <summary>
/// پردازشگر دستور ایجاد صندوق نقدی جدید
/// </summary>
public class CreateCashBoxCommandHandler : IRequestHandler<CreateCashBoxCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateCashBoxCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه صندوق نقدی ایجاد شده</returns>
    public async Task<Guid> Handle(CreateCashBoxCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن نام صندوق
        var existingCashBox = await _context.CashBoxes
            .FirstOrDefaultAsync(cb => cb.Name == request.Name, cancellationToken);

        if (existingCashBox != null)
        {
            throw new InvalidOperationException($"صندوق نقدی با نام {request.Name} قبلاً وجود دارد");
        }

        var cashBox = new CashBox
        {
            Id = Guid.NewGuid(),
            BusinessId = request.BusinessId, // Assuming this comes from the request or context
            Name = request.Name,
            Location = request.Location,
            ControlAccountId = request.ControlAccountId, // Assuming this comes from the request
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.CashBoxes.Add(cashBox);
        await _context.SaveChangesAsync(cancellationToken);

        return cashBox.Id;
    }
}
