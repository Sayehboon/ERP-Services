using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;
using Dinawin.Erp.Infrastructure.Data.Entities.HR;

namespace Dinawin.Erp.Application.Features.HR.Employees.Commands.CreateEmployee;

/// <summary>
/// پردازشگر دستور ایجاد کارمند جدید
/// </summary>
public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public CreateEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>شناسه کارمند ایجاد شده</returns>
    public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        // بررسی تکراری نبودن کد کارمند
        var existingEmployee = await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeCode == request.EmployeeCode, cancellationToken);

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

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            EmployeeCode = request.EmployeeCode,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            DepartmentId = request.DepartmentId,
            CompanyId = request.CompanyId,
            Position = request.Position,
            HireDate = request.HireDate ?? DateTime.UtcNow,
            Salary = request.Salary,
            IsActive = request.IsActive,
            IsLocked = false,
            Address = request.Address,
            BirthDate = request.BirthDate,
            Gender = request.Gender,
            NationalId = request.NationalId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
