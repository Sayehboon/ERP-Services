using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Models.Queries.GetModelById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت مدل بر اساس شناسه
/// </summary>
public sealed class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, ModelDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت مدل بر اساس شناسه
    /// </summary>
    public GetModelByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<ModelDto?> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
    {
        var model = await _context.Models
            .Include(m => m.Brand)
            .Include(m => m.Products)
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (model == null)
        {
            return null;
        }

        var dto = _mapper.Map<ModelDto>(model);
        dto.BrandName = model.Brand?.Name;
        dto.ProductCount = model.Products?.Count ?? 0;
        return dto;
    }
}
