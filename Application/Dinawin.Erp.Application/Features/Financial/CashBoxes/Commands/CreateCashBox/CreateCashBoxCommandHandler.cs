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
        // بررسی تکراری نبودن کد صندوق
        var existingCashBox = await _context.CashBoxes
            .FirstOrDefaultAsync(cb => cb.Code == request.Code, cancellationToken);

        if (existingCashBox != null)
        {
            throw new InvalidOperationException($"صندوق نقدی با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی وجود مسئول صندوق
        if (request.ResponsiblePersonId.HasValue)
        {
            var personExists = await _context.Employees
                .AnyAsync(e => e.Id == request.ResponsiblePersonId.Value, cancellationToken);

            if (!personExists)
            {
                throw new InvalidOperationException($"کارمند با شناسه {request.ResponsiblePersonId} یافت نشد");
            }
        }

        var cashBox = new CashBox
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            Location = request.Location,
            ResponsiblePersonId = request.ResponsiblePersonId,
            CurrentBalance = request.InitialBalance,
            Currency = request.Currency,
            IsActive = request.IsActive,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.CashBoxes.Add(cashBox);
        await _context.SaveChangesAsync(cancellationToken);

        return cashBox.Id;
    }
}
