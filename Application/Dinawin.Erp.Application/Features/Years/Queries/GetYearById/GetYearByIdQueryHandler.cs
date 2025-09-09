using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Years.Queries.GetYearById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت سال بر اساس شناسه
/// </summary>
public sealed class GetYearByIdQueryHandler : IRequestHandler<GetYearByIdQuery, YearDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت سال بر اساس شناسه
    /// </summary>
    public GetYearByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<YearDto?> Handle(GetYearByIdQuery request, CancellationToken cancellationToken)
    {
        var year = await _context.Years
            .FirstOrDefaultAsync(y => y.Id == request.Id, cancellationToken);

        if (year == null)
        {
            return null;
        }

        var dto = _mapper.Map<YearDto>(year);
        dto.ProductCount = 0;
        return dto;
    }
}
