using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Application.Features.Products.Commands.UpdateProduct;

/// <summary>
/// پردازش‌کننده فرمان ویرایش کالا
/// Update product command handler
/// </summary>
public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازش‌کننده فرمان ویرایش کالا
    /// Update product command handler constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش فرمان ویرایش کالا
    /// Handle update product command
    /// </summary>
    /// <param name="request">درخواست ویرایش کالا</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>نتیجه ویرایش</returns>
    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (product == null)
        {
            return false;
        }

        // بروزرسانی اطلاعات کالا
        // Update product information
        product.Sku = request.Sku;
        product.Name = request.Name;
        product.Description = request.Description;
        product.BrandId = request.BrandId;
        product.CategoryId = request.CategoryId;
        product.BaseUomId = request.BaseUomId;
        product.PurchasePrice = request.PriceBuy.HasValue ? Money.Rial(request.PriceBuy.Value) : null;
        product.SellingPrice = request.PriceSell.HasValue ? Money.Rial(request.PriceSell.Value) : null;
        product.MinStockLevel = request.MinStockLevel;
        product.MaxStockLevel = request.MaxStockLevel;
        product.ReorderPoint = request.ReorderPoint;
        product.IsActive = request.IsActive;

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
