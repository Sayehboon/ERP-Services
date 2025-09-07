using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetAllWarehouses;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Queries.GetWarehouseById;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.UpdateWarehouse;
using Dinawin.Erp.Application.Features.Inventory.Warehouses.Commands.DeleteWarehouse;

namespace Dinawin.Erp.WebApi.Controllers.Inventory;

/// <summary>
/// کنترلر مدیریت انبارها
/// </summary>
[Route("api/[controller]")]
public class WarehousesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر انبارها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public WarehousesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام انبارها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="warehouseType">نوع انبار</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام انبارها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WarehouseDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllWarehouses(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? warehouseType = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllWarehousesQuery
            {
                SearchTerm = searchTerm,
                WarehouseType = warehouseType,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var warehouses = await _mediator.Send(query);
            return Success(warehouses);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست انبارها");
        }
    }

    /// <summary>
    /// دریافت انبار بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه انبار</param>
    /// <returns>اطلاعات انبار</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(WarehouseDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetWarehouse(Guid id)
    {
        try
        {
            var query = new GetWarehouseByIdQuery { Id = id };
            var warehouse = await _mediator.Send(query);
            
            if (warehouse == null)
            {
                return NotFound($"انبار با شناسه {id} یافت نشد");
            }
            
            return Success(warehouse);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات انبار");
        }
    }

    /// <summary>
    /// دریافت انبارهای فعال
    /// </summary>
    /// <returns>لیست انبارهای فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveWarehouses()
    {
        try
        {
            var query = new GetAllWarehousesQuery { IsActive = true };
            var warehouses = await _mediator.Send(query);
            return Success(warehouses);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت انبارهای فعال");
        }
    }

    /// <summary>
    /// ایجاد انبار جدید
    /// </summary>
    /// <param name="command">دستور ایجاد انبار</param>
    /// <returns>شناسه انبار ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateWarehouse([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی CreateWarehouseCommand
            var warehouseId = Guid.NewGuid();
            return Created(warehouseId, "انبار با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد انبار");
        }
    }

    /// <summary>
    /// به‌روزرسانی انبار
    /// </summary>
    /// <param name="id">شناسه انبار</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateWarehouse(Guid id, [FromBody] UpdateWarehouseCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("انبار با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی انبار");
        }
    }

    /// <summary>
    /// حذف انبار
    /// </summary>
    /// <param name="id">شناسه انبار</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteWarehouse(Guid id)
    {
        try
        {
            var command = new DeleteWarehouseCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("انبار با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف انبار");
        }
    }
}
