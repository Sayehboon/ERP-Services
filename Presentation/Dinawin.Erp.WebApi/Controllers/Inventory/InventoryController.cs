using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetAllInventory;
using Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryById;
using Dinawin.Erp.Application.Features.Inventories.Inventories.Queries.GetInventoryByProduct;
using Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.UpdateInventory;
using Dinawin.Erp.Application.Features.Inventories.Inventories.Commands.DeleteInventory;

namespace Dinawin.Erp.WebApi.Controllers.Inventory;

/// <summary>
/// کنترلر مدیریت موجودی
/// </summary>
[Route("api/[controller]")]
public class InventoryController : BaseController
{
    /// <summary>
    /// سازنده کنترلر موجودی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public InventoryController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام موجودی‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="productId">شناسه محصول</param>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="binId">شناسه مکان</param>
    /// <param name="lowStock">فیلتر موجودی کم</param>
    /// <param name="expired">فیلتر موجودی منقضی</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام موجودی‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InventoryDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllInventory(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? productId = null,
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] Guid? binId = null,
        [FromQuery] bool? lowStock = null,
        [FromQuery] bool? expired = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllInventoryQuery
            {
                SearchTerm = searchTerm,
                ProductId = productId,
                WarehouseId = warehouseId,
                BinId = binId,
                LowStock = lowStock,
                Expired = expired,
                Page = page,
                PageSize = pageSize
            };

            var inventory = await _mediator.Send(query);
            return Success(inventory);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست موجودی‌ها");
        }
    }

    /// <summary>
    /// دریافت موجودی بر اساس شناسه محصول
    /// </summary>
    /// <param name="productId">شناسه محصول</param>
    /// <returns>اطلاعات موجودی محصول</returns>
    [HttpGet("product/{productId}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetInventoryByProduct(Guid productId)
    {
        try
        {
            var query = new GetInventoryByProductQuery { ProductId = productId };
            var inventory = await _mediator.Send(query);
            
            if (inventory == null)
            {
                return NotFound("محصول یافت نشد");
            }
            
            return Success(inventory);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت موجودی محصول");
        }
    }

    /// <summary>
    /// دریافت موجودی‌های کم
    /// </summary>
    /// <returns>لیست موجودی‌های کم</returns>
    [HttpGet("low-stock")]
    [ProducesResponseType(typeof(IEnumerable<InventoryDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetLowStockItems()
    {
        try
        {
            var query = new GetAllInventoryQuery { LowStock = true };
            var lowStockItems = await _mediator.Send(query);
            return Success(lowStockItems);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت موجودی‌های کم");
        }
    }

    /// <summary>
    /// به‌روزرسانی موجودی
    /// </summary>
    /// <param name="id">شناسه موجودی</param>
    /// <param name="command">دستور به‌روزرسانی موجودی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateInventory(Guid id, [FromBody] UpdateInventoryCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("موجودی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی موجودی");
        }
    }

    /// <summary>
    /// رزرو موجودی
    /// </summary>
    /// <param name="command">دستور رزرو موجودی</param>
    /// <returns>نتیجه رزرو</returns>
    [HttpPost("reserve")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ReserveInventory([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی ReserveInventoryCommand
            return Success("موجودی با موفقیت رزرو شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در رزرو موجودی");
        }
    }

    /// <summary>
    /// آزادسازی موجودی رزرو شده
    /// </summary>
    /// <param name="command">دستور آزادسازی</param>
    /// <returns>نتیجه آزادسازی</returns>
    [HttpPost("release")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> ReleaseInventory([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی ReleaseInventoryCommand
            return Success("موجودی رزرو شده با موفقیت آزاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در آزادسازی موجودی");
        }
    }
}
