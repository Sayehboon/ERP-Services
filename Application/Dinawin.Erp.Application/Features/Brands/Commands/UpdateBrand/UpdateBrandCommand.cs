using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Brands.Commands.UpdateBrand;

/// <summary>
/// دستور به‌روزرسانی برند
/// </summary>
public sealed class UpdateBrandCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه برند
    /// </summary>
    [Required(ErrorMessage = "شناسه برند الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام برند
    /// </summary>
    [Required(ErrorMessage = "نام برند الزامی است")]
    [StringLength(200, ErrorMessage = "نام برند نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات برند
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات برند نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت فعال بودن برند
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "ترتیب نمایش باید عددی مثبت باشد")]
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}


