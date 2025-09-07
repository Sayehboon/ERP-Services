using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetChartOfAccountById;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.CreateChartOfAccount;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.UpdateChartOfAccount;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.DeleteChartOfAccount;

namespace Dinawin.Erp.WebApi.Controllers.Accounting;

/// <summary>
/// کنترلر مدیریت حساب‌های کل
/// </summary>
[Route("api/[controller]")]
public class ChartOfAccountsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر حساب‌های کل
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public ChartOfAccountsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام حساب‌های کل
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="parentAccountId">شناسه حساب والد</param>
    /// <param name="accountType">نوع حساب</param>
    /// <param name="accountCategory">دسته حساب</param>
    /// <param name="level">سطح حساب</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام حساب‌های کل</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ChartOfAccountDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllAccounts(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? parentAccountId = null,
        [FromQuery] string? accountType = null,
        [FromQuery] string? accountCategory = null,
        [FromQuery] int? level = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllChartOfAccountsQuery
            {
                SearchTerm = searchTerm,
                ParentAccountId = parentAccountId,
                AccountType = accountType,
                AccountCategory = accountCategory,
                Level = level,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var accounts = await _mediator.Send(query);
            return Success(accounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست حساب‌های کل");
        }
    }

    /// <summary>
    /// دریافت حساب بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه حساب</param>
    /// <returns>اطلاعات حساب</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ChartOfAccountDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetAccount(Guid id)
    {
        try
        {
            var query = new GetChartOfAccountByIdQuery { Id = id };
            var account = await _mediator.Send(query);
            
            if (account == null)
            {
                return NotFound($"حساب با شناسه {id} یافت نشد");
            }
            
            return Success(account);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات حساب");
        }
    }

    /// <summary>
    /// دریافت حساب‌های یک نوع
    /// </summary>
    /// <param name="accountType">نوع حساب</param>
    /// <returns>لیست حساب‌های نوع مشخص</returns>
    [HttpGet("by-type/{accountType}")]
    [ProducesResponseType(typeof(IEnumerable<ChartOfAccountDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAccountsByType(string accountType)
    {
        try
        {
            var query = new GetAllChartOfAccountsQuery { AccountType = accountType };
            var accounts = await _mediator.Send(query);
            return Success(accounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حساب‌های نوع مشخص");
        }
    }

    /// <summary>
    /// دریافت حساب‌های فرزند
    /// </summary>
    /// <param name="parentId">شناسه حساب والد</param>
    /// <returns>لیست حساب‌های فرزند</returns>
    [HttpGet("children/{parentId}")]
    [ProducesResponseType(typeof(IEnumerable<ChartOfAccountDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetChildAccounts(Guid parentId)
    {
        try
        {
            var query = new GetAllChartOfAccountsQuery { ParentAccountId = parentId };
            var accounts = await _mediator.Send(query);
            return Success(accounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حساب‌های فرزند");
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
    public async Task<ActionResult> CreateAccount([FromBody] CreateChartOfAccountCommand command)
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
    public async Task<ActionResult> UpdateAccount(Guid id, [FromBody] UpdateChartOfAccountCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
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
            var command = new DeleteChartOfAccountCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("حساب با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف حساب");
        }
    }
}
