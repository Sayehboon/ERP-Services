using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetAllCompanies;
using Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetCompanyById;
using Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.CreateCompany;
using Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.UpdateCompany;
using Dinawin.Erp.Application.Features.SystemManagement.Companies.Commands.DeleteCompany;
using CompanyDto = Dinawin.Erp.Application.Features.SystemManagement.Companies.Queries.GetAllCompanies.CompanyDto;

namespace Dinawin.Erp.WebApi.Controllers.SystemManagement;

/// <summary>
/// کنترلر مدیریت شرکت‌ها
/// </summary>
[Route("api/[controller]")]
public class CompaniesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر شرکت‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public CompaniesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام شرکت‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام شرکت‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAllCompanies(
        [FromQuery] string searchTerm = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllCompaniesQuery
            {
                SearchTerm = searchTerm,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var companies = await _mediator.Send(query);
            return Success(companies);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست شرکت‌ها");
        }
    }

    /// <summary>
    /// دریافت شرکت بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه شرکت</param>
    /// <returns>اطلاعات شرکت</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CompanyDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetCompany(Guid id)
    {
        try
        {
            var query = new GetCompanyByIdQuery { Id = id };
            var company = await _mediator.Send(query);
            
            if (company == null)
            {
                return NotFound($"شرکت با شناسه {id} یافت نشد");
            }
            
            return Success(company);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات شرکت");
        }
    }

    /// <summary>
    /// دریافت شرکت‌های فعال
    /// </summary>
    /// <returns>لیست شرکت‌های فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetActiveCompanies()
    {
        try
        {
            var query = new GetAllCompaniesQuery { IsActive = true };
            var companies = await _mediator.Send(query);
            return Success(companies);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت شرکت‌های فعال");
        }
    }

    /// <summary>
    /// ایجاد شرکت جدید
    /// </summary>
    /// <param name="command">دستور ایجاد شرکت</param>
    /// <returns>شناسه شرکت ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Guid>> CreateCompany([FromBody] CreateCompanyCommand command)
    {
        try
        {
            var companyId = await _mediator.Send(command);
            return Created(companyId, "شرکت با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد شرکت");
        }
    }

    /// <summary>
    /// به‌روزرسانی شرکت
    /// </summary>
    /// <param name="id">شناسه شرکت</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateCompany(Guid id, [FromBody] UpdateCompanyCommand command)
    {
        try
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Success("شرکت با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی شرکت");
        }
    }

    /// <summary>
    /// حذف شرکت
    /// </summary>
    /// <param name="id">شناسه شرکت</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteCompany(Guid id)
    {
        try
        {
            var command = new DeleteCompanyCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success("شرکت با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف شرکت");
        }
    }
}
