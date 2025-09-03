using Dinawin.Erp.Application.Features.Inventory.Queries.GetInventoryOverview;
using Dinawin.Erp.Application.Features.Inventory.Queries.Dtos;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetWarehouses;
using Dinawin.Erp.Application.Features.Inventory.Commands.UpdateStockAlert;
using Dinawin.Erp.Application.Features.Inventory.Movements.Queries.GetInventoryMovements;
using Dinawin.Erp.Application.Features.Inventory.Movements.Commands.CreateInventoryMovement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کنترلر مدیریت موجودی
/// Controller for managing inventory
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class InventoryController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// سازنده کنترلر موجودی
    /// Inventory controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public InventoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// دریافت نمای کلی موجودی
    /// Gets inventory overview with optional filtering
    /// </summary>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="productId">شناسه کالا</param>
    /// <param name="lowStockOnly">فقط موجودی‌های کم</param>
    /// <param name="reorderOnly">فقط موجودی‌های نیازمند سفارش مجدد</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست موجودی‌ها</returns>
    /// <response code="200">نمای کلی موجودی با موفقیت بازگردانده شد</response>
    [HttpGet("overview")]
    [ProducesResponseType(typeof(IEnumerable<InventoryDto>), 200)]
    public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventoryOverview(
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] Guid? productId = null,
        [FromQuery] bool? lowStockOnly = null,
        [FromQuery] bool? reorderOnly = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetInventoryOverviewQuery
        {
            WarehouseId = warehouseId,
            ProductId = productId,
            LowStockOnly = lowStockOnly,
            ReorderOnly = reorderOnly,
            Page = page,
            PageSize = pageSize
        };

        var inventory = await _mediator.Send(query);
        return Ok(inventory);
    }

    /// <summary>
    /// دریافت لیست انبارها
    /// Gets list of warehouses
    /// </summary>
    /// <returns>لیست انبارها</returns>
    /// <response code="200">لیست انبارها با موفقیت بازگردانده شد</response>
    [HttpGet("warehouses")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseDto>), 200)]
    public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetWarehouses()
    {
        var warehouses = await _mediator.Send(new GetWarehousesQuery());
        return Ok(warehouses);
    }

    /// <summary>
    /// بروزرسانی حداقل موجودی هشدار
    /// Updates minimum stock alert level
    /// </summary>
    /// <param name="inventoryId">شناسه موجودی</param>
    /// <param name="minStockAlert">حداقل موجودی جدید</param>
    /// <returns>نتیجه بروزرسانی</returns>
    /// <response code="200">حداقل موجودی با موفقیت بروزرسانی شد</response>
    /// <response code="404">موجودی پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("stock-alert/{inventoryId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateStockAlert(Guid inventoryId, [FromBody] decimal minStockAlert)
    {
        try
        {
            var ok = await _mediator.Send(new UpdateStockAlertCommand(inventoryId, minStockAlert));
            if (!ok) return NotFound();
            return Ok(new { message = "حداقل موجودی با موفقیت بروزرسانی شد" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در بروزرسانی حداقل موجودی", error = ex.Message });
        }
    }

    /// <summary>
    /// دریافت حرکات موجودی
    /// Gets inventory movements
    /// </summary>
    /// <param name="productId">شناسه کالا</param>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست حرکات موجودی</returns>
    /// <response code="200">لیست حرکات موجودی با موفقیت بازگردانده شد</response>
    [HttpGet("movements")]
    [ProducesResponseType(typeof(IEnumerable<InventoryMovementDto>), 200)]
    public async Task<ActionResult<IEnumerable<InventoryMovementDto>>> GetInventoryMovements(
        [FromQuery] Guid? productId = null,
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        var query = new GetInventoryMovementsQuery(productId, warehouseId, page, pageSize);
        var movements = await _mediator.Send(query);
        return Ok(movements);
    }

    /// <summary>
    /// ایجاد حرکت موجودی جدید
    /// Creates a new inventory movement
    /// </summary>
    /// <returns>شناسه حرکت موجودی ایجاد شده</returns>
    /// <response code="201">حرکت موجودی با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost("movements")]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateInventoryMovement([FromBody] CreateInventoryMovementCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetInventoryMovements), new { id }, id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "خطا در ایجاد حرکت موجودی", error = ex.Message });
        }
    }
}
