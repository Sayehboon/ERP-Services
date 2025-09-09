using AutoMapper;
using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Brands.Queries.GetBrandById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت برند بر اساس شناسه
/// </summary>
public sealed class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت برند بر اساس شناسه
    /// </summary>
    public GetBrandByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<BrandDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
    {
        var brand = await _context.Brands
            .Include(b => b.Products)
            .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken);

        if (brand == null)
        {
            return null;
        }

        var dto = _mapper.Map<BrandDto>(brand);
        dto.ProductCount = brand.Products?.Count ?? 0;
        return dto;
    }
}


