using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.HR.Departments.Queries.GetAllDepartments;
using Dinawin.Erp.Application.Features.HR.Departments.Queries.GetDepartmentById;
using Dinawin.Erp.Application.Features.HR.Departments.Commands.CreateDepartment;
using Dinawin.Erp.Application.Features.HR.Departments.Commands.UpdateDepartment;
using Dinawin.Erp.Application.Features.HR.Departments.Commands.DeleteDepartment;

namespace Dinawin.Erp.WebApi.Controllers.HR;

/// <summary>
/// کنترلر مدیریت بخش‌ها
/// </summary>
[Route("api/[controller]")]
public class DepartmentsController : BaseController
{
    /// <summary>
    /// سازنده کنترلر بخش‌ها
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public DepartmentsController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام بخش‌ها
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <param name="parentDepartmentId">شناسه بخش والد</param>
    /// <param name="managerId">شناسه مدیر</param>
    /// <param name="companyId">شناسه شرکت</param>
    /// <param name="departmentType">نوع بخش</param>
    /// <param name="level">سطح بخش</param>
    /// <param name="isActive">وضعیت فعال بودن</param>
    /// <param name="page">شماره صفحه</param>
    /// <param name="pageSize">تعداد آیتم در هر صفحه</param>
    /// <returns>لیست تمام بخش‌ها</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllDepartments(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? parentDepartmentId = null,
        [FromQuery] Guid? managerId = null,
        [FromQuery] Guid? companyId = null,
        [FromQuery] string? departmentType = null,
        [FromQuery] int? level = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllDepartmentsQuery
            {
                SearchTerm = searchTerm,
                ParentDepartmentId = parentDepartmentId,
                ManagerId = managerId,
                CompanyId = companyId,
                DepartmentType = departmentType,
                Level = level,
                IsActive = isActive,
                Page = page,
                PageSize = pageSize
            };

            var departments = await _mediator.Send(query);
            return Success(departments);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست بخش‌ها");
        }
    }

    /// <summary>
    /// دریافت بخش بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه بخش</param>
    /// <returns>اطلاعات بخش</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DepartmentDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetDepartment(Guid id)
    {
        try
        {
            var query = new GetDepartmentByIdQuery { Id = id };
            var department = await _mediator.Send(query);
            
            if (department == null)
            {
                return NotFound($"بخش با شناسه {id} یافت نشد");
            }
            
            return Success(department);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات بخش");
        }
    }

    /// <summary>
    /// دریافت بخش‌های فرزند
    /// </summary>
    /// <param name="parentId">شناسه بخش والد</param>
    /// <returns>لیست بخش‌های فرزند</returns>
    [HttpGet("children/{parentId}")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetChildDepartments(Guid parentId)
    {
        try
        {
            // TODO: پیاده‌سازی GetChildDepartmentsQuery
            var departments = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    Name = "فروش داخلی", 
                    Code = "SALES_INT",
                    ParentId = parentId
                }
            };
            return Success(departments);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت بخش‌های فرزند");
        }
    }

    /// <summary>
    /// دریافت بخش‌های فعال
    /// </summary>
    /// <returns>لیست بخش‌های فعال</returns>
    [HttpGet("active")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetActiveDepartments()
    {
        try
        {
            // TODO: پیاده‌سازی GetActiveDepartmentsQuery
            var departments = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    Name = "فروش", 
                    Code = "SALES",
                    IsActive = true
                }
            };
            return Success(departments);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت بخش‌های فعال");
        }
    }

    /// <summary>
    /// ایجاد بخش جدید
    /// </summary>
    /// <param name="command">دستور ایجاد بخش</param>
    /// <returns>شناسه بخش ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
    {
        try
        {
            var departmentId = await _mediator.Send(command);
            return Created(departmentId, "بخش با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد بخش");
        }
    }

    /// <summary>
    /// به‌روزرسانی بخش
    /// </summary>
    /// <param name="id">شناسه بخش</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateDepartment(Guid id, [FromBody] UpdateDepartmentCommand command)
    {
        try
        {
            command.Id = id;
            var departmentId = await _mediator.Send(command);
            return Success(departmentId, "بخش با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی بخش");
        }
    }

    /// <summary>
    /// حذف بخش
    /// </summary>
    /// <param name="id">شناسه بخش</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteDepartment(Guid id)
    {
        try
        {
            var command = new DeleteDepartmentCommand { Id = id };
            var result = await _mediator.Send(command);
            return Success(result, "بخش با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف بخش");
        }
    }
}
