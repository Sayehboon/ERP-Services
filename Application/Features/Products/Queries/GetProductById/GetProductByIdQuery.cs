using MediatR;
using Dinawin.Erp.Application.Features.Products.Queries.Dtos;

namespace Dinawin.Erp.Application.Features.Products.Queries.GetProductById;

/// <summary>
/// پرس‌وجو دریافت کالا با شناسه
/// Query for getting product by ID
/// </summary>
public record GetProductByIdQuery : IRequest<ProductDto>
{
    /// <summary>
    /// شناسه کالا
    /// Product ID
    /// </summary>
    public required Guid Id { get; init; }
}
