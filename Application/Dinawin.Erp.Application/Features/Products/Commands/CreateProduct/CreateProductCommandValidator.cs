using FluentValidation;
using Dinawin.Erp.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.Products.Commands.CreateProduct;

/// <summary>
/// اعتبارسنج فرمان ایجاد کالای جدید
/// Create product command validator
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده اعتبارسنج فرمان ایجاد کالا
    /// Create product command validator constructor
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public CreateProductCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(x => x.Sku)
            .NotEmpty().WithMessage("کد SKU الزامی است")
            .MaximumLength(50).WithMessage("کد SKU نباید بیش از 50 کاراکتر باشد")
            .MustAsync(BeUniqueSku).WithMessage("کد SKU باید یکتا باشد");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("نام کالا الزامی است")
            .MaximumLength(200).WithMessage("نام کالا نباید بیش از 200 کاراکتر باشد");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("توضیحات نباید بیش از 1000 کاراکتر باشد");

        RuleFor(x => x.PriceBuy)
            .GreaterThanOrEqualTo(0).WithMessage("قیمت خرید نمی‌تواند منفی باشد")
            .When(x => x.PriceBuy.HasValue);

        RuleFor(x => x.PriceSell)
            .GreaterThanOrEqualTo(0).WithMessage("قیمت فروش نمی‌تواند منفی باشد")
            .When(x => x.PriceSell.HasValue);

        RuleFor(x => x.MinStockLevel)
            .GreaterThanOrEqualTo(0).WithMessage("حداقل موجودی نمی‌تواند منفی باشد");

        RuleFor(x => x.MaxStockLevel)
            .GreaterThanOrEqualTo(0).WithMessage("حداکثر موجودی نمی‌تواند منفی باشد")
            .GreaterThan(x => x.MinStockLevel).WithMessage("حداکثر موجودی باید بیشتر از حداقل موجودی باشد")
            .When(x => x.MaxStockLevel > 0);

        RuleFor(x => x.ReorderPoint)
            .GreaterThanOrEqualTo(0).WithMessage("نقطه سفارش مجدد نمی‌تواند منفی باشد");

        RuleFor(x => x.BrandId)
            .MustAsync(BeValidBrand).WithMessage("برند انتخاب شده معتبر نیست")
            .When(x => x.BrandId.HasValue);

        RuleFor(x => x.CategoryId)
            .MustAsync(BeValidCategory).WithMessage("دسته‌بندی انتخاب شده معتبر نیست")
            .When(x => x.CategoryId.HasValue);

        RuleFor(x => x.BaseUomId)
            .MustAsync(BeValidUom).WithMessage("واحد اندازه‌گیری انتخاب شده معتبر نیست")
            .When(x => x.BaseUomId.HasValue);
    }

    /// <summary>
    /// بررسی یکتا بودن کد SKU
    /// Check SKU uniqueness
    /// </summary>
    private async Task<bool> BeUniqueSku(string sku, CancellationToken cancellationToken)
    {
        return !await _context.Products
            .AnyAsync(p => p.Sku == sku && !p.IsDeleted, cancellationToken);
    }

    /// <summary>
    /// بررسی معتبر بودن برند
    /// Check brand validity
    /// </summary>
    private async Task<bool> BeValidBrand(Guid? brandId, CancellationToken cancellationToken)
    {
        if (!brandId.HasValue) return true;

        return await _context.Brands
            .AnyAsync(b => b.Id == brandId.Value && b.IsActive && !b.IsDeleted, cancellationToken);
    }

    /// <summary>
    /// بررسی معتبر بودن دسته‌بندی
    /// Check category validity
    /// </summary>
    private async Task<bool> BeValidCategory(Guid? categoryId, CancellationToken cancellationToken)
    {
        if (!categoryId.HasValue) return true;

        return await _context.Categories
            .AnyAsync(c => c.Id == categoryId.Value && c.IsActive && !c.IsDeleted, cancellationToken);
    }

    /// <summary>
    /// بررسی معتبر بودن واحد اندازه‌گیری
    /// Check unit of measure validity
    /// </summary>
    private async Task<bool> BeValidUom(Guid? uomId, CancellationToken cancellationToken)
    {
        if (!uomId.HasValue) return true;

        return await _context.UnitsOfMeasure
            .AnyAsync(u => u.Id == uomId.Value && u.IsActive && !u.IsDeleted, cancellationToken);
    }
}
