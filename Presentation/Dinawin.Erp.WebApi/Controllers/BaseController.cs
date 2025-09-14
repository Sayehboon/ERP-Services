using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dinawin.Erp.WebApi.Controllers;

/// <summary>
/// کلاس پایه برای تمام کنترلرها
/// Base controller class for all controllers
/// </summary>
[ApiController]
[Produces("application/json")]
public abstract class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;

    /// <summary>
    /// سازنده کلاس پایه
    /// Base controller constructor
    /// </summary>
    /// <param name="mediator">واسط میدیاتور</param>
    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// ایجاد پاسخ موفقیت‌آمیز
    /// Creates a successful response
    /// </summary>
    /// <typeparam name="T">نوع داده</typeparam>
    /// <param name="data">داده‌ها</param>
    /// <param name="message">پیام</param>
    /// <returns>پاسخ موفقیت‌آمیز</returns>
    protected ActionResult<T> Success<T>(T data, string message = null)
    {
        var response = new
        {
            success = true,
            data = data,
            message = message ?? "عملیات با موفقیت انجام شد",
            timestamp = DateTime.UtcNow
        };
        return Ok(response);
    }

    /// <summary>
    /// ایجاد پاسخ موفقیت‌آمیز بدون داده
    /// Creates a successful response without data
    /// </summary>
    /// <param name="message">پیام</param>
    /// <returns>پاسخ موفقیت‌آمیز</returns>
    protected ActionResult Success(string message = null)
    {
        var response = new
        {
            success = true,
            message = message ?? "عملیات با موفقیت انجام شد",
            timestamp = DateTime.UtcNow
        };
        return Ok(response);
    }

    /// <summary>
    /// ایجاد پاسخ خطا
    /// Creates an error response
    /// </summary>
    /// <param name="message">پیام خطا</param>
    /// <param name="statusCode">کد وضعیت HTTP</param>
    /// <returns>پاسخ خطا</returns>
    protected ActionResult Error(string message, int statusCode = 400)
    {
        var response = new
        {
            success = false,
            message = message,
            timestamp = DateTime.UtcNow
        };

        return statusCode switch
        {
            400 => BadRequest(response),
            401 => Unauthorized(response),
            403 => Forbid(),
            404 => NotFound(response),
            500 => StatusCode(500, response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// ایجاد پاسخ خطا با جزئیات
    /// Creates an error response with details
    /// </summary>
    /// <param name="message">پیام خطا</param>
    /// <param name="details">جزئیات خطا</param>
    /// <param name="statusCode">کد وضعیت HTTP</param>
    /// <returns>پاسخ خطا</returns>
    protected ActionResult Error(string message, object details, int statusCode = 400)
    {
        var response = new
        {
            success = false,
            message = message,
            details = details,
            timestamp = DateTime.UtcNow
        };

        return statusCode switch
        {
            400 => BadRequest(response),
            401 => Unauthorized(response),
            403 => Forbid(),
            404 => NotFound(response),
            500 => StatusCode(500, response),
            _ => BadRequest(response)
        };
    }

    /// <summary>
    /// ایجاد پاسخ لیست با اطلاعات صفحه‌بندی
    /// Creates a paginated list response
    /// </summary>
    /// <typeparam name="T">نوع داده</typeparam>
    /// <param name="data">داده‌ها</param>
    /// <param name="pageNumber">شماره صفحه</param>
    /// <param name="pageSize">اندازه صفحه</param>
    /// <param name="totalCount">تعداد کل</param>
    /// <returns>پاسخ لیست صفحه‌بندی شده</returns>
    protected ActionResult<PaginatedResponse<T>> Paginated<T>(
        IEnumerable<T> data, 
        int pageNumber, 
        int pageSize, 
        int totalCount)
    {
        var response = new PaginatedResponse<T>
        {
            Data = data,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling((double)totalCount / pageSize),
            HasPreviousPage = pageNumber > 1,
            HasNextPage = pageNumber < (int)Math.Ceiling((double)totalCount / pageSize)
        };

        return Ok(response);
    }

    /// <summary>
    /// ایجاد پاسخ ایجاد شده
    /// Creates a created response
    /// </summary>
    /// <typeparam name="T">نوع داده</typeparam>
    /// <param name="id">شناسه ایجاد شده</param>
    /// <param name="data">داده‌ها</param>
    /// <param name="actionName">نام اکشن</param>
    /// <returns>پاسخ ایجاد شده</returns>
    protected ActionResult<T> Created<T>(Guid id, T data, string actionName = "Get")
    {
        var response = new
        {
            success = true,
            data = data,
            message = "رکورد با موفقیت ایجاد شد",
            timestamp = DateTime.UtcNow
        };

        return CreatedAtAction(actionName, new { id }, response);
    }

    /// <summary>
    /// ایجاد پاسخ ایجاد شده با شناسه
    /// Creates a created response with ID
    /// </summary>
    /// <param name="id">شناسه ایجاد شده</param>
    /// <param name="message">پیام</param>
    /// <param name="actionName">نام اکشن</param>
    /// <returns>پاسخ ایجاد شده</returns>
    protected ActionResult<Guid> Created(Guid id, string message, string actionName = "Get")
    {
        var response = new
        {
            success = true,
            data = id,
            message = message,
            timestamp = DateTime.UtcNow
        };

        return CreatedAtAction(actionName, new { id }, response);
    }

    /// <summary>
    /// ایجاد پاسخ حذف شده
    /// Creates a deleted response
    /// </summary>
    /// <param name="message">پیام</param>
    /// <returns>پاسخ حذف شده</returns>
    protected ActionResult Deleted(string message = null)
    {
        var response = new
        {
            success = true,
            message = message ?? "رکورد با موفقیت حذف شد",
            timestamp = DateTime.UtcNow
        };

        return Ok(response);
    }

    /// <summary>
    /// ایجاد پاسخ به‌روزرسانی شده
    /// Creates an updated response
    /// </summary>
    /// <param name="message">پیام</param>
    /// <returns>پاسخ به‌روزرسانی شده</returns>
    protected ActionResult Updated(string message = null)
    {
        var response = new
        {
            success = true,
            message = message ?? "رکورد با موفقیت به‌روزرسانی شد",
            timestamp = DateTime.UtcNow
        };

        return Ok(response);
    }

    /// <summary>
    /// مدیریت خطاهای عمومی
    /// Handles general errors
    /// </summary>
    /// <param name="ex">استثنا</param>
    /// <returns>پاسخ خطا</returns>
    protected ActionResult HandleError(Exception ex)
    {
        // Log the exception here if needed
        return Error("خطای داخلی سرور", 500);
    }

    /// <summary>
    /// مدیریت خطاهای عمومی با پیام سفارشی
    /// Handles general errors with custom message
    /// </summary>
    /// <param name="ex">استثنا</param>
    /// <param name="customMessage">پیام خطای سفارشی</param>
    /// <param name="statusCode">کد وضعیت HTTP</param>
    /// <returns>پاسخ خطا</returns>
    protected ActionResult HandleError(Exception ex, string customMessage, int statusCode = 500)
    {
        // Log the exception here if needed
        return Error(customMessage, statusCode);
    }

    /// <summary>
    /// اعتبارسنجی شناسه
    /// Validates ID
    /// </summary>
    /// <param name="id">شناسه</param>
    /// <returns>نتیجه اعتبارسنجی</returns>
    protected bool IsValidId(Guid id)
    {
        return id != Guid.Empty;
    }

    /// <summary>
    /// اعتبارسنجی شناسه و بازگشت خطا در صورت نامعتبر بودن
    /// Validates ID and returns error if invalid
    /// </summary>
    /// <param name="id">شناسه</param>
    /// <returns>نتیجه اعتبارسنجی</returns>
    protected ActionResult ValidateId(Guid id)
    {
        if (!IsValidId(id))
        {
            return Error("شناسه نامعتبر است", 400);
        }
        return null;
    }
}

/// <summary>
/// کلاس پاسخ صفحه‌بندی شده
/// Paginated response class
/// </summary>
/// <typeparam name="T">نوع داده</typeparam>
public class PaginatedResponse<T>
{
    public IEnumerable<T> Data { get; set; } = new List<T>();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage { get; set; }
    public bool HasNextPage { get; set; }
}

