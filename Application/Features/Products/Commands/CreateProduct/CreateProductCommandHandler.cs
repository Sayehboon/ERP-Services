using MediatR;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Products;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// پردازش‌کننده فرمان ایجاد کالای جدید
/// Create product command handler
/// </summary>
public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده فرمان ایجاد کالا
    /// Create product command handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش فرمان ایجاد کالا
    /// Handle create product command
    /// </summary>
    /// <param name="request">درخواست ایجاد کالا</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه کالای ایجاد شده</returns>
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Dinawin.Erp.Domain.Entities.Products.Product
        {
            Sku = request.Sku,
            Name = request.Name,
            Description = request.Description,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
            BaseUomId = request.BaseUomId,
            PurchasePrice = request.PriceBuy.HasValue ? Money.Rial(request.PriceBuy.Value) : null,
            SellingPrice = request.PriceSell.HasValue ? Money.Rial(request.PriceSell.Value) : null,
            MinStockLevel = request.MinStockLevel,
            MaxStockLevel = request.MaxStockLevel,
            ReorderPoint = request.ReorderPoint,
            IsActive = true
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return product.Id;
    }
}
