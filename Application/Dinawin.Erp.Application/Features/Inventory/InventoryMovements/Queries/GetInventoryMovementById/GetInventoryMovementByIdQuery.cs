using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Queries.GetInventoryMovementById;

/// <summary>
/// پرس‌وجو دریافت حرکت موجودی بر اساس شناسه
/// </summary>
public sealed class GetInventoryMovementByIdQuery : IRequest<InventoryMovementDto?>
{
    /// <summary>
    /// شناسه حرکت موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه حرکت موجودی الزامی است")]
    public Guid Id { get; set; }
}
