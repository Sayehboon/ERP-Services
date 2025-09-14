using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.DeleteInventory;

/// <summary>
/// دستور حذف موجودی
/// </summary>
public sealed class DeleteInventoryCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه موجودی الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
