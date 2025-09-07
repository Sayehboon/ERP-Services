using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;

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

        // بررسی تکراری نبودن کد کارمند (به جز خود کارمند)
        var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeCode == request.EmployeeCode && e.Id != request.Id, cancellationToken);

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

        // بررسی وجود شرکت
        if (request.CompanyId.HasValue)
        {
            var companyExists = await _context.Companies
                .AnyAsync(c => c.Id == request.CompanyId.Value, cancellationToken);

            if (!companyExists)
            {
                throw new InvalidOperationException($"شرکت با شناسه {request.CompanyId} یافت نشد");
            }
        }

        // به‌روزرسانی اطلاعات
        employee.EmployeeCode = request.EmployeeCode;
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;
        employee.Phone = request.Phone;
        employee.DepartmentId = request.DepartmentId;
        employee.CompanyId = request.CompanyId;
        employee.Position = request.Position;
        employee.HireDate = request.HireDate ?? employee.HireDate;
        employee.Salary = request.Salary;
        employee.IsActive = request.IsActive;
        employee.Address = request.Address;
        employee.BirthDate = request.BirthDate;
        employee.Gender = request.Gender;
        employee.NationalId = request.NationalId;
        employee.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}