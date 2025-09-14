using Dinawin.Erp.Application.Features.Accounting.Bills.Queries.GetAllBills;
using Dinawin.Erp.Application.Features.Accounting.Bills.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.CreatePurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.UpdatePurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.PostPurchaseBill;
using Dinawin.Erp.Application.Features.Accounting.Bills.Commands.DeletePurchaseBill;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Purchase;

/// <summary>
/// کنترلر مدیریت فاکتورهای خرید
/// </summary>
[Route("api/[controller]")]
public class PurchaseBillsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر فاکتورهای خرید
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public PurchaseBillsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام فاکتورهای خرید
    /// </summary>
    /// <param name="vendorId">شناسه تامین‌کننده</param>
    /// <param name="status">وضعیت فاکتور</param>
    /// <param name="fromDate">از تاریخ</param>
    /// <param name="toDate">تا تاریخ</param>
    /// <returns>لیست فاکتورهای خرید</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PurchaseBillDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllPurchaseBills(
        [FromQuery] Guid? vendorId = null, 
        [FromQuery] string status = null, 
        [FromQuery] DateTime? fromDate = null, 
        [FromQuery] DateTime? toDate = null)
    {
        try
        {
            var result = await _mediator.Send(new GetAllBillsQuery(vendorId, status, fromDate, toDate));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست فاکتورهای خرید");
        }
    }

    /// <summary>
    /// دریافت فاکتور خرید بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>اطلاعات فاکتور خرید</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PurchaseBillDto), 200)]
    [ProducesResponseType(404)]
    public object GetPurchaseBill(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetPurchaseBillByIdQuery
            var bill = new { 
                Id = id, 
                BillNumber = "PB001",
                BillDate = DateTime.Now,
                VendorId = Guid.NewGuid(),
                TotalAmount = 1000000000
            };
            return Success(bill);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات فاکتور خرید");
        }
    }

    /// <summary>
    /// ایجاد فاکتور خرید جدید
    /// </summary>
    /// <param name="command">دستور ایجاد فاکتور</param>
    /// <returns>شناسه فاکتور ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreatePurchaseBill([FromBody] CreatePurchaseBillCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created(id, "فاکتور خرید با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد فاکتور خرید");
        }
    }

    /// <summary>
    /// ویرایش فاکتور خرید
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <param name="command">دستور ویرایش</param>
    /// <returns>نتیجه ویرایش</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> UpdatePurchaseBill(Guid id, [FromBody] UpdatePurchaseBillCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه فاکتور مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("فاکتور خرید یافت نشد");
            return Success("فاکتور خرید با موفقیت ویرایش شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ویرایش فاکتور خرید");
        }
    }

    /// <summary>
    /// ثبت فاکتور خرید در دفتر کل
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه ثبت</returns>
    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> PostPurchaseBill(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new PostPurchaseBillCommand(id));
            if (!ok) return NotFound("فاکتور خرید یافت نشد");
            return Success("فاکتور خرید با موفقیت ثبت شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ثبت فاکتور خرید");
        }
    }

    /// <summary>
    /// حذف فاکتور خرید
    /// </summary>
    /// <param name="id">شناسه فاکتور</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeletePurchaseBill(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new DeletePurchaseBillCommand(id));
            if (!ok) return NotFound("فاکتور خرید یافت نشد");
            return Success("فاکتور خرید با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف فاکتور خرید");
        }
    }
}
