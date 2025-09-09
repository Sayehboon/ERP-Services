using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Uoms.Queries.GetUomById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
/// </summary>
public sealed class GetUomByIdQueryHandler : IRequestHandler<GetUomByIdQuery, UomDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
    /// </summary>
    public GetUomByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت واحد اندازه‌گیری بر اساس شناسه
    /// </summary>
    public async Task<UomDto?> Handle(GetUomByIdQuery request, CancellationToken cancellationToken)
    {
        var uom = await _context.UnitsOfMeasures
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        return uom != null ? _mapper.Map<UomDto>(uom) : null;
    }
}