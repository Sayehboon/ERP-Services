using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.UpdateRole;

/// <summary>
/// دستور به‌روزرسانی نقش
/// </summary>
public sealed class UpdateRoleCommand : IRequest<Guid>
{
    /// <summary>
    /// شناسه نقش
    /// </summary>
    [Required(ErrorMessage = "شناسه نقش الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// نام نقش
    /// </summary>
    [Required(ErrorMessage = "نام نقش الزامی است")]
    [StringLength(100, ErrorMessage = "نام نقش نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات نقش
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نقش نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// آیا فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// مجوزهای نقش
    /// </summary>
    public List<string> Permissions { get; set; } = new();

    /// <summary>
    /// شناسه کاربر به‌روزرسانی کننده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
