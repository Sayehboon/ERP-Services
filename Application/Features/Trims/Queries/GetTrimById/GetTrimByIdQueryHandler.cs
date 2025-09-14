using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Trims.Queries.GetTrimById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت تریم بر اساس شناسه
/// </summary>
public sealed class GetTrimByIdQueryHandler : IRequestHandler<GetTrimByIdQuery, TrimDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت تریم بر اساس شناسه
    /// </summary>
    public GetTrimByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<TrimDto> Handle(GetTrimByIdQuery request, CancellationToken cancellationToken)
    {
        var trim = await _context.Trims
            .Include(t => t.Model)
            .Include(t => t.Products)
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (trim == null)
        {
            return null;
        }

        var dto = _mapper.Map<TrimDto>(trim);
        dto.ModelName = trim.Model?.Name;
        dto.ProductCount = trim.Products?.Count ?? 0;
        return dto;
    }
}
