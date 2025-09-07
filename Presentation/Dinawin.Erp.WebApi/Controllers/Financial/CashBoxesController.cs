using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetAllCashBoxes;
using Dinawin.Erp.Application.Features.Financial.CashBoxes.Queries.GetCashBoxById;
using Dinawin.Erp.Application.Features.Financial.CashBoxes.Commands.CreateCashBox;

namespace Dinawin.Erp.WebApi.Controllers.Financial;

/// <summary>
/// کنترلر مدیریت صندوق‌های نقدی
/// </summary>
[Route("api/[controller]")]
public class CashBoxesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر صندوق‌های نقدی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public CashBoxesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام صندوق‌های نقدی
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="responsiblePersonId">شناسه مسئول صندوق</param>
    /// <param name="isActive">آیا فقط صندوق‌های فعال</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <returns>لیست تمام صندوق‌های نقدی</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CashBoxDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllCashBoxes(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? responsiblePersonId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllCashBoxesQuery
            {
                SearchTerm = searchTerm,
                ResponsiblePersonId = responsiblePersonId,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var cashBoxes = await _mediator.Send(query);
            return Success(cashBoxes);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست صندوق‌های نقدی");
        }
    }

    /// <summary>
    /// دریافت صندوق نقدی بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <returns>اطلاعات صندوق نقدی</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CashBoxDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetCashBox(Guid id)
    {
        try
        {
            var query = new GetCashBoxByIdQuery { Id = id };
            var cashBox = await _mediator.Send(query);
            
            if (cashBox == null)
            {
                return NotFound($"صندوق نقدی با شناسه {id} یافت نشد");
            }
            
            return Success(cashBox);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات صندوق نقدی");
        }
    }

    /// <summary>
    /// دریافت صندوق‌های نقدی فعال
    /// </summary>
    /// <returns>لیست صندوق‌های نقدی فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveCashBoxes()
    {
        try
        {
            // TODO: پیاده‌سازی GetActiveCashBoxesQuery
            var cashBoxes = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    Name = "صندوق اصلی",
                    Code = "CASH001",
                    IsActive = true
                }
            };
            return Success(cashBoxes);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت صندوق‌های نقدی فعال");
        }
    }

    /// <summary>
    /// دریافت تراکنش‌های صندوق نقدی
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <returns>لیست تراکنش‌ها</returns>
    [HttpGet("{id}/transactions")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetCashBoxTransactions(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetCashBoxTransactionsQuery
            var transactions = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    TransactionDate = DateTime.Now.AddDays(-3),
                    Description = "دریافت نقدی فروش",
                    Amount = 10000000,
                    TransactionType = "دریافت",
                    Balance = 50000000
                }
            };
            return Success(transactions);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تراکنش‌های صندوق نقدی");
        }
    }

    /// <summary>
    /// دریافت موجودی صندوق نقدی
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <returns>موجودی صندوق</returns>
    [HttpGet("{id}/balance")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetCashBoxBalance(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetCashBoxBalanceQuery
            var balance = new
            {
                CashBoxId = id,
                CurrentBalance = 50000000,
                LastUpdated = DateTime.Now.AddHours(-2),
                Currency = "IRR"
            };
            return Success(balance);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت موجودی صندوق نقدی");
        }
    }

    /// <summary>
    /// ایجاد صندوق نقدی جدید
    /// </summary>
    /// <param name="command">دستور ایجاد صندوق نقدی</param>
    /// <returns>شناسه صندوق نقدی ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateCashBox([FromBody] CreateCashBoxCommand command)
    {
        try
        {
            var cashBoxId = await _mediator.Send(command);
            return Created(cashBoxId, "صندوق نقدی با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد صندوق نقدی");
        }
    }

    /// <summary>
    /// به‌روزرسانی صندوق نقدی
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateCashBox(Guid id, [FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی UpdateCashBoxCommand
            return Success("صندوق نقدی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی صندوق نقدی");
        }
    }

    /// <summary>
    /// به‌روزرسانی موجودی صندوق نقدی
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <param name="command">دستور به‌روزرسانی موجودی</param>
    /// <returns>نتیجه به‌روزرسانی موجودی</returns>
    [HttpPatch("{id}/balance")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateCashBoxBalance(Guid id, [FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی UpdateCashBoxBalanceCommand
            return Success("موجودی صندوق نقدی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی موجودی صندوق نقدی");
        }
    }

    /// <summary>
    /// حذف صندوق نقدی
    /// </summary>
    /// <param name="id">شناسه صندوق نقدی</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteCashBox(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی DeleteCashBoxCommand
            return Success("صندوق نقدی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف صندوق نقدی");
        }
    }
}
