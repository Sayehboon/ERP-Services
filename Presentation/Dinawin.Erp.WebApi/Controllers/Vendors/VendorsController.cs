using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.Vendors.Queries.GetAllVendors;
using Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorById;
using Dinawin.Erp.Application.Features.Vendors.Queries.SearchVendors;
using Dinawin.Erp.Application.Features.Vendors.Queries.GetActiveVendors;
using Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorProducts;
using Dinawin.Erp.Application.Features.Vendors.Queries.GetVendorOrders;
using Dinawin.Erp.Application.Features.Vendors.Commands.CreateVendor;
using Dinawin.Erp.Application.Features.Vendors.Commands.UpdateVendor;
using Dinawin.Erp.Application.Features.Vendors.Commands.DeleteVendor;
using Dinawin.Erp.Application.Features.Vendors.Commands.ToggleVendorStatus;

namespace Dinawin.Erp.WebApi.Controllers.Vendors;

/// <summary>
/// کنترلر مدیریت تامین‌کنندگان
/// </summary>
[Route("api/[controller]")]
public class VendorsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر تامین‌کنندگان
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public VendorsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام تامین‌کنندگان
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="vendorType">نوع تامین‌کننده</param>
    /// <param name="city">شهر</param>
    /// <param name="province">استان</param>
    /// <param name="country">کشور</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="minCreditLimit">حداقل اعتبار</param>
    /// <param name="maxCreditLimit">حداکثر اعتبار</param>
    /// <param name="preferredCurrency">ارز ترجیحی</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام تامین‌کنندگان</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VendorDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllVendors(
        [FromQuery] string? searchTerm = null,
        [FromQuery] string? vendorType = null,
        [FromQuery] string? city = null,
        [FromQuery] string? province = null,
        [FromQuery] string? country = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] decimal? minCreditLimit = null,
        [FromQuery] decimal? maxCreditLimit = null,
        [FromQuery] string? preferredCurrency = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllVendorsQuery
            {
                SearchTerm = searchTerm,
                VendorType = vendorType,
                City = city,
                Province = province,
                Country = country,
                IsActive = isActive,
                MinCreditLimit = minCreditLimit,
                MaxCreditLimit = maxCreditLimit,
                PreferredCurrency = preferredCurrency,
                Page = page,
                PageSize = pageSize
            };

            var vendors = await _mediator.Send(query);
            return Success(vendors);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست تامین‌کنندگان");
        }
    }

    /// <summary>
    /// دریافت تامین‌کننده بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <returns>اطلاعات تامین‌کننده</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(VendorDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetVendor(Guid id)
    {
        try
        {
            var query = new GetVendorByIdQuery { Id = id };
            var vendor = await _mediator.Send(query);
            
            if (vendor == null)
            {
                return NotFound($"تامین‌کننده با شناسه {id} یافت نشد");
            }
            
            return Success(vendor);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات تامین‌کننده");
        }
    }

    /// <summary>
    /// جستجوی تامین‌کنندگان
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>لیست تامین‌کنندگان مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<VendorSearchDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> SearchVendors(
        [FromQuery] string searchTerm,
        [FromQuery] string? vendorType = null,
        [FromQuery] string? city = null,
        [FromQuery] string? province = null,
        [FromQuery] string? country = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int maxResults = 20)
    {
        try
        {
            var query = new SearchVendorsQuery
            {
                SearchTerm = searchTerm,
                VendorType = vendorType,
                City = city,
                Province = province,
                Country = country,
                IsActive = isActive,
                MaxResults = maxResults
            };

            var vendors = await _mediator.Send(query);
            return Success(vendors);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در جستجوی تامین‌کنندگان");
        }
    }

    /// <summary>
    /// دریافت تامین‌کنندگان فعال
    /// </summary>
    /// <returns>لیست تامین‌کنندگان فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveVendors()
    {
        try
        {
            var query = new GetActiveVendorsQuery();
            var vendors = await _mediator.Send(query);
            return Success(vendors);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تامین‌کنندگان فعال");
        }
    }

    /// <summary>
    /// دریافت تاریخچه سفارشات تامین‌کننده
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <returns>تاریخچه سفارشات</returns>
    [HttpGet("{id}/orders")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetVendorOrders(Guid id)
    {
        try
        {
            var query = new GetVendorOrdersQuery { VendorId = id };
            var orders = await _mediator.Send(query);
            return Success(orders);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت تاریخچه سفارشات تامین‌کننده");
        }
    }

    /// <summary>
    /// دریافت محصولات تامین‌کننده
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <returns>لیست محصولات</returns>
    [HttpGet("{id}/products")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetVendorProducts(Guid id)
    {
        try
        {
            var query = new GetVendorProductsQuery { VendorId = id };
            var products = await _mediator.Send(query);
            return Success(products);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت محصولات تامین‌کننده");
        }
    }

    /// <summary>
    /// ایجاد تامین‌کننده جدید
    /// </summary>
    /// <param name="command">دستور ایجاد تامین‌کننده</param>
    /// <returns>شناسه تامین‌کننده ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateVendor([FromBody] CreateVendorCommand command)
    {
        try
        {
            var vendorId = await _mediator.Send(command);
            return Created(vendorId, "تامین‌کننده با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد تامین‌کننده");
        }
    }

    /// <summary>
    /// به‌روزرسانی تامین‌کننده
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateVendor(Guid id, [FromBody] UpdateVendorCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("تامین‌کننده با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی تامین‌کننده");
        }
    }

    /// <summary>
    /// تغییر وضعیت تامین‌کننده
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <param name="command">دستور تغییر وضعیت</param>
    /// <returns>نتیجه تغییر وضعیت</returns>
    [HttpPatch("{id}/toggle-status")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> ToggleVendorStatus(Guid id, [FromBody] ToggleVendorStatusCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success(result, $"وضعیت تامین‌کننده با موفقیت به {(command.IsActive ? "فعال" : "غیرفعال")} تغییر یافت");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در تغییر وضعیت تامین‌کننده");
        }
    }

    /// <summary>
    /// حذف تامین‌کننده
    /// </summary>
    /// <param name="id">شناسه تامین‌کننده</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteVendor(Guid id)
    {
        try
        {
            var command = new DeleteVendorCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("تامین‌کننده با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف تامین‌کننده");
        }
    }
}
