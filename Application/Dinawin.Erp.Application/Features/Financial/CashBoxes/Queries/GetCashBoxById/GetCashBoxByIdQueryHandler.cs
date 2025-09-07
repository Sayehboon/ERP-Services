using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxById;

/// <summary>
/// پردازشگر درخواست دریافت صندوق نقدی بر اساس شناسه
/// </summary>
public class GetCashBoxByIdQueryHandler : IRequestHandler<GetCashBoxByIdQuery, CashBoxDto?>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetCashBoxByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>اطلاعات صندوق نقدی</returns>
    public async Task<CashBoxDto?> Handle(GetCashBoxByIdQuery request, CancellationToken cancellationToken)
    {
        var cashBox = await _context.CashBoxes
            .Where(cb => cb.Id == request.Id)
            .Select(cb => new CashBoxDto
            {
                Id = cb.Id,
                Name = cb.Name,
                Code = cb.Code,
                Location = cb.Location,
                ResponsiblePersonId = cb.ResponsiblePersonId,
                ResponsiblePersonName = cb.ResponsiblePerson != null ? 
                    $"{cb.ResponsiblePerson.FirstName} {cb.ResponsiblePerson.LastName}" : null,
                CurrentBalance = cb.CurrentBalance,
                Currency = cb.Currency,
                IsActive = cb.IsActive,
                CreatedAt = cb.CreatedAt,
                UpdatedAt = cb.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

        return cashBox;
    }
}
