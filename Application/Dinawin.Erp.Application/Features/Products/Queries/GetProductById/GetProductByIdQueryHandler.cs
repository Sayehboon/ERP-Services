using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Products.Queries.GetProductById;

/// <summary>
/// پردازش‌کننده پرس‌وجو دریافت کالا با شناسه
/// Get product by ID query handler
/// </summary>
public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    /// <summary>
    /// سازنده پردازش‌کننده پرس‌وجو دریافت کالا
    /// Get product by ID query handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    /// <param name="mapper">نگاشت‌کننده</param>
    public GetProductByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// پردازش پرس‌وجو دریافت کالا با شناسه
    /// Handle get product by ID query
    /// </summary>
    /// <param name="request">درخواست دریافت کالا</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>اطلاعات کالا</returns>
    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.BaseUom)
            .Include(p => p.Inventories)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        return product == null ? null : _mapper.Map<ProductDto>(product);
    }
}
