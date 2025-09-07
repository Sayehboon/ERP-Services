using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Product.Products.Commands.DeleteProduct;

/// <summary>
/// دستور حذف محصول
/// </summary>
public sealed class DeleteProductCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه محصول
    /// </summary>
    [Required(ErrorMessage = "شناسه محصول الزامی است")]
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