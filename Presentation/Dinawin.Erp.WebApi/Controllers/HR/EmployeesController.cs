using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetAllEmployees;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeesByDepartment;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.SearchEmployees;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.CreateEmployee;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.UpdateEmployee;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.DeleteEmployee;

namespace Dinawin.Erp.WebApi.Controllers.HR;

/// <summary>
/// کنترلر مدیریت کارمندان
/// </summary>
[Route("api/[controller]")]
public class EmployeesController : BaseController
{
    /// <summary>
    /// سازنده کنترلر کارمندان
    /// </summary>
    /// <param name="mediator">مدیاتور برای ارسال درخواست‌ها</param>
    public EmployeesController(IMediator mediator) : base(mediator)
    {
    }

    /// <summary>
    /// دریافت تمام کارمندان
    /// </summary>
    /// <returns>لیست تمام کارمندان</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetAllEmployees(
        [FromQuery] string? searchTerm = null,
        [FromQuery] Guid? departmentId = null,
        [FromQuery] Guid? roleId = null,
        [FromQuery] Guid? companyId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] bool? isLocked = null,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var query = new GetAllEmployeesQuery
            {
                SearchTerm = searchTerm,
                DepartmentId = departmentId,
                RoleId = roleId,
                CompanyId = companyId,
                IsActive = isActive,
                IsLocked = isLocked,
                Page = page,
                PageSize = pageSize
            };

            var employees = await _mediator.Send(query);
            return Success(employees);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت لیست کارمندان");
        }
    }

    /// <summary>
    /// دریافت کارمند بر اساس شناسه
    /// </summary>
    /// <param name="id">شناسه کارمند</param>
    /// <returns>اطلاعات کارمند</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EmployeeDto), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> GetEmployee(Guid id)
    {
        try
        {
            var query = new GetEmployeeByIdQuery { Id = id };
            var employee = await _mediator.Send(query);
            
            if (employee == null)
            {
                return NotFound($"کارمند با شناسه {id} یافت نشد");
            }
            
            return Success(employee);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت اطلاعات کارمند");
        }
    }

    /// <summary>
    /// دریافت کارمندان یک بخش
    /// </summary>
    /// <param name="departmentId">شناسه بخش</param>
    /// <param name="isActive">آیا فقط کارمندان فعال</param>
    /// <param name="maxResults">حداکثر تعداد نتایج</param>
    /// <returns>لیست کارمندان بخش</returns>
    [HttpGet("by-department/{departmentId}")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetEmployeesByDepartment(
        Guid departmentId,
        [FromQuery] bool? isActive = null,
        [FromQuery] int? maxResults = null)
    {
        try
        {
            var query = new GetEmployeesByDepartmentQuery
            {
                DepartmentId = departmentId,
                IsActive = isActive,
                MaxResults = maxResults
            };

            var employees = await _mediator.Send(query);
            return Success(employees);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت کارمندان بخش");
        }
    }

    /// <summary>
    /// جستجوی کارمندان
    /// </summary>
    /// <param name="searchTerm">عبارت جستجو</param>
    /// <returns>لیست کارمندان مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> SearchEmployees([FromQuery] string searchTerm)
    {
        try
        {
            // TODO: پیاده‌سازی SearchEmployeesQuery
            var employees = new List<object>
            {
                new { 
                    Id = Guid.NewGuid(), 
                    EmployeeCode = "EMP001",
                    FirstName = "احمد",
                    LastName = "محمدی"
                }
            };
            return Success(employees);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در جستجوی کارمندان");
        }
    }

    /// <summary>
    /// ایجاد کارمند جدید
    /// </summary>
    /// <param name="command">دستور ایجاد کارمند</param>
    /// <returns>شناسه کارمند ایجاد شده</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> CreateEmployee([FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی CreateEmployeeCommand
            var employeeId = Guid.NewGuid();
            return Created(employeeId, "کارمند با موفقیت ایجاد شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در ایجاد کارمند");
        }
    }

    /// <summary>
    /// به‌روزرسانی کارمند
    /// </summary>
    /// <param name="id">شناسه کارمند</param>
    /// <param name="command">دستور به‌روزرسانی</param>
    /// <returns>نتیجه به‌روزرسانی</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> UpdateEmployee(Guid id, [FromBody] object command)
    {
        try
        {
            // TODO: پیاده‌سازی UpdateEmployeeCommand
            return Success("کارمند با موفقیت به‌روزرسانی شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در به‌روزرسانی کارمند");
        }
    }

    /// <summary>
    /// حذف کارمند
    /// </summary>
    /// <param name="id">شناسه کارمند</param>
    /// <returns>نتیجه حذف</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult> DeleteEmployee(Guid id)
    {
        try
        {
            // TODO: پیاده‌سازی DeleteEmployeeCommand
            return Success("کارمند با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف کارمند");
        }
    }
}
