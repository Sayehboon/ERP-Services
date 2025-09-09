using Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.CreateAccount;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Commands.UpdateAccountStatus;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.Dtos;
using Dinawin.Erp.Application.Features.Accounting.Accounts.Queries.GetAllAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر مدیریت حساب‌ها
/// </summary>
[Route("api/[controller]")]
public class AccountsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر حساب‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public AccountsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام حساب‌ها
    /// </summary>
    /// <returns>لیست تمام حساب‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IReadOnlyList<AccountDto>>> GetAllAccounts()
    {
        try
        {
            var accounts = await _mediator.Send(new GetAllAccountsQuery());
            return Success(accounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست حساب‌ها");
        }
    }

    /// <summary>
    /// دریافت حساب بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه حساب</param>
    /// <returns>اطلاعات حساب</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AccountDto>> GetAccount(Guid id)
    {
        try
        {
            // There is no explicit GetAccountById query; fetch from business/all then filter
            var accounts = await _mediator.Send(new GetAllAccountsQuery());
            var account = accounts.FirstOrDefault(a => a.Id == id);
            if (account == null) return NotFound("حساب یافت نشد");
            return Success(account);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات حساب");
        }
    }

    /// <summary>
    /// ایجاد حساب جدید
    /// </summary>
    /// <param name="command">دستور ایجاد حساب</param>
    /// <returns>شناسه حساب ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateAccount([FromBody] CreateAccountCommand command)
    {
        try
        {
            var accountId = await _mediator.Send(command);
            return Created(accountId, "حساب با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد حساب");
        }
    }

    /// <summary>
    /// به‌روزرسانی حساب
    /// </summary>
    /// <param name="id">شناسه حساب</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateAccount(Guid id, [FromBody] UpdateAccountStatusCommand command)
    {
        try
        {
            if (command.Id != id) return BadRequest("شناسه حساب مطابقت ندارد");
            var ok = await _mediator.Send(command);
            if (!ok) return NotFound("حساب یافت نشد");
            return Success("حساب با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی حساب");
        }
    }

    /// <summary>
    /// حذف حساب
    /// </summary>
    /// <param name="id">شناسه حساب</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteAccount(Guid id)
    {
        try
        {
            // No delete command defined; set inactive as soft-delete
            var ok = await _mediator.Send(new UpdateAccountStatusCommand(id, false));
            if (!ok) return NotFound("حساب یافت نشد");
            return Success("حساب با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف حساب");
        }
    }
}
