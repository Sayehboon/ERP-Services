using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.SystemManagement.Users.Commands.ToggleUserStatus;

/// <summary>
/// دستور تغییر وضعیت فعال/غیرفعال کاربر
/// </summary>
public sealed class ToggleUserStatusCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه کاربر
    /// </summary>
    [Required(ErrorMessage = "شناسه کاربر الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// وضعیت جدید (true = فعال، false = غیرفعال)
    /// </summary>
    [Required(ErrorMessage = "وضعیت جدید الزامی است")]
    public bool IsActive { get; set; }

    /// <summary>
    /// دلیل تغییر وضعیت
    /// </summary>
    [StringLength(500, ErrorMessage = "دلیل تغییر وضعیت نمی‌تواند بیش از 500 کاراکتر باشد")]
    public string Reason { get; set; }

    /// <summary>
    /// شناسه کاربر انجام دهنده
    /// </summary>
    public Guid? UpdatedBy { get; set; }
}
