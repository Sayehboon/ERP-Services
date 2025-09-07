using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Categories.Commands.DeleteCategory;

/// <summary>
/// دستور حذف دسته‌بندی
/// </summary>
public sealed class DeleteCategoryCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه دسته‌بندی
    /// </summary>
    [Required(ErrorMessage = "شناسه دسته‌بندی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف‌کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }

    /// <summary>
    /// دلیل حذف
    /// </summary>
    [StringLength(500)]
    public string? DeleteReason { get; set; }
}
