using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.InventoryMovements.Commands.DeleteInventoryMovement;

/// <summary>
/// دستور حذف حرکت موجودی
/// </summary>
public sealed class DeleteInventoryMovementCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه حرکت موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه حرکت موجودی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
