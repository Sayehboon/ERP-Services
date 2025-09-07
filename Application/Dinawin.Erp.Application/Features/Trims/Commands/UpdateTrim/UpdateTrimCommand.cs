using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Trims.Commands.UpdateTrim;

/// <summary>
/// دستور به‌روزرسانی تریم
/// </summary>
public sealed class UpdateTrimCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه تریم
    /// </summary>
    [Required(ErrorMessage = "شناسه تریم الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام تریم
    /// </summary>
    [Required(ErrorMessage = "نام تریم الزامی است")]
    [StringLength(200, ErrorMessage = "نام تریم نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات تریم
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات تریم نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه مدل
    /// </summary>
    public Guid? ModelId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن تریم
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
