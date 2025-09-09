using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Commands.UpdateEmployee;

/// <summary>
/// پردازشگر دستور به‌روزرسانی کارمند
/// </summary>
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public UpdateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>وظیفه</returns>
    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (employee == null)
        {
            throw new InvalidOperationException($"کارمند با شناسه {request.Id} یافت نشد");
        }

        // بررسی تکراری نبودن شماره پرسنلی (به جز خود کارمند)
        var existingEmployee = string.IsNullOrWhiteSpace(request.EmployeeCode)
            ? null
            : await _context.Employees.FirstOrDefaultAsync(e => e.PersonnelNumber == request.EmployeeCode && e.Id != request.Id, cancellationToken);

        if (existingEmployee != null)
        {
            throw new InvalidOperationException($"کارمند با کد {request.EmployeeCode} قبلاً وجود دارد");
        }

        // بررسی وجود بخش
        if (request.DepartmentId.HasValue)
        {
            var departmentExists = await _context.Departments
                .AnyAsync(d => d.Id == request.DepartmentId.Value, cancellationToken);

            if (!departmentExists)
            {
                throw new InvalidOperationException($"بخش با شناسه {request.DepartmentId} یافت نشد");
            }
        }

        // توجه: موجودیت شرکت در مدل کارمند وجود ندارد؛ از اعتبارسنجی شرکت صرف‌نظر شد

        // به‌روزرسانی اطلاعات
        employee.PersonnelNumber = request.EmployeeCode;
        employee.Name = request.FirstName ?? employee.Name;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.Phone = request.Phone;
        employee.DepartmentId = request.DepartmentId;
        employee.Position = request.Position;
        employee.EmploymentDate = request.HireDate ?? employee.EmploymentDate;
        employee.IsActive = request.IsActive;
        employee.Address = request.Address;
        employee.NationalCode = request.NationalId;
        employee.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}