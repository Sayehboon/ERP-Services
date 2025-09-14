using Dinawin.Erp.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTaskProgress;

/// <summary>
/// پردازشگر دستور به‌روزرسانی پیشرفت وظیفه
/// </summary>
public class UpdateTaskProgressCommandHandler : IRequestHandler<UpdateTaskProgressCommand>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده پردازشگر
    /// </summary>
    /// <param name="context">کانتکست پایگاه داده</param>
    public UpdateTaskProgressCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// پردازش دستور
    /// </summary>
    /// <param name="request">درخواست</param>
    /// <param name="cancellationToken">توکن لغو</param>
    /// <returns>وظیفه</returns>
    public async Task Handle(UpdateTaskProgressCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks
            .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
        {
            throw new InvalidOperationException($"وظیفه با شناسه {request.Id} یافت نشد");
        }

        // به‌روزرسانی پیشرفت
        task.ProgressPercentage = request.Progress;

        // به‌روزرسانی زمان صرف شده
        if (request.ActualHours.HasValue)
        {
            task.ActualHours = request.ActualHours.Value;
        }

        // اگر پیشرفت 100% است، وضعیت را به تکمیل شده تغییر دهید
        if (request.Progress == 100 && task.Status != "Completed")
        {
            task.Status = "Completed";
            task.CompletedDate = DateTime.UtcNow;
        }
        // اگر پیشرفت کمتر از 100% است و وضعیت تکمیل شده است، آن را به در حال انجام تغییر دهید
        else if (request.Progress < 100 && task.Status == "Completed")
        {
            task.Status = "InProgress";
            task.CompletedDate = null;
        }

        task.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
    }
}
