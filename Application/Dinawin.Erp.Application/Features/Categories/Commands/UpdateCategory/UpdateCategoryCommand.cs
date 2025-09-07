using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Categories.Commands.UpdateCategory;

/// <summary>
/// دستور به‌روزرسانی دسته‌بندی
/// </summary>
public sealed class UpdateCategoryCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    [Required(ErrorMessage = "شناسه دسته‌بندی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام دسته‌بندی
    /// </summary>
    [Required(ErrorMessage = "نام دسته‌بندی الزامی است")]
    [StringLength(200, ErrorMessage = "نام دسته‌بندی نمی‌تواند بیش از 200 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات دسته‌بندی
    /// </summary>
    [StringLength(1000, ErrorMessage = "توضیحات دسته‌بندی نمی‌تواند بیش از 1000 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// شناسه دسته‌بندی والد
    /// </summary>
    public Guid? ParentCategoryId { get; set; }

    /// <summary>
    /// وضعیت فعال بودن دسته‌بندی
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
