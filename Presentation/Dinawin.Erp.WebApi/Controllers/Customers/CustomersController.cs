using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Customers.Queries.GetAllCustomers;
using Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerById;
using Dinawin.Erp.Application.Features.Customers.Queries.SearchCustomers;
using Dinawin.Erp.Application.Features.Customers.Queries.GetActiveCustomers;
using Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerOrders;
using Dinawin.Erp.Application.Features.Customers.Queries.GetCustomerTransactions;
using Dinawin.Erp.Application.Features.Customers.Commands.CreateCustomer;
using CustomerDto = Dinawin.Erp.Application.Features.Customers.Queries.GetAllCustomers.CustomerDto;
using Dinawin.Erp.Application.Features.Customers.Commands.UpdateCustomer;
using Dinawin.Erp.Application.Features.Customers.Commands.DeleteCustomer;
using Dinawin.Erp.Application.Features.Customers.Commands.ToggleCustomerStatus;

namespace Dinawin.Erp.WebApi.Controllers.Customers;

/// <summary>
/// کنترلر مدیریت مشتریان
/// </summary>
[Route("api/[controller]")]
public class CustomersController : BaseController
{
    /// <summary>
    /// سازنده کنترلر مشتریان
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public CustomersController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام مشتریان
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="customerType">نوع مشتری</param>
    /// <param name="city">شهر</param>
    /// <param name="province">استان</param>
    /// <param name="country">کشور</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="minCreditLimit">حداقل اعتبار</param>
    /// <param name="maxCreditLimit">حداکثر اعتبار</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام مشتریان</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CustomerDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAllCustomers(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? customerType = null,
        [FromQuery] string? city = null,
        [FromQuery] string? province = null,
        [FromQuery] string? country = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] decimal? minCreditLimit = null,
        [FromQuery] decimal? maxCreditLimit = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllCustomersQuery
            {
                SearchTerm = searchTerm,
                CustomerType = customerType,
                City = city,
                Province = province,
                Country = country,
                IsActive = isActive,
                MinCreditLimit = minCreditLimit,
                MaxCreditLimit = maxCreditLimit,
                Page = page,
                PageSize = pageSize
            };

            var customers = await _mediator.Send(query);
            return Success(customers);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست مشتریان");
        }
    }

    /// <summary>
    /// دریافت مشتری بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <returns>اطلاعات مشتری</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CustomerDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetCustomer(Guid id)
    {
        try
        {
            var query = new GetCustomerByIdQuery { Id = id };
            var customer = await _mediator.Send(query);
            
            if (customer == null)
            {
                return NotFound($"مشتری با شناسه {id} یافت نشد");
            }
            
            return Success(customer);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات مشتری");
        }
    }

    /// <summary>
    /// جستجوی مشتریان
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>لیست مشتریان مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<CustomerSearchDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<CustomerSearchDto>>> SearchCustomers(
        [FromQuery] string searchTerm,
        [FromQuery] string? customerType = null,
        [FromQuery] string? city = null,
        [FromQuery] string? province = null,
        [FromQuery] string? country = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int maxResults = 20)
    {
        try
        {
            var query = new SearchCustomersQuery
            {
                SearchTerm = searchTerm,
                CustomerType = customerType,
                City = city,
                Province = province,
                Country = country,
                IsActive = isActive,
                MaxResults = maxResults
            };

            var customers = await _mediator.Send(query);
            return Success(customers);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در جستجوی مشتریان");
        }
    }

    /// <summary>
    /// دریافت مشتریان فعال
    /// </summary>
    /// <returns>لیست مشتریان فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetActiveCustomers()
    {
        try
        {
            var query = new GetActiveCustomersQuery();
            var customers = await _mediator.Send(query);
            return Success(customers);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت مشتریان فعال");
        }
    }

    /// <summary>
    /// دریافت تاریخچه سفارشات مشتری
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <returns>تاریخچه سفارشات</returns>
    [HttpGet("{id}/orders")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetCustomerOrders(Guid id)
    {
        try
        {
            var query = new GetCustomerOrdersQuery { CustomerId = id };
            var orders = await _mediator.Send(query);
            return Success(orders);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تاریخچه سفارشات مشتری");
        }
    }

    /// <summary>
    /// دریافت تراکنش‌های مشتری
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <param name="transactionType">نوع تراکنش (اختیاری)</param>
    /// <param name="fromDate">تاریخ شروع (اختیاری)</param>
    /// <param name="toDate">تاریخ پایان (اختیاری)</param>
    /// <param name="minAmount">مبلغ حداقل (اختیاری)</param>
    /// <param name="maxAmount">مبلغ حداکثر (اختیاری)</param>
    /// <param name="maxResults">تعداد نتایج حداکثر</param>
    /// <returns>لیست تراکنش‌های مشتری</returns>
    [HttpGet("{id}/transactions")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetCustomerTransactions(
        Guid id,
        [FromQuery] string? transactionType = null,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] decimal? minAmount = null,
        [FromQuery] decimal? maxAmount = null,
        [FromQuery] int maxResults = 100)
    {
        try
        {
            var query = new GetCustomerTransactionsQuery
            {
                CustomerId = id,
                TransactionType = transactionType,
                FromDate = fromDate,
                ToDate = toDate,
                MinAmount = minAmount,
                MaxAmount = maxAmount,
                MaxResults = maxResults
            };

            var transactions = await _mediator.Send(query);
            return Success(transactions);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تراکنش‌های مشتری");
        }
    }

    /// <summary>
    /// ایجاد مشتری جدید
    /// </summary>
    /// <param name="command">دستور ایجاد مشتری</param>
    /// <returns>شناسه مشتری ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<object> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var customerId = await _mediator.Send(command);
            return Created(customerId, "مشتری با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد مشتری");
        }
    }

    /// <summary>
    /// به‌روزرسانی مشتری
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<object> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("مشتری با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی مشتری");
        }
    }

    /// <summary>
    /// تغییر وضعیت مشتری
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <param name="command">دستور تغییر وضعیت</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    [HttpPatch("{id}/toggle-status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<object> ToggleCustomerStatus(Guid id, [FromBody] ToggleCustomerStatusCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success(result, $"وضعیت مشتری با موفقیت به {(command.IsActive ? "فعال" : "غیرفعال")} تغییر یافت");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر وضعیت مشتری");
        }
    }

    /// <summary>
    /// حذف مشتری
    /// </summary>
    /// <param name="id">شناسه مشتری</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<object> DeleteCustomer(Guid id)
    {
        try
        {
            var command = new DeleteCustomerCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("مشتری با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف مشتری");
        }
    }
}
