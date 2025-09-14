using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.Application.Features.SalesOrders.Commands.CreateSalesOrder;
using Dinawin.Erp.Application.Features.Sales.SalesOrders.Commands.UpdateSalesOrder;
using Dinawin.Erp.Application.Features.SalesOrders.Queries.GetAllSalesOrders;
using Dinawin.Erp.Application.Features.SalesOrders.DTOs;

namespace Dinawin.Erp.WebApi.Controllers.Sales;

/// <summary>
/// کنترلر مدیریت سفارشات فروش
/// Controller for managing sales orders
/// </summary>
[Route("api/[controller]")]
public class SalesOrdersController : BaseController
{
    /// <summary>
    /// سازنده کنترلر سفارشات فروش
    /// Sales orders controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    public SalesOrdersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت لیست تمام سفارشات فروش
    /// Gets all sales orders with optional filtering
    /// </summary>
    /// <param name="query">پارامترهای فیلتر</param>
    /// <returns>لیست سفارشات فروش</returns>
    /// <response code="200">لیست سفارشات فروش با موفقیت بازگردانده شد</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SalesOrderDto>), 200)]
    public async Task<ActionResult<List<SalesOrderDto>>> GetAllSalesOrders([FromQuery] GetAllSalesOrdersQuery query)
    {
        try
        {
            var salesOrders = await _mediator.Send(query);
            return Success(salesOrders, "لیست سفارشات فروش با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت سفارش فروش با شناسه
    /// Gets a sales order by ID
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>اطلاعات سفارش فروش</returns>
    /// <response code="200">سفارش پیدا شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(SalesOrderDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<SalesOrderDto>> GetSalesOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement GetSalesOrderByIdQuery
            await Task.CompletedTask;
            return Error("سفارش فروش با شناسه مشخص شده پیدا نشد", 404);
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ایجاد سفارش فروش جدید
    /// Creates a new sales order
    /// </summary>
    /// <param name="command">اطلاعات سفارش جدید</param>
    /// <returns>شناسه سفارش ایجاد شده</returns>
    /// <response code="201">سفارش با موفقیت ایجاد شد</response>
    /// <response code="400">اطلاعات ارسالی نامعتبر است</response>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateSalesOrder([FromBody] CreateSalesOrderCommand command)
    {
        try
        {
            var salesOrderId = await _mediator.Send(command);
            return Created(salesOrderId, salesOrderId, nameof(GetSalesOrder));
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// ویرایش سفارش فروش
    /// Updates an existing sales order
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
    public async Task<IActionResult> UpdateSalesOrder(Guid id, [FromBody] UpdateSalesOrderCommand command)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateSalesOrderCommand
            await Task.CompletedTask;
            return Updated("سفارش فروش با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// حذف سفارش فروش
    /// Deletes a sales order
    /// </summary>
    /// <param name="id">شناسه سفارش</param>
    /// <returns>نتیجه حذف</returns>
    /// <response code="200">سفارش با موفقیت حذف شد</response>
    /// <response code="404">سفارش پیدا نشد</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteSalesOrder(Guid id)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement DeleteSalesOrderCommand
            await Task.CompletedTask;
            return Deleted("سفارش فروش با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// تغییر وضعیت سفارش فروش
    /// Updates sales order status
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
    public async Task<IActionResult> UpdateSalesOrderStatus(Guid id, [FromBody] string status)
    {
        try
        {
            var validationResult = ValidateId(id);
            if (validationResult != null) return validationResult;

            // TODO: Implement UpdateSalesOrderStatusCommand
            await Task.CompletedTask;
            return Success("وضعیت سفارش با موفقیت تغییر کرد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }

    /// <summary>
    /// دریافت آمار سفارشات فروش
    /// Gets sales orders statistics
    /// </summary>
    /// <returns>آمار سفارشات</returns>
    /// <response code="200">آمار سفارشات با موفقیت بازگردانده شد</response>
    [HttpGet("statistics")]
    [ProducesResponseType(typeof(object), 200)]
    public async Task<ActionResult<object>> GetSalesOrderStatistics()
    {
        try
        {
            // TODO: Implement GetSalesOrderStatisticsQuery
            await Task.CompletedTask;
            
            var mockStats = new
            {
                Total = 5,
                Confirmed = 2,
                InProduction = 1,
                Shipped = 1,
                Delivered = 1,
                TodaySales = 18200000m,
                NewCustomers = 7,
                TodayOrders = 23,
                GrowthRate = 22
            };

            return Success(mockStats, "آمار سفارشات با موفقیت بازگردانده شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex);
        }
    }
}

