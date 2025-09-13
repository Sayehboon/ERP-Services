using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.ValueObjects;

namespace Dinawin.Erp.Application.Features.Product.Products.Commands.UpdateProduct;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی محصول
/// </summary>
public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی محصول
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی محصول
    /// </summary>
    public async Task<Guid> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);
        if (product == null)
        {
            throw new ArgumentException($"محصول با شناسه {request.Id} یافت نشد");
        }

        // بررسی یکتایی کد محصول (به جز خود محصول)
        var codeExists = await _context.Products
            .AnyAsync(p => p.Code == request.Code && p.Id != request.Id, cancellationToken);
        if (codeExists)
        {
            throw new ArgumentException($"محصول با کد {request.Code} قبلاً وجود دارد");
        }

        // بررسی وجود برند
        if (request.BrandId.HasValue)
        {
            var brandExists = await _context.Brands
                .AnyAsync(b => b.Id == request.BrandId.Value, cancellationToken);
            if (!brandExists)
            {
                throw new ArgumentException($"برند با شناسه {request.BrandId} یافت نشد");
            }
        }

        // بررسی وجود دسته‌بندی
        if (request.CategoryId.HasValue)
        {
            var categoryExists = await _context.Categories
                .AnyAsync(c => c.Id == request.CategoryId.Value, cancellationToken);
            if (!categoryExists)
            {
                throw new ArgumentException($"دسته‌بندی با شناسه {request.CategoryId} یافت نشد");
            }
        }

        // بررسی وجود مدل
        if (request.ModelId.HasValue)
        {
            var modelExists = await _context.Models
                .AnyAsync(m => m.Id == request.ModelId.Value, cancellationToken);
            if (!modelExists)
            {
                throw new ArgumentException($"مدل با شناسه {request.ModelId} یافت نشد");
            }
        }

        // بررسی وجود تریم
        if (request.TrimId.HasValue)
        {
            var trimExists = await _context.Trims
                .AnyAsync(t => t.Id == request.TrimId.Value, cancellationToken);
            if (!trimExists)
            {
                throw new ArgumentException($"تریم با شناسه {request.TrimId} یافت نشد");
            }
        }

        // بررسی وجود سال
        if (request.YearId.HasValue)
        {
            var yearExists = await _context.Years
                .AnyAsync(y => y.Id == request.YearId.Value, cancellationToken);
            if (!yearExists)
            {
                throw new ArgumentException($"سال با شناسه {request.YearId} یافت نشد");
            }
        }

        // بررسی وجود واحد
        if (request.UnitId.HasValue)
        {
            var unitExists = await _context.Units
                .AnyAsync(u => u.Id == request.UnitId.Value, cancellationToken);
            if (!unitExists)
            {
                throw new ArgumentException($"واحد با شناسه {request.UnitId} یافت نشد");
            }
        }

        // بررسی وجود UOM
        if (request.UomId.HasValue)
        {
            var uomExists = await _context.UnitsOfMeasures
                .AnyAsync(u => u.Id == request.UomId.Value, cancellationToken);
            if (!uomExists)
            {
                throw new ArgumentException($"UOM با شناسه {request.UomId} یافت نشد");
            }
        }

        product.Name = request.Name;
        product.Code = request.Code;
        product.BrandId = request.BrandId;
        product.CategoryId = request.CategoryId;
        product.ModelId = request.ModelId;
        product.TrimId = request.TrimId;
        product.YearId = request.YearId;
        product.UnitId = request.UnitId;
        product.UomId = request.UomId;
        product.Description = request.Description;
        product.PurchasePrice = request.PurchasePrice > 0 ? Money.Rial(request.PurchasePrice) : null;
        product.SellingPrice = request.SalePrice > 0 ? Money.Rial(request.SalePrice) : null;
        product.WholesalePrice = request.WholesalePrice > 0 ? request.WholesalePrice : 0;
        product.MinStock = request.MinStock;
        product.MaxStock = request.MaxStock;
        product.CurrentStock = request.CurrentStock;
        product.Weight = request.Weight.HasValue ? Weight.Kilograms(request.Weight.Value) : null;
        product.Dimensions = !string.IsNullOrEmpty(request.Dimensions) ? Dimensions.Centimeters(0, 0, 0) : null; // TODO: Parse dimensions string
        product.Color = request.Color;
        product.ProductType = request.ProductType;
        product.Status = request.Status;
        product.IsSellable = request.IsSellable;
        product.IsPurchasable = request.IsPurchasable;
        product.IsManufacturable = request.IsManufacturable;
        product.UpdatedBy = request.UpdatedBy;
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}