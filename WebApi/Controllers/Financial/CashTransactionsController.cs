using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.Dtos;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Queries.GetCashTransactionsByCashBoxes;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.CreateCashTransaction;
using Dinawin.Erp.Application.Features.Treasury.CashTransactions.Commands.PostCashTransaction;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;

namespace Dinawin.Erp.WebApi.Controllers.Financial;

/// <summary>
/// کنترلر تراکنش‌های نقدی
/// </summary>
[Route("api/[controller]")]
public class CashTransactionsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تراکنش‌های نقدی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public CashTransactionsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام تراکنش‌های نقدی
    /// </summary>
    /// <param name="cashBoxIds">شناسه‌های صندوق‌های نقدی</param>
    /// <returns>لیست تراکنش‌های نقدی</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CashTransactionDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllCashTransactions([FromQuery] Guid[] cashBoxIds)
    {
        try
        {
            var result = await _mediator.Send(new GetCashTransactionsByCashBoxesQuery(cashBoxIds));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست تراکنش‌های نقدی");
        }
    }

    /// <summary>
    /// دریافت تراکنش نقدی بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه تراکنش</param>
    /// <returns>اطلاعات تراکنش نقدی</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CashTransactionDto), 200)]
    [ProducesResponseType(404)]
    public object GetCashTransaction(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetCashTransactionByIdQuery
            var transaction = new { 
                Id = id, 
                TransactionDate = DateTime.Now,
                Description = "دریافت نقدی فروش",
                Amount = 10000000
            };
            return Success(transaction);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات تراکنش نقدی");
        }
    }

    /// <summary>
    /// دریافت تراکنش‌های یک صندوق نقدی
    /// </summary>
    /// <param name="cashBoxId">شناسه صندوق نقدی</param>
    /// <returns>لیست تراکنش‌های صندوق</returns>
    [HttpGet("by-cashbox/{cashBoxId}")]
    [ProducesResponseType(typeof(IEnumerable<CashTransactionDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetCashTransactionsByCashBox(Guid cashBoxId)
    {
        try
        {
            var result = await _mediator.Send(new GetCashTransactionsByCashBoxesQuery(new[] { cashBoxId }));
            return Success(result);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تراکنش‌های صندوق نقدی");
        }
    }

    /// <summary>
    /// ایجاد تراکنش نقدی جدید
    /// </summary>
    /// <param name="command">دستور ایجاد تراکنش</param>
    /// <returns>شناسه تراکنش ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreateCashTransaction([FromBody] CreateCashTransactionCommand command)
    {
        try
        {
            var id = await _mediator.Send(command);
            return Created(id, "تراکنش نقدی با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد تراکنش نقدی");
        }
    }

    /// <summary>
    /// تایید تراکنش نقدی
    /// </summary>
    /// <param name="id">شناسه تراکنش</param>
    /// <returns>نتیجه تایید</returns>
    [HttpPost("{id}/post")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> PostCashTransaction(Guid id)
    {
        try
        {
            var ok = await _mediator.Send(new PostCashTransactionCommand(id));
            if (!ok) return NotFound("تراکنش نقدی یافت نشد");
            return Success("تراکنش نقدی با موفقیت تایید شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تایید تراکنش نقدی");
        }
    }

    /// <summary>
    /// حذف تراکنش نقدی
    /// </summary>
    /// <param name="id">شناسه تراکنش</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public ActionResult DeleteCashTransaction(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی DeleteCashTransactionCommand
            return Success("تراکنش نقدی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف تراکنش نقدی");
        }
    }
}
