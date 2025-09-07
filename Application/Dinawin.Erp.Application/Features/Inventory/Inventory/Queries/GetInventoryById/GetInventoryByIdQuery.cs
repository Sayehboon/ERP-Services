using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventory.Inventory.Queries.GetInventoryById;

/// <summary>
/// پرس‌وجو دریافت موجودی بر اساس شناسه
/// </summary>
public sealed class GetInventoryByIdQuery : IRequest<InventoryDto?>
{
    /// <summary>
    /// شناسه موجودی
    /// </summary>
    [Required(ErrorMessage = "شناسه موجودی الزامی است")]
    public Guid Id { get; set; }
}
