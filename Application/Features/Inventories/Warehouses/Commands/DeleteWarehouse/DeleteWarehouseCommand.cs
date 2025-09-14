using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventories.Warehouses.Commands.DeleteWarehouse;

/// <summary>
/// دستور حذف انبار
/// </summary>
public sealed class DeleteWarehouseCommand : IRequest<bool>
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    [Required(ErrorMessage = "شناسه انبار الزامی است")]
    public Guid Id { get; set; }

    /// <summary>
    /// شناسه کاربر حذف کننده
    /// </summary>
    public Guid? DeletedBy { get; set; }
}
