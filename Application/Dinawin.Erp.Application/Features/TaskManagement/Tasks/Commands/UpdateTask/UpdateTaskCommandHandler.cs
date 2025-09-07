using MediatR;
using Microsoft.EntityFrameworkCore;
using Dinawin.Erp.Application.Common.Interfaces;

namespace Dinawin.Erp.Application.Features.TaskManagement.Tasks.Commands.UpdateTask;

/// <summary>
/// مدیریت‌کننده دستور به‌روزرسانی وظیفه
/// </summary>
public sealed class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    /// <summary>
    /// سازنده مدیریت‌کننده دستور به‌روزرسانی وظیفه
    /// </summary>
    /// <param name="context">کنتکست دیتابیس</param>
    public UpdateTaskCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// اجرای دستور به‌روزرسانی وظیفه
    /// </summary>
    public async Task<Guid> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);
        if (task == null)
        {
            throw new ArgumentException($"وظیفه با شناسه {request.Id} یافت نشد");
        }

        // بررسی وجود پروژه در صورت ارسال
        if (request.ProjectId.HasValue)
        {
            var projectExists = await _context.Projects
                .AnyAsync(p => p.Id == request.ProjectId.Value, cancellationToken);
            if (!projectExists)
            {
                throw new ArgumentException($"پروژه با شناسه {request.ProjectId} یافت نشد");
            }
        }

        // بررسی وجود کاربر مسئول در صورت ارسال
        if (request.AssignedToUserId.HasValue)
        {
            var userExists = await _context.Users
                .AnyAsync(u => u.Id == request.AssignedToUserId.Value, cancellationToken);
            if (!userExists)
            {
                throw new ArgumentException($"کاربر با شناسه {request.AssignedToUserId} یافت نشد");
            }
        }

        task.Title = request.Title;
        task.Description = request.Description;
        task.ProjectId = request.ProjectId;
        task.AssignedToUserId = request.AssignedToUserId;
        task.CreatedByUserId = request.CreatedByUserId;
        task.Priority = request.Priority;
        task.Status = request.Status;
        task.TaskType = request.TaskType;
        task.PlannedStartDate = request.PlannedStartDate;
        task.PlannedEndDate = request.PlannedEndDate;
        task.ActualStartDate = request.ActualStartDate;
        task.ActualEndDate = request.ActualEndDate;
        task.ProgressPercentage = request.ProgressPercentage;
        task.EstimatedHours = request.EstimatedHours;
        task.ActualHours = request.ActualHours;
        task.Tags = request.Tags;
        task.IsActive = request.IsActive;
        task.UpdatedBy = request.UpdatedBy;
        task.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync(cancellationToken);
        return task.Id;
    }
}
