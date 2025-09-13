using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.Product.Products.Queries.GetProductById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت محصول بر اساس شناسه
/// </summary>
public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت محصول بر اساس شناسه
    /// </summary>
    public GetProductByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// اجرای پرس‌وجو
    /// </summary>
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Model)
            .Include(p => p.Trim)
            .Include(p => p.Year)
            .Include(p => p.Unit)
            // .Include(p => p.Uom) // Uom is an alias for BaseUom, already included above
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return null;
        }

        var dto = _mapper.Map<ProductDto>(product);
        dto.BrandName = product.Brand?.Name;
        dto.CategoryName = product.Category?.Name;
        dto.ModelName = product.Model?.Name;
        dto.TrimName = product.Trim?.Name;
        dto.Year = product.Year?.YearValue;
        dto.UnitName = product.Unit?.Name;
        dto.UomName = product.Unit?.Name;
        return dto;
    }
}