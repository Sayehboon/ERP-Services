using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;

namespace Dinawin.Erp.Application.Features.HR.Employees.Commands.DeleteEmployee;

/// <summary>
/// پردازشگر دستور حذف کارمند
/// </summary>
public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public DeleteEmployeeCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>وظیفه</returns>
    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

        if (employee == null)
        {
            throw new InvalidOperationException($"کارمند با شناسه {request.Id} یافت نشد");
        }

        // بررسی وابستگی‌ها قبل از حذف
        // بررسی وجود فروش‌های مرتبط
        var hasSalesOrders = await _context.SalesOrders
            .AnyAsync(so => so.SalesPersonId == request.Id, cancellationToken);

        if (hasSalesOrders)
        {
            throw new InvalidOperationException("امکان حذف کارمند به دلیل وجود فروش‌های مرتبط وجود ندارد");
        }

        // بررسی وجود فعالیت‌های CRM مرتبط
        var hasCrmActivities = await _context.Activities
            .AnyAsync(a => a.AssignedToUserId == request.Id, cancellationToken);

        if (hasCrmActivities)
        {
            throw new InvalidOperationException("امکان حذف کارمند به دلیل وجود فعالیت‌های CRM مرتبط وجود ندارد");
        }

        // بررسی وجود پروژه‌های مرتبط
        var hasProjects = await _context.Projects
            .AnyAsync(p => p.ManagerId == request.Id, cancellationToken);

        if (hasProjects)
        {
            throw new InvalidOperationException("امکان حذف کارمند به دلیل وجود پروژه‌های مرتبط وجود ندارد");
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync(cancellationToken);
    }
}