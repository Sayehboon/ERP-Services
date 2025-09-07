using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetWarehouseById;

/// <summary>
/// پرس‌وجو دریافت انبار بر اساس شناسه
/// </summary>
public sealed class GetWarehouseByIdQuery : IRequest<WarehouseDto?>
{
    /// <summary>
    /// شناسه انبار
    /// </summary>
    [Required(ErrorMessage = "شناسه انبار الزامی است")]
    public Guid Id { get; set; }
}
