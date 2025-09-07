using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Years.Commands.CreateYear;

/// <summary>
/// دستور ایجاد سال
/// </summary>
public sealed class CreateYearCommand : IRequest<Guid>
{
    /// <summary>
    /// سال
    /// </summary>
    [Required(ErrorMessage = "سال الزامی است")]
    [Range(1900, 2100, ErrorMessage = "سال باید بین 1900 تا 2100 باشد")]
    public int Year { get; set; }

    /// <summary>
    /// توضیحات سال
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات سال نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// وضعیت فعال بودن سال
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// ترتیب نمایش
    /// </summary>
    [Range(0, int.MaxValue, ErrorMessage = "ترتیب نمایش باید عددی مثبت باشد")]
    public int SortOrder { get; set; } = 0;

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
