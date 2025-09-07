using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetAllBankAccounts;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Queries.GetBankAccountById;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.CreateBankAccount;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccount;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.UpdateBankAccountBalance;
using Dinawin.Erp.Application.Features.Financial.BankAccounts.Commands.DeleteBankAccount;

namespace Dinawin.Erp.WebApi.Controllers.Financial;

/// <summary>
/// کنترلر مدیریت حساب‌های بانکی
/// </summary>
[Route("api/[controller]")]
public class BankAccountsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر حساب‌های بانکی
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public BankAccountsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام حساب‌های بانکی
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="bankName">نام بانک</param>
    /// <param name="accountType">نوع حساب</param>
    /// <param name="currency">ارز</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام حساب‌های بانکی</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BankAccountDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllBankAccounts(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? bankName = null,
        [FromQuery] string? accountType = null,
        [FromQuery] string? currency = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllBankAccountsQuery
            {
                SearchTerm = searchTerm,
                BankName = bankName,
                AccountType = accountType,
                Currency = currency,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var bankAccounts = await _mediator.Send(query);
            return Success(bankAccounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست حساب‌های بانکی");
        }
    }

    /// <summary>
    /// دریافت حساب بانکی بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه حساب بانکی</param>
    /// <returns>اطلاعات حساب بانکی</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BankAccountDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetBankAccount(Guid id)
    {
        try
        {
            var query = new GetBankAccountByIdQuery { Id = id };
            var bankAccount = await _mediator.Send(query);
            
            if (bankAccount == null)
            {
                return NotFound($"حساب بانکی با شناسه {id} یافت نشد");
            }
            
            return Success(bankAccount);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات حساب بانکی");
        }
    }

    /// <summary>
    /// دریافت حساب‌های بانکی فعال
    /// </summary>
    /// <returns>لیست حساب‌های بانکی فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<BankAccountDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveBankAccounts()
    {
        try
        {
            var query = new GetAllBankAccountsQuery { IsActive = true };
            var bankAccounts = await _mediator.Send(query);
            return Success(bankAccounts);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حساب‌های بانکی فعال");
        }
    }

    /// <summary>
    /// دریافت تراکنش‌های حساب بانکی
    /// </summary>
    /// <param name="id">شناسه حساب بانکی</param>
    /// <returns>لیست تراکنش‌ها</returns>
    [HttpGet("{id}/transactions")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetBankAccountTransactions(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی GetBankAccountTransactionsQuery
            var transactions = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    TransactionDate = DateTime.Now.AddDays(-5),
                    Description = "واریز فروش",
                    Amount = 1000000000,
                    TransactionType = "واریز",
                    Balance = 5000000000
                }
            };
            return Success(transactions);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تراکنش‌های حساب بانکی");
        }
    }

    /// <summary>
    /// ایجاد حساب بانکی جدید
    /// </summary>
    /// <param name="command">دستور ایجاد حساب بانکی</param>
    /// <returns>شناسه حساب بانکی ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateBankAccount([FromBody] CreateBankAccountCommand command)
    {
        try
        {
            var bankAccountId = await _mediator.Send(command);
            return Created(bankAccountId, "حساب بانکی با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد حساب بانکی");
        }
    }

    /// <summary>
    /// به‌روزرسانی حساب بانکی
    /// </summary>
    /// <param name="id">شناسه حساب بانکی</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateBankAccount(Guid id, [FromBody] UpdateBankAccountCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("حساب بانکی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی حساب بانکی");
        }
    }

    /// <summary>
    /// به‌روزرسانی موجودی حساب بانکی
    /// </summary>
    /// <param name="id">شناسه حساب بانکی</param>
    /// <param name="command">دستور به‌روزرسانی موجودی</param>
    /// <returns>نتیجه به‌روزرسانی موجودی</returns>
    [HttpPatch("{id}/balance")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateBankAccountBalance(Guid id, [FromBody] UpdateBankAccountBalanceCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success(result, "موجودی حساب بانکی با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی موجودی حساب بانکی");
        }
    }

    /// <summary>
    /// حذف حساب بانکی
    /// </summary>
    /// <param name="id">شناسه حساب بانکی</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteBankAccount(Guid id)
    {
        try
        {
            var command = new DeleteBankAccountCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("حساب بانکی با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف حساب بانکی");
        }
    }
}
