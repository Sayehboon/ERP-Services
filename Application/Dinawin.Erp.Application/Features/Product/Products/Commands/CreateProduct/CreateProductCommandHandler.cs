using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities;

namespace Dinawin.Erp.Application.Features.Product.Products.Commands.CreateProduct;

/// <summary>
/// مدیریت‌کننده دستور ایجاد محصول
/// </summary>
public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور ایجاد محصول
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور ایجاد محصول
    /// </summary>
    public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // بررسی یکتایی کد محصول
        var codeExists = await _context.Products
            .AnyAsync(p => p.Code == request.Code, cancellationToken);
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
            var uomExists = await _context.Uoms
                .AnyAsync(u => u.Id == request.UomId.Value, cancellationToken);
            if (!uomExists)
            {
                throw new ArgumentException($"UOM با شناسه {request.UomId} یافت نشد");
            }
        }

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Code = request.Code,
            BrandId = request.BrandId,
            CategoryId = request.CategoryId,
            ModelId = request.ModelId,
            TrimId = request.TrimId,
            YearId = request.YearId,
            UnitId = request.UnitId,
            UomId = request.UomId,
            Description = request.Description,
            PurchasePrice = request.PurchasePrice,
            SalePrice = request.SalePrice,
            WholesalePrice = request.WholesalePrice,
            MinStock = request.MinStock,
            MaxStock = request.MaxStock,
            CurrentStock = request.CurrentStock,
            Weight = request.Weight,
            Dimensions = request.Dimensions,
            Color = request.Color,
            ProductType = request.ProductType,
            Status = request.Status,
            IsSellable = request.IsSellable,
            IsPurchasable = request.IsPurchasable,
            IsManufacturable = request.IsManufacturable,
            CreatedBy = request.CreatedBy,
            CreatedAt = DateTime.UtcNow
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}