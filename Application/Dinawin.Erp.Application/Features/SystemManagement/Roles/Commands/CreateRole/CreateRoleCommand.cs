using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Roles.Commands.CreateRole;

/// <summary>
/// دستور ایجاد نقش جدید
/// </summary>
public sealed class CreateRoleCommand : IRequest<Guid>
{
    /// <summary>
    /// نام نقش
    /// </summary>
    [Required(ErrorMessage = "نام نقش الزامی است")]
    [StringLength(100, ErrorMessage = "نام نقش نمی‌تواند بیش از 100 کاراکتر باشد")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// کد نقش
    /// </summary>
    [Required(ErrorMessage = "کد نقش الزامی است")]
    [StringLength(50, ErrorMessage = "کد نقش نمی‌تواند بیش از 50 کاراکتر باشد")]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// توضیحات نقش
    /// </summary>
    [StringLength(500, ErrorMessage = "توضیحات نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string? Description { get; set; }

    /// <summary>
    /// آیا نقش فعال است
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// آیا نقش سیستمی است
    /// </summary>
    public bool IsSystem { get; set; } = false;

    /// <summary>
    /// شناسه کاربر ایجاد کننده
    /// </summary>
    public Guid? CreatedBy { get; set; }
}
