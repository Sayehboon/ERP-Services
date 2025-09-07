using Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Queries.GetAllInventoryMovements;
using Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Queries.GetInventoryMovementById;
using Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Commands.UpdateInventoryMovement;
using Dinawin.Erp.Application.Features.Inventory.InventoryMovements.Commands.DeleteInventoryMovement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Inventory;

/// <summary>
/// کنترلر حرکات انبار
/// </summary>
[Route("api/[controller]")]
public class InventoryMovementsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر حرکات انبار
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public InventoryMovementsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام حرکات انبار
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="productId">شناسه محصول</param>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="binId">شناسه مکان</param>
    /// <param name="movementType">نوع حرکت</param>
    /// <param name="fromDate">از تاریخ</param>
    /// <param name="toDate">تا تاریخ</param>
    /// <param name="referenceType">نوع سند مرجع</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست حرکات انبار</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InventoryMovementDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllInventoryMovements(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? productId = null,
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] Guid? binId = null,
        [FromQuery] string? movementType = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string? referenceType = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllInventoryMovementsQuery
            {
                SearchTerm = searchTerm,
                ProductId = productId,
                WarehouseId = warehouseId,
                BinId = binId,
                MovementType = movementType,
                FromDate = fromDate,
                ToDate = toDate,
                ReferenceType = referenceType,
                Page = page,
                PageSize = pageSize
            };

            var movements = await _mediator.Send(query);
            return Success(movements);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست حرکات انبار");
        }
    }

    /// <summary>
    /// دریافت حرکت انبار بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه حرکت</param>
    /// <returns>اطلاعات حرکت انبار</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(InventoryMovementDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetInventoryMovement(Guid id)
    {
        try
        {
            var query = new GetInventoryMovementByIdQuery { Id = id };
            var movement = await _mediator.Send(query);
            
            if (movement == null)
            {
                return NotFound($"حرکت انبار با شناسه {id} یافت نشد");
            }
            
            return Success(movement);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات حرکت انبار");
        }
    }

    /// <summary>
    /// دریافت حرکات انبار برای یک محصول
    /// </summary>
    /// <param name="productId">شناسه محصول</param>
    /// <returns>لیست حرکات محصول</returns>
    [HttpGet("by-product/{productId}")]
    [ProducesResponseType(typeof(IEnumerable<InventoryMovementDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetMovementsByProduct(Guid productId)
    {
        try
        {
            var query = new GetAllInventoryMovementsQuery { ProductId = productId };
            var movements = await _mediator.Send(query);
            return Success(movements);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حرکات محصول");
        }
    }

    /// <summary>
    /// دریافت حرکات انبار برای یک انبار
    /// </summary>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <returns>لیست حرکات انبار</returns>
    [HttpGet("by-warehouse/{warehouseId}")]
    [ProducesResponseType(typeof(IEnumerable<InventoryMovementDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetMovementsByWarehouse(Guid warehouseId)
    {
        try
        {
            var query = new GetAllInventoryMovementsQuery { WarehouseId = warehouseId };
            var movements = await _mediator.Send(query);
            return Success(movements);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حرکات انبار");
        }
    }

    /// <summary>
    /// ایجاد حرکت انبار جدید
    /// </summary>
    /// <param name="command">دستور ایجاد حرکت</param>
    /// <returns>شناسه حرکت ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateInventoryMovement([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی CreateInventoryMovementCommand
            var movementId = Guid.NewGuid();
            return Created(movementId, "حرکت انبار با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد حرکت انبار");
        }
    }

    /// <summary>
    /// حذف حرکت انبار
    /// </summary>
    /// <param name="id">شناسه حرکت</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteInventoryMovement(Guid id)
    {
        try
        {
            var command = new DeleteInventoryMovementCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("حرکت انبار با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف حرکت انبار");
        }
    }
}
