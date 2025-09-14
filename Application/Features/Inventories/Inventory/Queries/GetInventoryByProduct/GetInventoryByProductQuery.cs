using MediatR;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryByProduct;

/// <summary>
/// پرس‌وجو دریافت موجودی محصول
/// </summary>
public sealed class GetInventoryByProductQuery : IRequest<ProductInventoryDto>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public required Guid ProductId { get; init; }

    /// <summary>
    /// شناسه انبار (اختیاری)
    /// </summary>
    public Guid? WarehouseId { get; init; }
}
