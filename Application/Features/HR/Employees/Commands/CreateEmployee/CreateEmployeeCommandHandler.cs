using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;
using Dinawin.Erp.Domain.Entities.Users;

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
        // بررسی تکراری نبودن شماره پرسنلی (در صورت ارسال)
        var existingEmployee = string.IsNullOrWhiteSpace(request.EmployeeCode)
            ? null
            : await _context.Employees.FirstOrDefaultAsync(e => e.PersonnelNumber == request.EmployeeCode, cancellationToken);

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

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            Name = request.FirstName ?? string.Empty,
            LastName = request.LastName ?? string.Empty,
            Email = request.Email,
            Phone = request.Phone,
            DepartmentId = request.DepartmentId,
            Position = request.Position,
            EmploymentDate = request.HireDate ?? DateTime.UtcNow,
            IsActive = request.IsActive,
            Address = request.Address,
            NationalCode = request.NationalId,
            PersonnelNumber = request.EmployeeCode,
            Status = "active",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Employees.Add(employee);
        await _context.SaveChangesAsync(cancellationToken);

        return employee.Id;
    }
}
