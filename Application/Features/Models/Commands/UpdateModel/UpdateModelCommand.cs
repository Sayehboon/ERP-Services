using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Models.Commands.UpdateModel;

/// <summary>
/// دستور به‌روزرسانی مدل
/// </summary>
public sealed class UpdateModelCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه مدل
    /// </summary>
    [Required(ErrorMessage = "شناسه مدل الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام مدل
    /// </summary>
    [Required(ErrorMessage = "نام مدل الزامی است")]
    [StringLength(200, ErrorMessage = "نام مدل نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات مدل
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات مدل نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string Description { get; set; }

    /// <summary>
    /// شناسه برند
    /// </summary>
    public Guid? BrandId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن مدل
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
