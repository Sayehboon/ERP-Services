using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAllChartOfAccounts;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetChartOfAccountById;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetAccountBalance;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Queries.GetTrialBalance;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.CreateChartOfAccount;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.UpdateChartOfAccount;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Commands.DeleteChartOfAccount;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.DTOs;
using Dinawin.Erp.Application.Features.Accounting.ChartOfAccounts.Services;
using Dinawin.Erp.Domain.Enums;

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
    public async Task<ActionResult<IEnumerable<ChartOfAccountDto>>> GetAllAccounts(
        [FromQuery] string searchTerm = null,
        [FromQuery] Guid? parentAccountId = null,
        [FromQuery] AccountTypeEnum? accountType = null,
        [FromQuery] string accountCategory = null,
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
    public async Task<ActionResult<ChartOfAccountDto>> GetAccount(Guid id)
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
    public async Task<ActionResult<IEnumerable<ChartOfAccountDto>>> GetAccountsByType(AccountTypeEnum accountType)
    {
        try
        {
            var query = new GetAllChartOfAccountsQuery 
            { 
                AccountType = accountType 
            };
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
    public async Task<ActionResult<IEnumerable<ChartOfAccountDto>>> GetChildAccounts(Guid parentId)
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
    public async Task<ActionResult<Guid>> CreateAccount([FromBody] CreateChartOfAccountCommand command)
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

    /// <summary>
    /// دریافت مانده حساب
    /// </summary>
    /// <param name="id">شناسه حساب</param>
    /// <param name="fromDate">تاریخ شروع (اختیاری)</param>
    /// <param name="toDate">تاریخ پایان (اختیاری)</param>
    /// <param name="includeChildren">آیا شامل حساب‌های فرزند باشد</param>
    /// <returns>مانده حساب</returns>
    [HttpGet("{id}/balance")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<AccountBalanceDto>> GetAccountBalance(
        Guid id,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] bool includeChildren = false)
    {
        try
        {
            var query = new GetAccountBalanceQuery
            {
                AccountId = id,
                FromDate = fromDate,
                ToDate = toDate,
                IncludeChildren = includeChildren
            };

            var balance = await _mediator.Send(query);
            
            if (balance == null)
            {
                return NotFound("حساب یافت نشد");
            }

            return Success(balance);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت مانده حساب");
        }
    }

    /// <summary>
    /// دریافت تراز آزمایشی
    /// </summary>
    /// <param name="fromDate">تاریخ شروع (اختیاری)</param>
    /// <param name="toDate">تاریخ پایان (اختیاری)</param>
    /// <param name="accountType">نوع حساب (اختیاری)</param>
    /// <param name="accountCategory">دسته‌بندی حساب (اختیاری)</param>
    /// <param name="level">سطح حساب (اختیاری)</param>
    /// <param name="onlyNonZeroBalances">آیا فقط حساب‌های با مانده غیر صفر را نمایش دهد</param>
    /// <param name="includeInactiveAccounts">آیا شامل حساب‌های غیرفعال باشد</param>
    /// <returns>تراز آزمایشی</returns>
    [HttpGet("trial-balance")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<TrialBalanceDto>> GetTrialBalance(
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] AccountTypeEnum? accountType = null,
        [FromQuery] string accountCategory = null,
        [FromQuery] int? level = null,
        [FromQuery] bool onlyNonZeroBalances = false,
        [FromQuery] bool includeInactiveAccounts = false)
    {
        try
        {
            var query = new GetTrialBalanceQuery
            {
                FromDate = fromDate,
                ToDate = toDate,
                AccountType = accountType,
                AccountCategory = accountCategory,
                Level = level,
                OnlyNonZeroBalances = onlyNonZeroBalances,
                IncludeInactiveAccounts = includeInactiveAccounts
            };

            var trialBalance = await _mediator.Send(query);
            return Success(trialBalance);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تراز آزمایشی");
        }
    }

    /// <summary>
    /// دریافت انواع حساب
    /// </summary>
    /// <returns>لیست انواع حساب</returns>
    [HttpGet("account-types")]
    [ProducesResponseType(typeof(IEnumerable<EnumItemDto>), 200)]
    [ProducesResponseType(400)]
    public ActionResult<IEnumerable<EnumItemDto>> GetAccountTypes()
    {
        try
        {
            var accountTypes = EnumService.GetAccountTypeEnumItems();
            return Success(accountTypes);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت انواع حساب");
        }
    }

    /// <summary>
    /// دریافت ترازهای طبیعی
    /// </summary>
    /// <returns>لیست ترازهای طبیعی</returns>
    [HttpGet("normal-balances")]
    [ProducesResponseType(typeof(IEnumerable<EnumItemDto>), 200)]
    [ProducesResponseType(400)]
    public ActionResult<IEnumerable<EnumItemDto>> GetNormalBalances()
    {
        try
        {
            var normalBalances = EnumService.GetNormalBalanceEnumItems();
            return Success(normalBalances);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت ترازهای طبیعی");
        }
    }
}
