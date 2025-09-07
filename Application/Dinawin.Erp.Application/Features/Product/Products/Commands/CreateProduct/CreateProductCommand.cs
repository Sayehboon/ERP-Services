using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Product.Products.Commands.CreateProduct;

/// <summary>
/// دستور ایجاد محصول
/// </summary>
public sealed class CreateProductCommand : IRequest<Guid>
{
    /// <summary>
    /// نام محصول
    /// </summary>
    [Required(ErrorMessage = "نام محصول الزامی است")]
    [StringLength(200, ErrorMessage = "نام محصول نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد محصول
    /// </summary>
    [Required(ErrorMessage = "کد محصول الزامی است")]
    [StringLength(50, ErrorMessage = "کد محصول نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// شناسه برند
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    public Guid? CategoryId { get; set; }

    /// <summary>
    /// شناسه مدل
    /// </summary>
    public Guid? ModelId { get; set; }

    /// <summary>
    /// شناسه تریم
    /// </summary>
    public Guid? TrimId { get; set; }

    /// <summary>
    /// شناسه سال
    /// </summary>
    public Guid? YearId { get; set; }

    /// <summary>
    /// شناسه واحد
    /// </summary>
    public Guid? UnitId { get; set; }

    /// <summary>
    /// شناسه UOM
    /// </summary>
    public Guid? UomId { get; set; }

    /// <summary>
    /// توضیحات محصول
    /// </summary>
    [StringLength(2000, ErrorMessage = "توضیحات محصول نمی‌تواند بیش از 2000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// قیمت خرید
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت خرید باید مثبت باشد")]
    public decimal PurchasePrice { get; set; }

    /// <summary>
    /// قیمت فروش
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت فروش باید مثبت باشد")]
    public decimal SalePrice { get; set; }

    /// <summary>
    /// قیمت عمده‌فروشی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "قیمت عمده‌فروشی باید مثبت باشد")]
    public decimal WholesalePrice { get; set; }

    /// <summary>
    /// حداقل موجودی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "حداقل موجودی باید مثبت باشد")]
    public decimal MinStock { get; set; }

    /// <summary>
    /// حداکثر موجودی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "حداکثر موجودی باید مثبت باشد")]
    public decimal MaxStock { get; set; }

    /// <summary>
    /// موجودی فعلی
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "موجودی فعلی باید مثبت باشد")]
    public decimal CurrentStock { get; set; }

    /// <summary>
    /// وزن محصول
    /// </summary>
    [Range(0, double.MaxValue, ErrorMessage = "وزن محصول باید مثبت باشد")]
    public decimal? Weight { get; set; }

    /// <summary>
    /// ابعاد محصول
    /// </summary>
    [StringLength(100, ErrorMessage = "ابعاد محصول نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string? Dimensions { get; set; }

    /// <summary>
    /// رنگ محصول
    /// </summary>
    [StringLength(50, ErrorMessage = "رنگ محصول نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? Color { get; set; }

    /// <summary>
    /// نوع محصول
    /// </summary>
    [StringLength(50, ErrorMessage = "نوع محصول نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string? ProductType { get; set; }

    /// <summary>
    /// وضعیت محصول
    /// </summary>
    [StringLength(20, ErrorMessage = "وضعیت محصول نمی‌تواند بیش از 20 کاراکتر باشد")]
    public string Status { get; set; } = "Active";

    /// <summary>
    /// آیا قابل فروش است
    /// </summary>
    public bool IsSellable { get; set; } = true;

    /// <summary>
    /// آیا قابل خرید است
    /// </summary>
    public bool IsPurchasable { get; set; } = true;

    /// <summary>
    /// آیا قابل تولید است
    /// </summary>
    public bool IsManufacturable { get; set; } = false;

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}