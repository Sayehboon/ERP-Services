using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.PurchaseOrders.Commands.CreatePurchaseOrder;
using Dinawin.Erp.Application.Features.Purchase.PurchaseOrders.Commands.UpdatePurchaseOrder;
using Dinawin.Erp.Application.Features.PurchaseOrders.Queries.GetAllPurchaseOrders;
using Dinawin.Erp.Application.Features.PurchaseOrders.DTOs;

namespace Dinawin.Erp.WebApi.Controllers.Purchase;

/// <summary>
/// کنترلر مدیریت سفارشات خرید
/// Controller for managing purchase orders
/// </summary>
[Route("api/[controller]")]
public class PurchaseOrdersController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سفارشات خرید
    /// Purchase orders controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public PurchaseOrdersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام سفارشات خرید
    /// Gets all purchase orders with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست سفارشات خرید</returns>
    /// <response code="200">لیست سفارشات خرید با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PurchaseOrderDto>), 200)]
    public async Task<ActionResult<List<PurchaseOrderDto>>> GetAllPurchaseOrders([FromQuery] GetAllPurchaseOrdersQuery query)
    {
        try
        {
            var purchaseOrders = await _mediator.Send(query);
            return Success(purchaseOrders, "لیست سفارشات خرید با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت سفارش خرید با شناسه
    /// Gets a purchase order by ID
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>اطلاعات سفارش خرید</returns>
    /// <response code="200">سفارش پیدا شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PurchaseOrderDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<PurchaseOrderDto>> GetPurchaseOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetPurchaseOrderByIdQuery
            await Task.CompletedTask;
            return Error("سفارش خرید با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد سفارش خرید جدید
    /// Creates a new purchase order
    /// </summary>
    /// <param name="command">اطلاعات سفارش جدید</param>
    /// <returns>شناسه سفارش ایجاد شده</returns>
    /// <response code="201">سفارش با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreatePurchaseOrder([FromBody] CreatePurchaseOrderCommand command)
    {
        try
        {
            var purchaseOrderId = await _mediator.Send(command);
            return Created(purchaseOrderId, purchaseOrderId, nameof(GetPurchaseOrder));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش سفارش خرید
    /// Updates an existing purchase order
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <param name="command">اطلاعات به‌روزرسانی</param>
    /// <returns>نتیجه ویرایش</returns>
    /// <response code="200">سفارش با موفقیت ویرایش شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdatePurchaseOrder(Guid id, [FromBody] UpdatePurchaseOrderCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdatePurchaseOrderCommand
            await Task.CompletedTask;
            return Updated("سفارش خرید با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف سفارش خرید
    /// Deletes a purchase order
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">سفارش با موفقیت حذف شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeletePurchaseOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeletePurchaseOrderCommand
            await Task.CompletedTask;
            return Deleted("سفارش خرید با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ارسال سفارش خرید به تامین‌کننده
    /// Sends purchase order to vendor
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>نتیجه ارسال</returns>
    /// <response code="200">سفارش با موفقیت ارسال شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    /// <response code="400">سفارش قابل ارسال نیست</response>
    [HttpPost("{id}/send")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> SendPurchaseOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement SendPurchaseOrderCommand
            await Task.CompletedTask;
            return Success("سفارش خرید با موفقیت ارسال شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دانلود سفارش خرید
    /// Downloads purchase order
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>فایل سفارش خرید</returns>
    /// <response code="200">فایل سفارش با موفقیت دانلود شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    [HttpGet("{id}/download")]
    [ProducesResponseType(typeof(FileResult), 200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DownloadPurchaseOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DownloadPurchaseOrderQuery
            await Task.CompletedTask;
            return Error("سفارش خرید با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت سفارش خرید
    /// Updates purchase order status
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <param name="status">وضعیت جدید</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    /// <response code="200">وضعیت سفارش با موفقیت تغییر کرد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    /// <response code="400">وضعیت نامعتبر است</response>
    [HttpPatch("{id}/status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdatePurchaseOrderStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdatePurchaseOrderStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت سفارش با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

