using Dinawin.Erp.Application.Common.Interfaces;
// using Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetAllCashBoxes;

/// <summary>
/// پردازشگر درخواست دریافت تمام صندوق‌های نقدی
/// </summary>
public class GetAllCashBoxesQueryHandler : IRequestHandler<GetAllCashBoxesQuery, IEnumerable<CashBoxDto>>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public GetAllCashBoxesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش درخواست
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>لیست صندوق‌های نقدی</returns>
    public async Task<IEnumerable<CashBoxDto>> Handle(GetAllCashBoxesQuery request, CancellationToken cancellationToken)
    {
        var query = _context.CashBoxes.AsQueryable();

        // جستجو در نام و کد صندوق
        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(cb => 
                cb.Name.ToLower().Contains(searchTerm) ||
                (cb.Location != null && cb.Location.ToLower().Contains(searchTerm)));
        }

        // Note: ResponsiblePersonId and IsActive properties were removed from CashBox entity

        var cashBoxes = await query
            .Select(cb => new CashBoxDto
            {
                Id = cb.Id,
                Name = cb.Name,
                Code = string.Empty, // Code property does not exist in CashBox entity
                Location = cb.Location,
                ResponsiblePersonId = null, // ResponsiblePersonId property does not exist in CashBox entity
                ResponsiblePersonName = null, // ResponsiblePerson property does not exist in CashBox entity
                CurrentBalance = 0, // CurrentBalance property does not exist in CashBox entity
                Currency = "IRR", // Currency property does not exist in CashBox entity
                IsActive = cb.IsActive,
                CreatedAt = cb.CreatedAt,
                UpdatedAt = cb.UpdatedAt
            })
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return cashBoxes;
    }
}
