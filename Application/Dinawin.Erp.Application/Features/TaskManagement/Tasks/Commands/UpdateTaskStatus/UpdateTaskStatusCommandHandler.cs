using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskStatus;

/// <summary>
/// پردازشگر دستور تغییر وضعیت وظیفه
/// </summary>
public class UpdateTaskStatusCommandHandler : IRequestHandler<UpdateTaskStatusCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public UpdateTaskStatusCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>وظیفه</returns>
    public async Task Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new InvalidOperationException($"وظیفه با شناسه {request.Id} یافت نشد");
        }

        // تغییر وضعیت
        task.Status = request.Status;

        // اگر وضعیت به تکمیل شده تغییر یافت، تاریخ تکمیل را تنظیم کنید
        if (request.Status == "Completed")
        {
            task.CompletedDate = DateTime.UtcNow;
            task.Progress = 100; // پیشرفت را به 100% تنظیم کنید
        }
        // اگر وضعیت از تکمیل شده تغییر یافت، تاریخ تکمیل را پاک کنید
        else if (task.Status == "Completed" && request.Status != "Completed")
        {
            task.CompletedDate = null;
        }

        task.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
