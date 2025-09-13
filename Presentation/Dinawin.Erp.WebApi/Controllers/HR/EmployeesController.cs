using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dinawin.Erp.WebApi.Controllers;
using GetAllEmployees = Dinawin.Erp.Application.Features.HR.Employees.Queries.GetAllEmployees;
using GetEmployeeById = Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeesByDepartment;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.SearchEmployees;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeAttendance;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeSalary;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.CreateEmployee;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.UpdateEmployee;
using Dinawin.Erp.Application.Features.HR.Employees.Commands.DeleteEmployee;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetEmployeeById;
using Dinawin.Erp.Application.Features.HR.Employees.Queries.GetAllEmployees;

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
    [ProducesResponseType(typeof(IEnumerable<GetAllEmployees.EmployeeDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetAllEmployees(
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
    [ProducesResponseType(typeof(GetEmployeeById.EmployeeDto), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetEmployee(Guid id)
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
    [ProducesResponseType(typeof(IEnumerable<GetAllEmployees.EmployeeDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> GetEmployeesByDepartment(
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
    /// <param name="departmentId">شناسه بخش</param>
    /// <param name="companyId">شناسه شرکت</param>
    /// <param name="isActive">آیا فقط کارمندان فعال</param>
    /// <param name="maxResults">حداکثر تعداد نتایج</param>
    /// <returns>لیست کارمندان مطابق جستجو</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(IEnumerable<EmployeeSearchDto>), 200)]
    [ProducesResponseType(400)]
    public async Task<object> SearchEmployees(
        [FromQuery] string searchTerm,
        [FromQuery] Guid? departmentId = null,
        [FromQuery] Guid? companyId = null,
        [FromQuery] bool? isActive = null,
        [FromQuery] int maxResults = 20)
    {
        try
        {
            var query = new SearchEmployeesQuery
            {
                SearchTerm = searchTerm,
                DepartmentId = departmentId,
                CompanyId = companyId,
                IsActive = isActive,
                MaxResults = maxResults
            };

            var employees = await _mediator.Send(query);
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
    public async Task<object> CreateEmployee([FromBody] CreateEmployeeCommand command)
    {
        try
        {
            var employeeId = await _mediator.Send(command);
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
    public async Task<object> UpdateEmployee(Guid id, [FromBody] UpdateEmployeeCommand command)
    {
        try
        {
            command.Id = id;
            await _mediator.Send(command);
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
    public async Task<object> DeleteEmployee(Guid id)
    {
        try
        {
            var command = new DeleteEmployeeCommand { Id = id };
            await _mediator.Send(command);
            return Success("کارمند با موفقیت حذف شد");
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در حذف کارمند");
        }
    }

    /// <summary>
    /// دریافت حضور و غیاب کارمند
    /// </summary>
    /// <param name="id">شناسه کارمند</param>
    /// <param name="fromDate">تاریخ شروع (اختیاری)</param>
    /// <param name="toDate">تاریخ پایان (اختیاری)</param>
    /// <param name="attendanceType">نوع حضور (اختیاری)</param>
    /// <param name="status">وضعیت حضور (اختیاری)</param>
    /// <param name="maxResults">تعداد نتایج حداکثر</param>
    /// <returns>لیست حضور و غیاب کارمند</returns>
    [HttpGet("{id}/attendance")]
    [ProducesResponseType(typeof(IEnumerable<object>), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetEmployeeAttendance(
        Guid id,
        [FromQuery] DateTime? fromDate = null,
        [FromQuery] DateTime? toDate = null,
        [FromQuery] string? attendanceType = null,
        [FromQuery] string? status = null,
        [FromQuery] int maxResults = 100)
    {
        try
        {
            var query = new GetEmployeeAttendanceQuery
            {
                EmployeeId = id,
                FromDate = fromDate,
                ToDate = toDate,
                AttendanceType = attendanceType,
                Status = status,
                MaxResults = maxResults
            };

            var attendance = await _mediator.Send(query);
            return Success(attendance);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حضور و غیاب کارمند");
        }
    }

    /// <summary>
    /// دریافت حقوق کارمند
    /// </summary>
    /// <param name="id">شناسه کارمند</param>
    /// <param name="year">سال (اختیاری)</param>
    /// <param name="month">ماه (اختیاری)</param>
    /// <param name="includeDetails">آیا شامل جزئیات باشد</param>
    /// <returns>اطلاعات حقوق کارمند</returns>
    [HttpGet("{id}/salary")]
    [ProducesResponseType(typeof(object), 200)]
    [ProducesResponseType(404)]
    public async Task<object> GetEmployeeSalary(
        Guid id,
        [FromQuery] int? year = null,
        [FromQuery] int? month = null,
        [FromQuery] bool includeDetails = true)
    {
        try
        {
            var query = new GetEmployeeSalaryQuery
            {
                EmployeeId = id,
                Year = year,
                Month = month,
                IncludeDetails = includeDetails
            };

            var salary = await _mediator.Send(query);
            
            if (salary == null)
            {
                return NotFound("اطلاعات حقوق برای این کارمند یافت نشد");
            }

            return Success(salary);
        }
        catch (Exception ex)
        {
            return HandleError(ex, "خطا در دریافت حقوق کارمند");
        }
    }
}
