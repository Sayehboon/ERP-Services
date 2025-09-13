using Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetAllBins;
using Dinawin.Erp.Application.Features.Inventories.Bins.Queries.GetBinById;
using Dinawin.Erp.Application.Features.Inventories.Bins.Commands.CreateBin;
using Dinawin.Erp.Application.Features.Inventories.Bins.Commands.UpdateBin;
using Dinawin.Erp.Application.Features.Inventories.Bins.Commands.DeleteBin;
using Dinawin.Erp.Application.Features.Inventories.Bins.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Inventory;

/// <summary>
/// کنترلر مدیریت مکان‌های انبار (بین‌ها)
/// </summary>
[Route("api/[controller]")]
public class BinsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر مکان‌های انبار
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public BinsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام مکان‌های انبار
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <param name="binType">نوع مکان</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست مکان‌های انبار</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BinDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllBins(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? warehouseId = null,
        [FromQuery] string? binType = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllBinsQuery
            {
                SearchTerm = searchTerm,
                WarehouseId = warehouseId,
                BinType = binType,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var bins = await _mediator.Send(query);
            return Success(bins);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست مکان‌های انبار");
        }
    }

    /// <summary>
    /// دریافت مکان انبار بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه مکان انبار</param>
    /// <returns>اطلاعات مکان انبار</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BinDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetBin(Guid id)
    {
        try
        {
            var query = new GetBinByIdQuery { Id = id };
            var bin = await _mediator.Send(query);
            
            if (bin == null)
            {
                return NotFound($"مکان انبار با شناسه {id} یافت نشد");
            }
            
            return Success(bin);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات مکان انبار");
        }
    }

    /// <summary>
    /// دریافت مکان‌های انبار یک انبار
    /// </summary>
    /// <param name="warehouseId">شناسه انبار</param>
    /// <returns>لیست مکان‌های انبار</returns>
    [HttpGet("by-warehouse/{warehouseId}")]
    [ProducesResponseType(typeof(IEnumerable<BinDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetBinsByWarehouse(Guid warehouseId)
    {
        try
        {
            var query = new GetAllBinsQuery { WarehouseId = warehouseId };
            var bins = await _mediator.Send(query);
            return Success(bins);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت مکان‌های انبار");
        }
    }

    /// <summary>
    /// ایجاد مکان انبار جدید
    /// </summary>
    /// <param name="command">دستور ایجاد مکان انبار</param>
    /// <returns>شناسه مکان انبار ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreateBin([FromBody] CreateBinCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created(id, "مکان انبار با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد مکان انبار");
        }
    }

    /// <summary>
    /// به‌روزرسانی مکان انبار
    /// </summary>
    /// <param name="id">شناسه مکان انبار</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateBin(Guid id, [FromBody] UpdateBinCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("مکان انبار با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی مکان انبار");
        }
    }

    /// <summary>
    /// حذف مکان انبار
    /// </summary>
    /// <param name="id">شناسه مکان انبار</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteBin(Guid id)
    {
        try
        {
            var command = new DeleteBinCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("مکان انبار با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف مکان انبار");
        }
    }
}
