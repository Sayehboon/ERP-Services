using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Brands.Commands.DeleteBrand;

/// <summary>
/// دستور حذف برند
/// </summary>
public sealed class DeleteBrandCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه برند
    /// </summary>
    [Required(ErrorMessage = "شناسه برند الزامی است")]
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


